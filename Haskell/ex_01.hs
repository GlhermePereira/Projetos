naturais = [ 0 ..100]

a = [ 3 * n | n <- naturais, n > 4, n < 30]

a 
[15,18,21,24,27,30,33,36,39,42,45,48,51,54,57,60,63,66,69,72,75,78,81,84,87]

------------------------------------------------
2º

naturais = [ 0 ..100]

b = [ n + 7 | n <- naturais, n > 1, n < 10]

b
[9,10,11,12,13,14,15,16]

------------------------------------------------
3º

naturais = [ 0 ..100]

c = [ 5 * n - 4 | n <- naturais, n > 0, n < 19]

c
[1,6,11,16,21,26,31,36,41,46,51,56,61,66,71,76,81,86]

------------------------------------------------
4º

naturais = [ 0 ..100]

d = [8 | n <- naturais, n > 10, n < 20]

d
[8,8,8,8,8,8,8,8,8]

--------------------------------------------------
5º

naturais = [ 0 ..100]

e = [ n - 44 | n <- naturais, n > 50, n < 60]

e
[7,8,9,10,11,12,13,14,15]