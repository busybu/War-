##Implementações de melhoria: 


Usar um único rand;
Usar pool size, um valor que vai ser 2*(atacantes + defensores)/ 10. esse valor vai servir para randomizar diversos valores que podem ser utilizados dentro do game.
usar rand.NextBytes(data) para preencher os valores do random, ele será mais rapido e dará um valor de 0 a 255 que deve ser mudado depois. 

colocar dentro da paralelização:
a randomização  para evitar o erro do valor randômico! 
INTERLOCKED usado para somar de uma forma "limpa" dentro das wins de cada war 

 
 REFAZER utilizando um VETOR NÃO COMPARTILHADO!!!!!!!!!
 