n =int(input('Digite um numero: '))
div= [1,2,3,4,5,6,7,8,9,10]
cont= int(0)

for d in div:
    cont+=1
    print('-------------')
    print('|',n,'x',cont,'=',div[cont-1]*n,'|')
print('-------------')

    
