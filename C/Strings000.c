# include<stdio.h>

/*Sequencia de caracteres (string), ou um vetor*/

int main(){
    char palavra [80] = "Olá, boa noite. Estamos trabalhando com strings";
    printf("Digite o seu nome: ");
    // usando o gets para ler string
    //scanf("%s", palavra);
    gets(palavra);
    // agora ele salva até o nome composto
    printf("Seu nome é: %s\n", palavra);

    return 0;
}