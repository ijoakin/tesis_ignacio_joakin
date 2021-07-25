import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import os

#utilizaremos un dataframe de seaborn por defecto llamado iris

flores = sns.load_dataset("iris")

print(flores.head())

print(flores["species"].unique())

#sns.pairplot(flores, hue="species")
#plt.show()

# lo de siempre dividimos entre features (caracteristicas) y columna objetiivo
from sklearn.model_selection import train_test_split

X = flores.drop("species", axis=1)
y = flores["species"]

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3)

from sklearn.svm import SVC

modelo = SVC(gamma='auto')
modelo.fit(X_train, y_train)
predicciones = modelo.predict(X_test)

print(predicciones)

from sklearn.metrics import classification_report, confusion_matrix

print(classification_report(y_test, predicciones))
print(confusion_matrix(y_test, predicciones))


