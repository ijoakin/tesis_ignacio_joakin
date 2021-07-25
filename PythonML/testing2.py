import numpy as np
import pandas as pd
import warnings
warnings.filterwarnings("ignore", category=DeprecationWarning)
import urllib3
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
import pymssql as pms
import requests
import cufflinks as cf
from plotly.offline import download_plotlyjs, init_notebook_mode, plot, iplot
import plotly.io as pio
pio.renderers.default = "png"


etiquetas = ['a','b', 'c']
datos = [1, 2, 3]

#series
pd.Series(data = datos, index=etiquetas)
array = np.arange(0,10)
pd.Series(array)

#dataframes
filas = ['ventas', 'ventas2', 'ventas3']
columnas = ['zonaA', 'zonaB', 'zonaC']
datos = [[21, 23, 31],
         [13, 21, 33],
         [13, 28, 33]
         ]
dataframe = pd.DataFrame(datos, filas, columnas)

dataframe['todaslaszonas'] = dataframe['zonaA'] + dataframe['zonaB'] + dataframe['zonaC']
print(dataframe)
#selecionamos la primer columna
#print(dataframe.loc['ventas'])
# connect to the database
cnx = {
    'host': 'WIN10',
    'username': 'sa',
    'password': 'Ignacio05',
    'db': 'Products'
}
conn = pms.connect(cnx['host'], cnx['username'], cnx['password'], cnx['db'])

cursor = conn.cursor()
query = 'SELECT * FROM Products'
cursor.execute(query)
result = cursor.fetchall()
for row in result:
    print(row)
conn.close()

url = 'https://localhost:44313/api/Products/GetProducts'
result = requests.get(url, verify=False)

print(result.status_code)
#print(result.json())
print(result.headers)

for product in result.json():
    print(product['description'])


init_notebook_mode(connected=True)
cf.go_offline()

#%matplotlib inline
dataframe = pd.DataFrame(np.random.randn(100, 4), columns=['a', 'b', 'c', 'd'])
print(dataframe)
p = dataframe.plot()
