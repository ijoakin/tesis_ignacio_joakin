import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression


train_df = pd.read_csv("data/train.csv")
test = pd.read_csv("test.csv")

df = pd.concat((train_df, test))

df["FareStatus"] = np.where(df["Fare"] >= 10, "Fare>10", "Fare<10")
X = train_df.loc[:, 'Age':].to_numpy().astype('float')
y = train_df['Survived']

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

#

train_df.info()
#print(df.Cabin)

#print(df.columns)
#df.loc[]