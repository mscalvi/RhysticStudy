#include <stdio.h>

#define MAX 100

typedef struct {
    int valor;
    int esq;
    int dir;
} No;

typedef struct {
    No nos[MAX];
    int raiz;
    int livre;
} Arvore;

// Inicializa
void init(Arvore *a) {
    a->raiz = -1;
    a->livre = 0;
}

// Cria novo nó
int novoNo(Arvore *a, int valor) {
    int i = a->livre++;
    a->nos[i].valor = valor;
    a->nos[i].esq = -1;
    a->nos[i].dir = -1;
    return i;
}

// Inserção (ABB)
int inserirRec(Arvore *a, int raiz, int valor) {
    if (raiz == -1)
        return novoNo(a, valor);

    if (valor < a->nos[raiz].valor)
        a->nos[raiz].esq = inserirRec(a, a->nos[raiz].esq, valor);
    else
        a->nos[raiz].dir = inserirRec(a, a->nos[raiz].dir, valor);

    return raiz;
}

void inserir(Arvore *a, int valor) {
    a->raiz = inserirRec(a, a->raiz, valor);
}

/////////////////////
// PERCURSOS
/////////////////////

void emOrdem(Arvore *a, int r) {
    if (r != -1) {
        emOrdem(a, a->nos[r].esq);
        printf("%d ", a->nos[r].valor);
        emOrdem(a, a->nos[r].dir);
    }
}

void preOrdem(Arvore *a, int r) {
    if (r != -1) {
        printf("%d ", a->nos[r].valor);
        preOrdem(a, a->nos[r].esq);
        preOrdem(a, a->nos[r].dir);
    }
}

void posOrdem(Arvore *a, int r) {
    if (r != -1) {
        posOrdem(a, a->nos[r].esq);
        posOrdem(a, a->nos[r].dir);
        printf("%d ", a->nos[r].valor);
    }
}

/////////////////////
// MENOR / MAIOR
/////////////////////

int menor(Arvore *a, int r) {
    while (a->nos[r].esq != -1)
        r = a->nos[r].esq;
    return a->nos[r].valor;
}

int maior(Arvore *a, int r) {
    while (a->nos[r].dir != -1)
        r = a->nos[r].dir;
    return a->nos[r].valor;
}

/////////////////////
// SOMA
/////////////////////

int soma(Arvore *a, int r) {
    if (r == -1) return 0;

    return a->nos[r].valor
         + soma(a, a->nos[r].esq)
         + soma(a, a->nos[r].dir);
}

/////////////////////
// QUANTIDADE
/////////////////////

int contar(Arvore *a, int r) {
    if (r == -1) return 0;

    return 1
         + contar(a, a->nos[r].esq)
         + contar(a, a->nos[r].dir);
}

/////////////////////
// PROFUNDIDADE
/////////////////////

int altura(Arvore *a, int r) {
    if (r == -1) return -1;

    int hEsq = altura(a, a->nos[r].esq);
    int hDir = altura(a, a->nos[r].dir);

    return (hEsq > hDir ? hEsq : hDir) + 1;
}

/////////////////////
// BUSCA
/////////////////////

int buscar(Arvore *a, int r, int valor) {
    if (r == -1) return 0;

    if (a->nos[r].valor == valor) return 1;

    if (valor < a->nos[r].valor)
        return buscar(a, a->nos[r].esq, valor);
    else
        return buscar(a, a->nos[r].dir, valor);
}

/////////////////////
// MAIN
/////////////////////

int main() {
    Arvore a;
    init(&a);

    int valores[] = {10, 5, 20, 3, 7, 15, 30};
    int n = 7;

    for (int i = 0; i < n; i++)
        inserir(&a, valores[i]);

    printf("Em ordem: ");
    emOrdem(&a, a.raiz);
    printf("\n");

    printf("Pre ordem: ");
    preOrdem(&a, a.raiz);
    printf("\n");

    printf("Pos ordem: ");
    posOrdem(&a, a.raiz);
    printf("\n");

    printf("Menor: %d\n", menor(&a, a.raiz));
    printf("Maior: %d\n", maior(&a, a.raiz));

    printf("Soma: %d\n", soma(&a, a.raiz));
    printf("Quantidade de nos: %d\n", contar(&a, a.raiz));
    printf("Altura: %d\n", altura(&a, a.raiz));

    int x = 15;
    printf("Buscar %d: %s\n", x, buscar(&a, a.raiz, x) ? "Encontrado" : "Nao encontrado");

    return 0;
}