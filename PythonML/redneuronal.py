import numpy as np
import scipy as sc
import matplotlib.pyplot as plt

from sklearn.datasets import make_circles

# Crear el dataset
n = 500 #cantidad de registros
p = 2  #caracteristicas (ejemplo edad y altura)

X, Y = make_circles(n, factor=0.5, noise=0.05)
print(Y)

plt.scatter(X[Y==0, 0], X[Y==0, 1], c="skyblue")
plt.scatter(X[Y==1, 0], X[Y==1, 1], c="salmon")
plt.plot(axis="equal")
#plt.show()

class neuronal_layer:
    def __init__(self, n_conn, n_neur, act_f): #inicializador de la clase (nro de conexiones, nro de neuronas, funcion de activación
        self.act_f = act_f
        self.b = np.random.rand(1, n_neur) * 2 - 1 #va de -1 a 1 (es un vector como parametros de bayas)
        # para normalizarlo lo hacemos de -1 a 1
        self.w = np.random.rand(n_conn, n_neur) * 2 - 1 #va de -1 a 1
        #lo mismo hacemos para le nro de w


#funciones de activación (introduce no linealinedaes para poder agregar más neuronas
#sigmoide / relu

sigm = lambda x: 1 / (1 + np.e ** (-x)) #función sigmoide
dsigm = lambda x: x * (1 - x) # derivada de la función sigmoide

relu = lambda x: np.maximum(0, x)

tanh

_x = np.linspace(-5, 5, 100) #va de -5 a 5 de forma lineal, función que genera 100 valores
print(_x)
plt.plot(_x, dsigm(_x))
plt.show()





