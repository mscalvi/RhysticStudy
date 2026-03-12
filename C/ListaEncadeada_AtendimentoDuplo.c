#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct No {
    char tipo;
    char nome[10];
    struct No* proximo;
    struct No* anterior;
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

void adicionarPessoa(Fila* f, char tipo, char* nome) {

    No* novo = (No*) malloc(sizeof(No));

    strcpy(novo->nome, nome);
    novo->tipo = tipo;
    novo->proximo = NULL;
    novo->anterior = NULL;

    if (estaVazia(f)) {
        f->inicio = novo;
        f->fim = novo;
    } else if (tipo == 'g') {
        No* temp = f->inicio;

        while (temp != NULL && temp->tipo == 'g') {
            temp = temp->proximo;
        }

        if (temp == f->inicio) { 
            novo->proximo = f->inicio;
            f->inicio->anterior = novo;
            f->inicio = novo;
        } else if (temp == NULL) { 
            novo->anterior = f->fim;
            f->fim->proximo = novo;
            f->fim = novo;
        } else {
            novo->proximo = temp;
            novo->anterior = temp->anterior;
            temp->anterior->proximo = novo;
            temp->anterior = novo;
        }
    } else {
        novo->anterior = f->fim;
        f->fim->proximo = novo;
        f->fim = novo;
    }   

    f->tamanho++;
}

void verPrimeiro(Fila* f) {

    if (estaVazia(f)) {
        printf("Fila vazia!\n");
        return;
    }

    if (f->inicio->tipo == 'g'){
        printf("Fique esperto! %s!\n", f->inicio->nome);
    } else {
        printf("Fique esperto! %s!\n", f->fim->nome);
    }
}

void atenderPessoa(Fila* f) {

    if (estaVazia(f)) {
        printf("Fila vazia.\n");
        return;
    }

    if(f->inicio->tipo == 'g'){
        No* temp = f->inicio;

        printf("Próximo! %s!\n", temp->nome);

        f->inicio = temp->proximo;

        if (f->inicio != NULL)
            f->inicio->anterior = NULL;
        
        free(temp);
    } else {
        No* temp = f->fim;

        printf("Próximo! %s!\n", temp->nome);

        f->fim = temp->anterior;

        if (f->fim != NULL)
            f->fim->proximo = NULL;
        else
            f->inicio = NULL;

        free(temp);
    }

    f->tamanho--;
}

int quantidade(Fila* f) {
    return f->tamanho;
}

int main() {

    Fila fila;
    inicializar(&fila);

    int opcao;
    char tipo;
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
            fgets(nome, 10, stdin);
            nome[strcspn(nome, "\n")] = 0;
            printf("Caso grave: g.\nCaso comum: a.\n");
            scanf(" %c", &tipo);
            adicionarPessoa(&fila, tipo, nome);
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