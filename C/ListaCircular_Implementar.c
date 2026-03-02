#include <stdio.h>
#include <stdlib.h>

// Definição da estrutura do nó
typedef struct No {
    int dado;
    struct No* prox;
} No;

// Função para criar uma lista vazia
No* criarLista() {
    return NULL;
}

// Função para mostrar todos os elementos da lista
void mostrarLista(No* lista) {
    if (lista == NULL) {
        printf("Lista vazia.\n");
        return;
    }

    No* temp = lista;
    do {
        printf("%d -> ", temp->dado);
        temp = temp->prox;
    } while (temp != lista);
    printf("(volta ao inicio)\n");
}

// Função para adicionar um elemento no início da lista
No* inserirInicio(No* lista, int valor) {
    No* novoNo = (No*)malloc(sizeof(No));
    novoNo->dado = valor;

    if (lista == NULL) {
        novoNo->prox = novoNo;
        return novoNo;
    } else {
        // Encontrar o último nó
        No* temp = lista;
        while (temp->prox != lista) {
            temp = temp->prox;
        }
        novoNo->prox = lista;
        temp->prox = novoNo;
        return novoNo;
    }
}

// Função para inserir um elemento no final da lista
No* inserirFinal(No* lista, int valor) {
    No* novoNo = (No*)malloc(sizeof(No));
    novoNo->dado = valor;

    if (lista == NULL) {
        novoNo->prox = novoNo;
        return novoNo;
    } else {
        No* temp = lista;
        while (temp->prox != lista) {
            temp = temp->prox;
        }
        temp->prox = novoNo;
        novoNo->prox = lista;
        return lista;
    }
}

// Função para remover o elemento do início da lista
No* removerInicio(No* lista) {
    if (lista == NULL) {
        printf("A lista está vazia. Nada para remover.\n");
        return NULL;
    }

    if (lista->prox == lista) {
        // Apenas um elemento na lista
        free(lista);
        return NULL;
    }

    // Encontrar o último nó
    No* temp = lista;
    while (temp->prox != lista) {
        temp = temp->prox;
    }

    // Ajustar o ponteiro para remover o primeiro elemento
    No* remover = lista;
    temp->prox = lista->prox;
    lista = lista->prox;
    free(remover);

    return lista;
}

// Função para remover o elemento do final da lista
No* removerFinal(No* lista) {
    if (lista == NULL) {
        printf("A lista está vazia. Nada para remover.\n");
        return NULL;
    }

    // Apenas um elemento
    if (lista->prox == lista) {
        free(lista);
        return NULL;
    }

    No* atual = lista;
    No* anterior = NULL;

    // Encontrar o último nó
    while (atual->prox != lista) {
        anterior = atual;
        atual = atual->prox;
    }

    anterior->prox = lista;
    free(atual);

    return lista;
}

// Função para inverter a Lista
No* inverterLista(No* lista) {
    if (lista == NULL || lista->prox == lista) {
        return lista;
    }

    No* anterior = lista;
    No* atual = lista->prox;
    No* proximo;

    while (atual != lista) {
        proximo = atual->prox;
        atual->prox = anterior;
        anterior = atual;
        atual = proximo;
    }

    lista->prox = anterior;

    lista = anterior;

    return lista;
}

// Função para Ordenar a Lista
No* ordenarLista(No* lista) {
    if (lista == NULL || lista->prox == lista) {
        return lista;
    }

    int trocou;
    No* atual;
    No* fim = NULL;

    do {
        trocou = 0;
        atual = lista;

        do {
            if (atual->prox == lista)
                break;

            if (atual->dado > atual->prox->dado) {
                int temp = atual->dado;
                atual->dado = atual->prox->dado;
                atual->prox->dado = temp;
                trocou = 1;
            }

            atual = atual->prox;

        } while (atual->prox != fim && atual->prox != lista);

        fim = atual;

    } while (trocou);

    return lista;
}

// Função para Remover Duplicatas
No* removerDuplicados(No* lista) {
    if (lista == NULL || lista->prox == lista) {
        return lista;
    }

    No* atual = lista;

    do {
        No* anterior = atual;
        No* comparador = atual->prox;

        while (comparador != lista) {
            if (comparador->dado == atual->dado) {
                anterior->prox = comparador->prox;
                free(comparador);
                comparador = anterior->prox;
            } else {
                anterior = comparador;
                comparador = comparador->prox;
            }
        }

        atual = atual->prox;

    } while (atual != lista);

    return lista;
}

// Função para Remover Duplicatas Consecutivas
No* removerConsecDuplicados(No* lista) {
    if (lista == NULL || lista->prox == lista) {
        return lista;
    }

    No* atual = lista;

    do {
        while (atual->prox != lista && atual->dado == atual->prox->dado) {
            No* remover = atual->prox;
            atual->prox = remover->prox;
            free(remover);
        }

        atual = atual->prox;

    } while (atual != lista);

    return lista;
}

int main() {
    No* lista = criarLista();

    int novoElemento = 0;
    int opcao = 1;
    int helper = 0;

    // Menu de Entrada
    while (opcao != 0){
        helper = 0;

        printf ("Selecione a opcao:\n");
        printf ("1- Ver Lista atual\n");
        printf ("2- Adicionar Elemento no Inicio da Lista\n");
        printf ("3- Adicionar Elemento no Final da Lista\n");
        printf ("4- Remover o Elemento do Inicio da Lista\n");
        printf ("5- Remover o Elemento do Final da Lista\n");
        printf ("6- Inverter Lista\n");
        printf ("7- Ordenar Lista\n");
        printf ("8- Remover Elementos Duplicados\n");
        printf ("9- Remover Elementos Duplicados Consecutivos\n");
        printf ("0- Sair\n");
        scanf ("%d", &opcao);

        switch (opcao){
            case 1:
                mostrarLista(lista);
                while (helper != 1){
                    printf("Aperte 1 para continuar.\n");
                    scanf ("%d", &helper);
                    helper = 1;
                }
                break;
            case 2:
                // Adicionar Elemento no Inicio da Lista
                printf("Digite o valor do Elemento.\n");
                scanf("%d", &novoElemento);
                lista = inserirInicio(lista, novoElemento);
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 3:
                // Adicionar Elemento no Final da Lista
                printf("Digite o valor do Elemento.\n");
                scanf("%d", &novoElemento);
                lista = inserirFinal(lista, novoElemento); 
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 4:
                // Remover Elemento do Inicio da Lista
                lista = removerInicio(lista);
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 5:
                // Remover Elemento do Final da Lista
                lista = removerFinal(lista);
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 6:
                // Inverter a Lista
                lista = inverterLista(lista);
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 7:
                // Ordenar a Lista
                lista = ordenarLista(lista);
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 8:
                // Remover Elementos Duplicados 
                lista = removerDuplicados(lista);
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 9:
                // Remover Elementos Duplicados Consecutivos
                lista = removerConsecDuplicados(lista);
                printf("Nova lista:\n");
                mostrarLista(lista);
                break;
            case 0:
                // Encerrar programa
                printf ("\nEncerrando.\n");
                break;
            default:
                printf ("\nOpcao Invalida.\n");
                break;
        }
    }

    return 0;
}
