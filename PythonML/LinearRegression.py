import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn import metrics

casas = pd.read_csv("data/USA_Housing.csv")
#cd C:\devel2\tesis\machineLearning

#print(casas.head(20))
#print(casas.info())
#print(casas.describe())
#print(casas.columns)
#print(casas['Price'])
#print(casas.describe())

# fail print(casas["Avg. Area House Ag"])
# sns.distplot(casas['Price']) # generate a graph con jupyter notebook
#sns.heatmap(casas.corr(), annot=True)# generate a graph con jupyter notebook

#print(casas.head())
#print(casas.columns)
X = casas[['Avg. Area Income', 'Avg. Area House Age', 'Avg. Area Number of Rooms',
       'Avg. Area Number of Bedrooms', 'Area Population']] #caracteristicas Features
Y = casas['Price'] #Valor objetivo
print(X)
print(Y)
# ahora vamos a dividir en datos de prueba y datos de entrenamiento.
# al poner test_size tomamos el 30% de los datos para tests y el 70 para entrenamiento
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=0.3, random_state=42)

#ahora que ya tenemos los datos separados vamos a entrenar el modelo.
lrm = LinearRegression()
lrm.fit(X_train, Y_train)

#ahora vamos a evaluar el modelo con los datos de prueba para generar un modelo definitivo.
predicciones = lrm.predict(X_test)
print(predicciones)
# podemos realizar un grafico entre los valores de test y los valores de predicción, al ver el grafico
#y trazar una linea diagonal entre todos los valores nos damos cuenta que el modelo esta prediciendo de una
#buena manera y podemos decir que es un buen modelo.
plt.scatter(Y_test, predicciones)
plt.show()
#por otro lado podemos hacer un grafico de su distribución
sns.distplot(Y_test - predicciones)
plt.show()
# al ver que esta distribucióm se acerca bastante a una ditribución normal podemos decir que es un buen
# esta distribución se realiza con los valores del error que tiene entre los datos de prueba y los datos de prediccion

#modelo para que se convierta en un modelo definitivo.
#Luego podemos evaluar nuestro modelo con datos numericos.

#metricas
# MAE Mean Absolute error, Media del valor absoluto de los errores
MAE = metrics.mean_absolute_error(Y_test, predicciones)
print(MAE)
#MSE Media de los errores al cuadrado.
MSE = metrics.mean_squared_error(Y_test, predicciones)
print(MSE)
#RSME raiz cuadrada de la media de los errores al cuadrado.
RSME = np.sqrt(MSE)
print(RSME)