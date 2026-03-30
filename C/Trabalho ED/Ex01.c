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
    } Pilha;

    void inicializar(Pilha* f) {
        f->inicio = NULL;
        f->fim = NULL;
        f->tamanho = 0;
    }

    int estaVazia(Pilha* f) {
        return f->inicio == NULL;
    }

    void adicionarEntrada(Pilha* f, char placa[]) {

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

    void requisitarSaida(Pilha* f, char placa[]) {

        if (estaVazia(f)) {
            printf("Pilha vazia.\n");
            return;
        }

        No* temp = f->inicio;
        int encontrou = 0;

        char pilha[100][7];
        int topo = -1;

        int realocados = 0;

        while (temp != NULL) {

            if (strcmp(temp->placa, placa) == 0) {
                encontrou = 1;
                break;
            }

            topo++;
            strcpy(pilha[topo], temp->placa);

            No* remover = f->inicio;
            f->inicio = remover->prox;

            free(remover);
            f->tamanho--;
            realocados++;

            temp = f->inicio;
        }

        if (!encontrou) {
            printf("Entrada nao encontrada.\n");

            for (int i = topo; i >= 0; i--) {
                adicionarEntrada(f, pilha[i]);
            }

            return;
        }

        No* remover = f->inicio;
        printf("Removendo: %s\n", remover->placa);

        f->inicio = remover->prox;

        if (f->inicio == NULL)
            f->fim = NULL;

        free(remover);
        f->tamanho--;

        for (int i = topo; i >= 0; i--) {
            adicionarEntrada(f, pilha[i]);
        }

        printf("Realocados: %d\n", realocados);
    }

    int quantidade(Pilha* f) {
        return f->tamanho;
    }

    int main() {

        Pilha fila;
        inicializar(&fila);

        int opcao;
        char placa[7];

        do {

            printf("\n1 - Registrar Entrada\n");
            printf("2 - Requisitar Saida\n");
            printf("3 - Contar Pilha\n");
            printf("0 - Sair\n");
            printf("Opcao: ");
            scanf("%d", &opcao);
            getchar();

            switch (opcao) {

            case 1:
                printf("Entrando. Placa: ");
                fgets(placa, 7, stdin);
                placa[strcspn(placa, "\n")] = 0;
                adicionarEntrada(&fila, placa);
                break;

            case 2:
                printf("Saida. Placa: ");
                fgets(placa, 7, stdin);
                placa[strcspn(placa, "\n")] = 0;
                requisitarSaida(&fila, placa);
                break;

            case 3:
                printf("%d entradas na Pilha\n", quantidade(&fila));
                break;

            default:
                break;
            }

        } while (opcao != 0);

        return 0;
    }