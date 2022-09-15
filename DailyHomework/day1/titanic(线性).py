# %% [markdown]

"""
Homework:

The folder '~//data//homework' contains data of Titanic with various features and survivals.

Try to use what you have learnt today to predict whether the passenger shall survive or not.

Evaluate your model.
"""
# %%
# 读取数据
import pandas as pd

data = pd.read_csv('C://Users//Bad Baseball//Desktop//ai//day1//data//homework//train.csv')
df = data.copy()
df.sample(10)
# %%
# 去除无用特征
df.drop(columns=['PassengerId', 'Name', 'Ticket', 'Cabin'], inplace=True)
df.info()
# %%
# 替换/删除空值，这里是删除
print('Is there any NaN in the dataset: {}'.format(df.isnull().values.any()))
df.dropna(inplace=True)
print('Is there any NaN in the dataset: {}'.format(df.isnull().values.any()))
# %%
# 把categorical数据通过one-hot变成数值型数据
# 很简单，比如sex=[male, female]，变成两个特征,sex_male和sex_female，用0, 1表示
df = pd.get_dummies(df)
# %%
# train-test split
y = df['Survived']
X = df.iloc[:, 1:]
import numpy as np
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=1)
print('X_train: {}'.format(np.shape(X_train)))
print('y_train: {}'.format(np.shape(y_train)))
print('X_test: {}'.format(np.shape(X_test)))
print('y_test: {}'.format(np.shape(y_test)))
# %%
# build model
from sklearn.linear_model import LinearRegression
reg = LinearRegression()
reg.fit(X_train, y_train)
print('Model intercept: ', reg.intercept_)
print('Model coefficients: ', reg.coef_)
print('y = {} + {} * X1 + {} * X2 + {} * X3 + {} * X4 + {} * X5 + {} * X6 + {} * X7 + {} * X8 + {} * X9 + {} * X10'.format(reg.intercept_, reg.coef_[0], reg.coef_[1], reg.coef_[2], reg.coef_[3], reg.coef_[4], reg.coef_[5], reg.coef_[6], reg.coef_[7], reg.coef_[8], reg.coef_[9]))
# %%
# predict and evaluate
from sklearn.metrics import r2_score

r2_score(y_train, reg.predict(X_train))

from sklearn.model_selection import cross_val_score

cross_val_score(reg, X_train, y_train, cv=10, scoring='r2').mean()

y_pred = reg.predict(X_test)
r2_score(y_test, y_pred)