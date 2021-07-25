import pandas as pd
import numpy as np
import os
from sklearn.model_selection import train_test_split

#pathforData = os.path.join(os.path.pardir, "data")

train_df = pd.read_csv("data/train.csv")
test_df = pd.read_csv("data/test.csv")

#trainData.info()
#testData.info()

y = train_df["Survived"].ravel()
X = train_df.drop("Survived", axis=1, inplace=True).astype("float")

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

#print X.shpae, Y.shape doesn't work on pycharm

