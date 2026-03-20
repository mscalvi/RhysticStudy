#include <stdio.h>
#include <stdlib.h>

typedef struct Node {
    int value;
    struct Node *next;
} Node;

typedef struct {
    Node *front;
    Node *rear;
} Queue;

void initQueue(Queue *q) {
    q->front = NULL;
    q->rear = NULL;
}

void enqueue(Queue *q, int value) {
    Node *newNode = (Node*) malloc(sizeof(Node));
    newNode->value = value;
    newNode->next = NULL;

    if (q->rear == NULL) {
        q->front = newNode;
        q->rear = newNode;
    } else {
        q->rear->next = newNode;
        q->rear = newNode;
    }
}

int dequeue(Queue *q) {
    if (q->front == NULL) {
        printf("Fila vazia\n");
        return -1;
    }

    Node *temp = q->front;
    int value = temp->value;

    q->front = temp->next;

    if (q->front == NULL)
        q->rear = NULL;

    free(temp);
    return value;
}

void printQueue(Queue *q) {
    Node *current = q->front;

    while (current != NULL) {
        printf("%d ", current->value);
        current = current->next;
    }

    printf("\n");
}

void duplicateNegatives(Queue *q) {
    Node *current = q->front;

    while (current != NULL) {
        if (current->value < 0) {

            Node *newNode = (Node*) malloc(sizeof(Node));
            newNode->value = current->value;

            newNode->next = current->next;
            current->next = newNode;

            if (current == q->rear)
                q->rear = newNode;

            current = newNode->next;
        } else {
            current = current->next;
        }
    }
}

int main() {

    Queue q;
    initQueue(&q);

    int value;

    printf("Digite numeros para inserir na fila.\n");
    printf("Digite qualquer letra para parar.\n");

    while (scanf("%d", &value) == 1) {
        enqueue(&q, value);
    }

    printf("\nFila original:\n");
    printQueue(&q);

    duplicateNegatives(&q);

    printf("\nFila apos duplicar negativos:\n");
    printQueue(&q);

    return 0;
}

