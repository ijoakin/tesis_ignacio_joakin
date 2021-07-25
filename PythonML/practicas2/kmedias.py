import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import os

from sklearn.datasets import make_blobs

datos = make_blobs(n_samples=200, n_features=2, centers=4) # centers es la cantidad de grupo que queremos

print(datos)

#plt.scatter(datos[0][:, 0], datos[0][:, 1]) #le paso la primer y segunda columna
#plt.show()

from sklearn.cluster import KMeans
modelo = KMeans(n_clusters=4)

modelo.fit(datos[0])

print(modelo.cluster_centers_)
print(modelo.labels_)

fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(12, 4))
ax1.scatter(datos[0][:, 0], datos[0][:, 1], c=modelo.labels_)
ax1.set_title('Algoritmo de k-medias')

ax2.scatter(datos[0][:, 0], datos[0][:, 1], c=datos[1])
ax2.set_title('Datos originales')

plt.show()
