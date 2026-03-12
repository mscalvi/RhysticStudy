#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct No {
    char nome[10];
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

void adicionarPessoa(Fila* f, char nome[]) {

    No* novo = (No*) malloc(sizeof(No));

    strcpy(novo->nome, nome);
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
        printf("Fila vazia! Hora de descansar!\n");
        return;
    }

    printf("Fique esperto! %s!\n", f->inicio->nome);
}

void atenderPessoa(Fila* f) {

    if (estaVazia(f)) {
        printf("Fila vazia.\n");
        return;
    }

    No* temp = f->inicio;

    printf("Próximo! %s!\n", temp->nome);

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
    char nome[10];

    do {

        printf("\n1 - Chegou alguém?\n");
        printf("2 - Quem é o próximo?\n");
        printf("3 - Manda entrar!\n");
        printf("4 - Falta muito?\n");
        printf("5 - Já acabou?\n");
        printf("0 - Chega por hoje!\n");
        printf("Opcao: ");
        scanf("%d", &opcao);
        getchar();

        switch (opcao) {

        case 1:
            printf("Nome: ");
            fgets(nome, 50, stdin);
            nome[strcspn(nome, "\n")] = 0;
            adicionarPessoa(&fila, nome);
            break;

        case 2:
            verPrimeiro(&fila);
            break;

        case 3:
            atenderPessoa(&fila);
            break;

        case 4:
            printf("Faltam %d pessoas.\n", quantidade(&fila));
            break;

        case 5:
            if (estaVazia(&fila))
                printf("Não tem ninguém!\n");
            else
                printf("Tem gente ainda...\n");
            break;
        }

    } while (opcao != 0);

    return 0;
}