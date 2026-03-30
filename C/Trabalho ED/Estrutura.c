#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct No {
    char placa[7];
    struct No* prox;
} No;

typedef struct {
    No* inicio;
    No* fim;
    int tamanho;
} Fila;

void inicializar(Fila* f) {
    f->inicio = NULL;
    f->fim = NULL;
    f->tamanho = 0;
}

int estaVazia(Fila* f) {
    return f->inicio == NULL;
}

void adicionarEntrada(Fila* f, char placa[]) {

    No* novo = (No*) malloc(sizeof(No));

    strcpy(novo->placa, placa);
    novo->prox = NULL;

    if (estaVazia(f)) {
        f->inicio = novo;
        f->fim = novo;
    } else {
        f->fim->prox = novo;
        f->fim = novo;
    }

    f->tamanho++;
}

void verPrimeiro(Fila* f) {

    if (estaVazia(f)) {
        printf("Fila vazia.\n");
        return;
    }

    printf("Primeiro: %s\n", f->inicio->placa);
}

void atenderPessoa(Fila* f) {

    if (estaVazia(f)) {
        printf("Fila vazia.\n");
        return;
    }

    No* temp = f->inicio;

    printf("Andando: %s\n", temp->placa);

    f->inicio = temp->prox;

    if (f->inicio == NULL)
        f->fim = NULL;

    free(temp);

    f->tamanho--;
}

int quantidade(Fila* f) {
    return f->tamanho;
}

int main() {

    Fila fila;
    inicializar(&fila);

    int opcao;
    char placa[7];

    do {

        printf("\n1 - Registrar Entrada\n");
        printf("2 - Conferir Primeiro\n");
        printf("3 - Andar Fila\n");
        printf("4 - Contar Fila\n");
        printf("0 - Sair\n");
        printf("Opcao: ");
        scanf("%d", &opcao);
        getchar();

        switch (opcao) {

        case 1:
            printf("Placa: ");
            fgets(placa, 7, stdin);
            placa[strcspn(placa, "\n")] = 0;
            adicionarEntrada(&fila, placa);
            break;

        case 2:
            verPrimeiro(&fila);
            break;

        case 3:
            atenderPessoa(&fila);
            break;

        case 4:
            printf("%d entradas na Fila\n", quantidade(&fila));
            break;
        default:
            break;
        }

    } while (opcao != 0);

    return 0;
}