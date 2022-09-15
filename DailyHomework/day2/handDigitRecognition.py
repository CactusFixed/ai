# %% [markdown]

"""
Homework:

The folder '~//data//homework' contains a folder 'Data', containing hand-digits of letters a-z stored in .txt.

Try to establish a network to classify the digits.

`dataLoader.py` offers APIs for loading data.
"""
# %%
import dataLoader as dl

features,labels=dl.readData(r'../data/homework/Data')

# %%
import matplotlib.pyplot as plt
plt.plot(features[5,0:30],features[5,30:])
plt.suptitle="Real: "+labels[5]
plt.show()
# %%

# feature engineering (if necessary)
# %%
try:
    from .dataLoader import *
except:
    from dataLoader import *

labels = np.array([letter2Number(label) for label in labels])
# train-test split
# %%
import numpy as np
from sklearn.model_selection import train_test_split
features_train, features_test, labels_train, labels_test = train_test_split(features, labels, test_size=0.2, random_state=1)
print('features_train: {}'.format(np.shape(features_train)))
print('labels_train: {}'.format(np.shape(labels_train)))
print('features_test: {}'.format(np.shape(features_test)))
print('labels_test: {}'.format(np.shape(labels_test)))
# build the network
# %%
import tensorflow as tf
model = tf.keras.Sequential([
    tf.keras.layers.Flatten(input_shape=(60,)),
    tf.keras.layers.Dense(128, activation="relu"),
    tf.keras.layers.Dense(26)
])
# training
# %%
model.compile(optimizer='adam',
              loss=tf.keras.losses.SparseCategoricalCrossentropy(from_logits=True),
              metrics=['accuracy'])
model.fit(features_train, labels_train, epochs=10)
# predict and evaluate
test_loss, test_acc = model.evaluate(features_test,  labels_test, verbose=1)

print('\nTest accuracy:', test_acc)

probability_model = tf.keras.Sequential([model, tf.keras.layers.Softmax()])

predictions = probability_model.predict(features_test)

for prediction in predictions:
    print("The maximum probability letter: ", number2Letter(np.argmax(prediction)))

