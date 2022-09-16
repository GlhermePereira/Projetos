texto = '{0} tem {idade} anos de idade'
print('Progama para calcular a idade de uma pessoa',end='\n\n')

nome = input('Entre com o nome da pessoa: \n')

a1 = int(input('Entre com o ano de nascimento: \n'))

a2 = int(input('Entre com ano atual: \n'))

print(texto.format(nome, idade = a2 - a1 ))

