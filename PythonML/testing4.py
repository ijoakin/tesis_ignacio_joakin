import pandas as pd
import numpy as np

import cufflinks as cf
from plotly.offline import download_plotlyjs, init_notebook_mode, plot, iplot

cf.go_offline()
dataframe = pd.DataFrame(np.random.randn(100, 4), columns=['a', 'b', 'c', 'd'])
print(dataframe)

dataframe.plot()
#dataframe.iplot()
#dataframe.iplot(kind='scatter', x='a', y='b', mode='markers')


