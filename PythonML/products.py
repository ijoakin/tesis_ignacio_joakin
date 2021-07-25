import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import warnings
warnings.filterwarnings("ignore", category=DeprecationWarning)
import urllib3
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
import pymssql as pms
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
import seaborn as sns
from sklearn import metrics

cnx = {
    'host': 'WIN10',
    'username': 'sa',
    'password': 'Ignacio05',
    'db': 'Products'
}

conn = pms.connect(cnx['host'], cnx['username'], cnx['password'], cnx['db'])

cursor = conn.cursor(as_dict=True)

#query = ("select * from MLModel where success = 0 and product = 74 order by [year]")
query = ("select * from MLModel where success = 0 and product = 74 and salepoint = 8 order by [year]")

print(query)
cursor.execute(query)
result = cursor.fetchall()

productsDataFrame = pd.DataFrame(result)

print(productsDataFrame.columns)
# X = productsDataFrame[['month', 'year', 'salepoint', 'product', 'success']]
# Y = productsDataFrame[['amount']]
#
# # ahora vamos a dividir en datos de prueba y datos de entrenamiento.
# # al poner test_size tomamos el 30% de los datos para tests y el 70 para entrenamiento
# X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=0.3, random_state=42)
#
# #ahora que ya tenemos los datos separados vamos a entrenar el modelo.
# lrm = LinearRegression()
# lrm.fit(X_train, Y_train)
#
# predicciones = lrm.predict(X_test)
# #print(predicciones)
# # podemos realizar un grafico entre los valores de test y los valores de predicción, al ver el grafico
# #y trazar una linea diagonal entre todos los valores nos damos cuenta que el modelo esta prediciendo de una
# #buena manera y podemos decir que es un buen modelo.
#
# plt.scatter(Y_test, predicciones)
# plt.show()

#sns.distplot(Y_test - predicciones)


#valores = []

#for row in result:
#    valores.append(row)

# print(valores.columns())