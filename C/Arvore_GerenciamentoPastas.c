#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Pasta {
    char nome[50];
    struct Pasta* filho;
    struct Pasta* irmao;
} Pasta;

//////////////////////////////
// CRIAR PASTA
//////////////////////////////

Pasta* criarPasta(char* nome) {
    Pasta* nova = (Pasta*) malloc(sizeof(Pasta));
    strcpy(nova->nome, nome);
    nova->filho = NULL;
    nova->irmao = NULL;
    return nova;
}

//////////////////////////////
// BUSCAR PASTA
//////////////////////////////

Pasta* buscar(Pasta* raiz, char* nome) {
    if (raiz == NULL) return NULL;

    if (strcmp(raiz->nome, nome) == 0)
        return raiz;

    Pasta* achou = buscar(raiz->filho, nome);
    if (achou != NULL) return achou;

    return buscar(raiz->irmao, nome);
}

//////////////////////////////
// CRIAR SUBPASTA
//////////////////////////////

void criarSubpasta(Pasta* raiz, char* nomeMae, char* nomeNova) {

    Pasta* mae = buscar(raiz, nomeMae);

    if (mae == NULL) {
        printf("Pasta mae nao encontrada.\n");
        return;
    }

    // evita duplicado no mesmo nivel
    Pasta* temp = mae->filho;
    while (temp != NULL) {
        if (strcmp(temp->nome, nomeNova) == 0) {
            printf("Ja existe uma pasta com esse nome.\n");
            return;
        }
        temp = temp->irmao;
    }

    Pasta* nova = criarPasta(nomeNova);

    if (mae->filho == NULL) {
        mae->filho = nova;
    } else {
        temp = mae->filho;
        while (temp->irmao != NULL)
            temp = temp->irmao;

        temp->irmao = nova;
    }

    printf("Pasta '%s' criada dentro de '%s'\n", nomeNova, nomeMae);
}

//////////////////////////////
// REMOVER SUBÁRVORE
//////////////////////////////

void liberarSubarvore(Pasta* raiz) {
    if (raiz == NULL) return;

    liberarSubarvore(raiz->filho);
    liberarSubarvore(raiz->irmao);

    free(raiz);
}

//////////////////////////////
// REMOVER PASTA
//////////////////////////////

void removerPasta(Pasta* raiz, char* nome) {

    if (raiz == NULL) return;

    Pasta* anterior = NULL;
    Pasta* atual = raiz->filho;

    while (atual != NULL) {

        if (strcmp(atual->nome, nome) == 0) {

            if (anterior == NULL)
                raiz->filho = atual->irmao;
            else
                anterior->irmao = atual->irmao;

            liberarSubarvore(atual);

            printf("Pasta '%s' removida.\n", nome);
            return;
        }

        // busca recursiva nos filhos
        removerPasta(atual, nome);

        anterior = atual;
        atual = atual->irmao;
    }
}

//////////////////////////////
// IMPRIMIR
//////////////////////////////

void imprimir(Pasta* raiz, int nivel) {
    if (raiz == NULL) return;

    for (int i = 0; i < nivel; i++)
        printf("  ");

    printf("%s\n", raiz->nome);

    imprimir(raiz->filho, nivel + 1);
    imprimir(raiz->irmao, nivel);
}

//////////////////////////////
// MENU
//////////////////////////////

int main() {

    Pasta* raiz = criarPasta("/");

    int opcao;
    char mae[50], nome[50];

    do {
        printf("\n1 - Criar pasta\n");
        printf("2 - Remover pasta\n");
        printf("3 - Mostrar estrutura\n");
        printf("0 - Sair\n");
        printf("Opcao: ");
        scanf("%d", &opcao);
        getchar();

        switch (opcao) {

        case 1:
            printf("Nome da pasta mae: ");
            fgets(mae, 50, stdin);
            mae[strcspn(mae, "\n")] = 0;

            printf("Nome da nova pasta: ");
            fgets(nome, 50, stdin);
            nome[strcspn(nome, "\n")] = 0;

            criarSubpasta(raiz, mae, nome);
            break;

        case 2:
            printf("Nome da pasta a remover: ");
            fgets(nome, 50, stdin);
            nome[strcspn(nome, "\n")] = 0;

            if (strcmp(nome, "/") == 0) {
                printf("Nao pode remover a raiz!\n");
            } else {
                removerPasta(raiz, nome);
            }
            break;

        case 3:
            printf("\nEstrutura:\n");
            imprimir(raiz, 0);
            break;

        }

    } while (opcao != 0);

    return 0;
}