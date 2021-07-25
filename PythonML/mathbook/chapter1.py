import numpy as np
import scipy as sc

from decimal import Decimal
from decimal import getcontext
from decimal import localcontext
num = Decimal("1.1")
with localcontext() as ctx:
    ctx.prec = 2
    num**4  # Decimal('1.5')
num**4  # Decimal('1.4641')
print(num)

ctx = getcontext()

num1 = Decimal('1.1')
num2 = Decimal('1.563')
num1 + num2  # Decimal('2.663')

#num = Decimal('2.2')

#num**4 # Decimal
#ctx.prec = 4 # set new precision
#num**4  # Decimal('1.464')
#print(num)


# for i in range(0, 100):
#    print(i)

