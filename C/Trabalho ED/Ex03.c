#include <stdio.h>
#include <string.h>

#define MAX 100
#define TAM 50

typedef struct {
    char itens[MAX][TAM];
    int topo;
} Pilha;

// Inicializa
void init(Pilha* p) {
    p->topo = -1;
}

// Verifica se vazia
int vazia(Pilha* p) {
    return p->topo == -1;
}

// Push
void push(Pilha* p, char* str) {
    if (p->topo < MAX - 1) {
        p->topo++;
        strcpy(p->itens[p->topo], str);
    }
}

// Pop
void pop(Pilha* p) {
    if (!vazia(p)) {
        p->topo--;
    }
}

// Função principal de simplificação
void simplificar(char* caminho, char* resultado) {

    Pilha p;
    init(&p);

    char temp[TAM];
    int j = 0;

    int len = strlen(caminho);

    for (int i = 0; i <= len; i++) {

        if (caminho[i] == '/' || caminho[i] == '\0') {

            temp[j] = '\0';

            if (strcmp(temp, "..") == 0) {
                pop(&p);
            }
            else if (strcmp(temp, ".") == 0 || strcmp(temp, "") == 0) {
                // ignora
            }
            else {
                push(&p, temp);
            }

            j = 0; // reset
        }
        else {
            temp[j++] = caminho[i];
        }
    }

    // Montar resultado final
    if (vazia(&p)) {
        strcpy(resultado, "/");
        return;
    }

    resultado[0] = '\0';

    for (int i = 0; i <= p.topo; i++) {
        strcat(resultado, "/");
        strcat(resultado, p.itens[i]);
    }
}

int main() {

    char caminho[200];
    char resultado[200];

    printf("Digite o caminho: ");
    scanf("%s", caminho);

    simplificar(caminho, resultado);

    printf("Caminho simplificado: %s\n", resultado);

    return 0;
}