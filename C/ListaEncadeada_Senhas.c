#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SENHAMAX 1000
#define LISTAMAX 20

int lista[LISTAMAX];
int tamanho = 0;

void mostrar() {
    printf("\nLista de senhas:\n");
    for (int i = 0; i < tamanho; i++) {
        printf("%d ", lista[i]);
    }
    printf("\n");
}

int existe(int senha) {
    for (int i = 0; i < tamanho; i++) {
        if (lista[i] == senha)
            return 1;
    }
    return 0;
}

void inserirOrdenado(int senha) {

    if (tamanho >= LISTAMAX) {
        printf("Lista cheia!\n");
        return;
    }

    if (existe(senha)) {
        printf("Senha %d ja existe.\n", senha);
        return;
    }

    int i = tamanho - 1;

    while (i >= 0 && lista[i] > senha) {
        lista[i + 1] = lista[i];
        i--;
    }

    lista[i + 1] = senha;
    tamanho++;
}

void removerMenor() {

    if (tamanho == 0) {
        printf("Lista vazia!\n");
        return;
    }

    for (int i = 0; i < tamanho - 1; i++) {
        lista[i] = lista[i + 1];
    }

    tamanho--;

    printf("Menor senha removida.\n");
}

int main() {

    srand(time(NULL));

    int opcao;

    do {
        printf("\n1 - Inserir nova senha\n");
        printf("2 - Remover menor senha\n");
        printf("3 - Mostrar lista\n");
        printf("0 - Sair\n");
        printf("Opcao: ");
        scanf("%d", &opcao);

        if (opcao == 1) {
            int senha = rand() % SENHAMAX + 1;
            printf("Senha gerada: %d\n", senha);
            inserirOrdenado(senha);
        }

        if (opcao == 2) {
            removerMenor();
        }

        if (opcao == 3) {
            mostrar();
        }

    } while (opcao != 0);

    return 0;
}