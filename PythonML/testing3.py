import numpy as np
import sys
print(sys.getdefaultencoding())

arr = []
for i in np.arange(100):
    arr.append(i)

print(arr)
print(np.sum(arr))
#testing excetions.
try:
    for i in range(0,10):
        print(i)
        #raise TypeError("raising an error")
    f = open("data/testing_file.txt", mode='wt', encoding="utf-8")
    f.write("Ignacio Joakin\n")
    f.write("Ignacio Joakin")
    f.close()
    f = open("data/testing_file.txt", mode='rt', encoding="utf-8")

    for line in f:
        print(line)


except (KeyError, TypeError) as e:
    txt = "Conversion error : {error}"
    print(txt.format(error=e))




