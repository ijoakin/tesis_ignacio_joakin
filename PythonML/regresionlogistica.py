import warnings
warnings.filterwarnings("ignore", category=DeprecationWarning)

import numpy as np
import pandas as pd
import matplotlib.pyplot as pl
import seaborn as sns

from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import classification_report

#cd C:\devel2\tesis\machineLearning

def edad_media(columnas):
    edad=columnas[0]
    clase=columnas[1]
    if (pd.isnull(edad)):
        if clase == 1:
            return 38
        elif clase == 2:
            return 30
        else:
            return 25
    else:
        return edad
def convertToFloat(valor):
    return float(valor)

test = pd.read_csv("data/test.csv")
train = pd.read_csv("data/train.csv")

#print(train.head())

#sns.heatmap(train.isnull())
#sns.countplot(x='Survived', data=train)
#sns.countplot(x='Survived', data=train, hue='Pclass')
#sns.distplot(train['Age'].dropna(), kde=False, bins=30)
#train['Age'].plot.hist(bins=30)
# tomar los valores medios de cada edad por clase

sns.boxplot(x="Pclass", y='Age', data=train)
#pl.show()
#Limpiamos los datos.

#le ponemos el valor medio a los valores nulos
train["Age"] = train[['Age', 'Pclass']].apply(edad_media, axis=1)
#borramos la columna Cabin
train.drop('Cabin', axis=1, inplace=True)
train.drop(['Name', 'Ticket', 'PassengerId'], axis=1, inplace=True)

sex = pd.get_dummies(train['Sex'], drop_first=True)
embarked = pd.get_dummies(train['Embarked'], drop_first=True)
S = embarked['S'].apply(convertToFloat)
Q = embarked['Q'].apply(convertToFloat)

print(embarked)

sns.heatmap(train.isnull())

train = pd.concat([train, sex, Q, S], axis=1)
train.drop('Sex', axis=1, inplace=True)
train.drop('Embarked', axis=1, inplace=True)
print(train)
#
y = train['Survived'] #nos quedamos con la columna Survived (la columna objetivo
X = train.drop('Survived', axis=1) #nos quedamos con todo menos la columna Survived (son las caracteristicas)
#print(X)

# #split the data into train and test data 70%
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=45)
model = LogisticRegression() #Create the model
model.fit(X_train, y_train) #train the model with features and labels
#
predicciones = model.predict(X_test)

print(predicciones)

print(classification_report(y_test, predicciones))

#pl.sho1w()