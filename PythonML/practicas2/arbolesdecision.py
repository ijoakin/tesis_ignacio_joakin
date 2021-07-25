import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import os

print(os.getcwd())
print(os.listdir())

vinos = pd.read_csv(os.getcwd() + "/../data/vino.csv")
#print(vinos.head())
print(vinos.columns)
print(vinos["Wine Type"].unique())
print(vinos["Wine Type"].value_counts())

X = vinos.drop('Wine Type', axis=1)
y = vinos['Wine Type']

from sklearn.model_selection import train_test_split

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3,random_state=True)

#--------------------------- arboles de decision ------------------------------------ (algoritmos de clasificaciones)
from sklearn.tree import DecisionTreeClassifier

arbol = DecisionTreeClassifier()

arbol.fit(X_train, y_train)
predicciones = arbol.predict(X_test)
print(predicciones)

from sklearn.metrics import classification_report, confusion_matrix

print(classification_report(y_test, predicciones))

print(confusion_matrix(y_test, predicciones))

#--------------------------- Random FOrest... una variación de arboles de decision ---------------------------
#---- supuestamente es más preciso ---------------------------------------------------------------------------

from sklearn.ensemble import RandomForestClassifier
forest = RandomForestClassifier(n_estimators=80)
forest.fit(X_train, y_train)
prediccionesforest = forest.predict(X_test)

print(classification_report(y_test, prediccionesforest))

print(confusion_matrix(y_test, prediccionesforest))

