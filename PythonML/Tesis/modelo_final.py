import warnings
warnings.filterwarnings("ignore", category=DeprecationWarning)
import urllib3
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
import pymssql as pms
import pandas as pd
import numpy as np

import matplotlib.pylab as plt

from keras.models import Sequential
from keras.layers import Dense, Activation, Flatten
from sklearn.preprocessing import MinMaxScaler

PASOS = 7
salepointid = "92"
productid = "14"
EPOCHS = 80

def to_str(var):
    if type(var) is list:
        return str(var)[1:-1] # list
    if type(var) is np.ndarray:
        try:
            return str(list(var[0]))[1:-1] # numpy 1D array
        except TypeError:
            return str(list(var))[1:-1] # numpy sequence
    return str(var) # everything else

def crear_modeloFF():
    model = Sequential()
    model.add(Dense(PASOS, input_shape=(1, PASOS),activation='tanh'))
    model.add(Flatten())
    model.add(Dense(1, activation='tanh'))
    model.compile(loss='mean_absolute_error',optimizer='Adam',metrics=["mse"])
    model.summary()
    return model

def agregarNuevoValor(x_test, nuevoValor):
    for i in range(x_test.shape[2] - 1):
        x_test[0][0][i] = x_test[0][0][i + 1]
    x_test[0][0][x_test.shape[2] - 1] = nuevoValor
    return x_test

# convert series to supervised learning
def series_to_supervised(data, n_in=1, n_out=1, dropnan=True):
    n_vars = 1 if type(data) is list else data.shape[1]
    df = pd.DataFrame(data)
    cols, names = list(), list()
    # input sequence (t-n, ... t-1)
    for i in range(n_in, 0, -1):
        cols.append(df.shift(i))
        names += [('var%d(t-%d)' % (j + 1, i)) for j in range(n_vars)]
    # forecast sequence (t, t+1, ... t+n)
    for i in range(0, n_out):
        cols.append(df.shift(-i))
        if i == 0:
            names += [('var%d(t)' % (j + 1)) for j in range(n_vars)]
        else:
            names += [('var%d(t+%d)' % (j + 1, i)) for j in range(n_vars)]
    # put it all together
    agg = pd.concat(cols, axis=1)
    agg.columns = names
    # drop rows with NaN values
    if dropnan:
        agg.dropna(inplace=True)
    return agg

cnx = {
    'host': 'WIN10',
    'username': 'sa',
    'password': 'Ignacio05',
    'db': 'Products'
}

conn = pms.connect(cnx['host'], cnx['username'], cnx['password'], cnx['db'])

cursor = conn.cursor(as_dict=True)

queryProductsAndSalespoint = '''
    select salepointid, productid, count(*) as amount from Searches 
    where  salepointid = ''' + salepointid + ''' and productid = ''' + productid + '''
        group by salepointid, productid
    '''
cursor.execute(queryProductsAndSalespoint)
productsAndSalePointResult = cursor.fetchall()

valores = []
for productsAndSalePointRow in productsAndSalePointResult:
    salepointid = productsAndSalePointRow["salepointid"]
    productid = productsAndSalePointRow["productid"]
    #print(productsAndSalesRow)

    query = '''
        select date as fecha, sum(amount) as unidades from Searches 
        where  salepointid = ''' + str(salepointid) + ''' and productid = ''' + str(productid) + '''
        group by date
        '''

    df = pd.read_sql(query, conn)
    df = df.set_index("fecha")
    print(df.head())
    print(df.index.min())
    print(df.index.max())

    print(len(df['2018']))
    meses = df.resample('M').mean()
    print(meses)
    plt.plot(meses['2017'].values)
    plt.plot(meses['2018'].values)
    #plt.show()
    #plt.rcParams['figure.figsize'] = (16, 9)
    #plt.style.use('fast')
    #verano2020 = df['2020-06-01':'2020-09-01']
    #plt.plot(verano2020.values)
    verano2018 = df['2018-06-01':'2018-09-01']
    plt.plot(verano2018.values)

    # plt.show()
    # Cargamos el dataset
    values = df.values
    # nos aseguramos que todos los velores sean float 32, recordemos que CUDA y la grafica utiliza float
    values = values.astype('float32')
    # normalizamos las features
    scaler = MinMaxScaler(feature_range=(-1, 1))
    values = values.reshape(-1, 1)  # esto lo hacemos porque tenemos 1 sola dimension
    scaled = scaler.fit_transform(values)
    # encuadramos el problema como un problema de aprendizaje suepervisado
    reframed = series_to_supervised(scaled, PASOS, 1)
    print(reframed.head())

    # dividimos la información en datos de entrenamiento y datos de prueba
    values = reframed.values
    n_train_days = 315 + 289 - (30 + PASOS)
    train = values[:n_train_days, :]
    test = values[n_train_days:, :]
    # dividimos en entrada y salida
    x_train, y_train = train[:, :-1], train[:, -1]

    x_val, y_val = test[:, :-1], test[:, -1]
    # cambiamos el input para que posea 3 dimensiones [samples, timesteps, features]
    x_train = x_train.reshape((x_train.shape[0], 1, x_train.shape[1]))
    x_val = x_val.reshape((x_val.shape[0], 1, x_val.shape[1]))
    print(x_train.shape, y_train.shape, x_val.shape, y_val.shape)

    model = crear_modeloFF()

    history = model.fit(x_train, y_train, epochs=EPOCHS, validation_data=(x_val, y_val), batch_size=PASOS)
    print(x_val)

    # Visualizamos al conjunto de validación (recordemos que eran 30 días)
    result_scatter = model.predict(x_val)
    plt.scatter(range(len(y_val)), y_val, c='g')
    plt.scatter(range(len(result_scatter)), result_scatter, c='r')
    plt.title('validate')
    #plt.show()
#
    queryUltimos = '''select top 15 CONVERT(date, [date]) as fecha from Searches order by [date] desc'''

    dfultimos = pd.read_sql(queryUltimos, conn)
    dfultimos = dfultimos.set_index("fecha")
    print(dfultimos.head())
    print("primer día:" + str(dfultimos.index.min()))
    print("ultimo día:" + str(dfultimos.index.max()))

    ultimosDias = df[dfultimos.index.min():dfultimos.index.max()]

    print(ultimosDias)

    values = ultimosDias.values
    values = values.astype('float32')
    # Normalizamos los features
    values = values.reshape(-1, 1)  # esto lo hacemos porque tenemos 1 sola dimension
    scaled = scaler.fit_transform(values)
    reframed = series_to_supervised(scaled, PASOS, 1)
    reframed.drop(reframed.columns[[7]], axis=1, inplace=True)
    print(reframed.head(7))

    values = reframed.values
    x_test = values
    #x_test = values[6:, :]
    x_test = x_test.reshape((x_test.shape[0], 1, x_test.shape[1]))
    print(x_test)
#
    results = []
    for i in range(7):
        parcial = model.predict(x_test)
        results.append(parcial[0])
        print(x_test)
        x_test = agregarNuevoValor(x_test, parcial[0])

    adimen = [x for x in results]
    inverted = scaler.inverse_transform(adimen)
    inverted
#
    prediccion = pd.DataFrame(inverted)
    prediccion.columns = ['pronostico']
    prediccion.plot()
    #plt.show()
    print(prediccion.info())

    for index, row in prediccion.iterrows():
        value = row['pronostico']
        print(type(value))
        print(value)
        print(to_str(value))
        with conn.cursor() as cursor:
            query = '''
            INSERT INTO [dbo].[Predictions]
               ([date]
               ,[day]
               ,[month]
               ,[year]
               ,[salepointid]
               ,[productid]
               ,[amount], applied)
             VALUES
               ('2020-12-01'
               ,''' + str(index) + '''
               ,12
               ,2020
               ,''' + str(salepointid) + '''
               ,''' + str(productid) + '''
               ,''' + to_str(value) + '''
               ,0)'''
            # Create a new record
            cursor.execute(query)
            conn.commit()
        #print(str(row['pronostico']))
#
    prediccion.to_csv('pronostico-' + str(salepointid) + '-' + str(productid) + '.csv')
#
#
#    meses = df.resample('M').mean()
 #   print(meses)
#
#
#
#
