import numpy as np
import pandas as pd
import matplotlib.pylab as plt

import os

raw_data_py = os.path.join("")

train_df = pd.read_csv("data/train.csv", index_col='PassengerId')
test_df = pd.read_csv("data/test.csv", index_col='PassengerId')

print(type(train_df))

df = pd.concat((train_df, test_df))

#df.Age.plot(kind='hist', title='histogram for age', color='c', bins=20)
#df.Age.plot(kind='kde', title='histogram for age', color='c')
print("skewness for age: {0:0.2f}".format(df.Age.skew()))
print("skewness for fare: {0:0.2f}".format(df.Fare.skew()))

df.plot.scatter(x="Age", y="Fare", color="c", title="scatter plot: Age vs Fare", alpha=0.1)

#median = df.groupby("Sex").Fare.median()
#median = df.groupby(['Pclass']).Age.median()

#print(median)

median = df.groupby(['Pclass']).agg({'Fare': 'mean', 'Age': 'median'})
#print(median)

ct = pd.crosstab(df.Sex, df.Pclass)
#print(ct)

ct = pd.crosstab(df.Sex, df.Pclass).plot(kind='bar')

#plt.show()
pivot = df.pivot_table(index="Sex", columns="Pclass", values="Age", aggfunc="mean")

print(pivot)
#print(df.info())

df["AgeState"] = np.where(df["Age"] >= 18, "Adult", "Child")
counts = df["AgeState"].value_counts()
print(counts)

#print(df.head())
crosstab = pd.crosstab(df[df.Survived != -888].Survived, df[df.Survived != -888].AgeState)
print(crosstab)