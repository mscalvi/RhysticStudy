    #include <stdio.h>
    #include <stdlib.h>
    #include <string.h>

    #define MAX 100

    typedef struct {
        int topo;
        int itens[MAX];
    } PilhaInt;

    typedef struct {
        int topo;
        char itens[MAX];
    } PilhaChar;

    void initInt(PilhaInt* p) { p->topo = -1; }
    void initChar(PilhaChar* p) { p->topo = -1; }

    int vaziaInt(PilhaInt* p) { return p->topo == -1; }
    int vaziaChar(PilhaChar* p) { return p->topo == -1; }

    void pushInt(PilhaInt* p, int v) { p->itens[++p->topo] = v; }
    int popInt(PilhaInt* p) { return p->itens[p->topo--]; }

    void pushChar(PilhaChar* p, char c) { p->itens[++p->topo] = c; }
    char popChar(PilhaChar* p) { return p->itens[p->topo--]; }

    char topoChar(PilhaChar* p) { return p->itens[p->topo]; }
        
    int balanceada(char* expr) {
        PilhaChar p;
        initChar(&p);

        for (int i = 0; expr[i]; i++) {
            if (expr[i] == '(') {
                pushChar(&p, '(');
            }
            else if (expr[i] == ')') {
                if (vaziaChar(&p)) return 0;
                popChar(&p);
            }
        }

        return vaziaChar(&p);
    }

    int prioridade(char op) {
        if (op == '+' || op == '-') return 1;
        if (op == '*' || op == '/') return 2;
        return 0;
    }

    void infixaParaPosfixa(char* infixa, char* posfixa) {
        PilhaChar p;
        initChar(&p);

        int j = 0;

        for (int i = 0; infixa[i]; i++) {

            char c = infixa[i];

            // número
            if (c >= '0' && c <= '9') {
                posfixa[j++] = c;
            }

            else if (c == '(') {
                pushChar(&p, c);
            }

            else if (c == ')') {
                while (!vaziaChar(&p) && topoChar(&p) != '(') {
                    posfixa[j++] = popChar(&p);
                }
                popChar(&p); // remove '('
            }

            else { // operador
                while (!vaziaChar(&p) &&
                    prioridade(topoChar(&p)) >= prioridade(c)) {
                    posfixa[j++] = popChar(&p);
                }
                pushChar(&p, c);
            }
        }

        while (!vaziaChar(&p)) {
            posfixa[j++] = popChar(&p);
        }

        posfixa[j] = '\0';
    }

    int aplicar(int a, int b, char op) {
        switch (op) {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/': return a / b;
        }
        return 0;
    }

    int avaliarPosfixa(char* expr) {
        PilhaInt p;
        initInt(&p);

        for (int i = 0; expr[i]; i++) {

            char c = expr[i];

            if (c >= '0' && c <= '9') {
                pushInt(&p, c - '0');
            } else {
                int b = popInt(&p);
                int a = popInt(&p);
                pushInt(&p, aplicar(a, b, c));
            }
        }

        return popInt(&p);
    }

    int main() {

        char infixa[100];
        char posfixa[100];

        printf("Digite a expressao: ");
        scanf("%s", infixa);

        if (!balanceada(infixa)) {
            printf("Expressao invalida (parenteses)\n");
            return 0;
        }

        infixaParaPosfixa(infixa, posfixa);

        printf("Posfixa: %s\n", posfixa);

        int resultado = avaliarPosfixa(posfixa);

        printf("Resultado: %d\n", resultado);

        return 0;
    }