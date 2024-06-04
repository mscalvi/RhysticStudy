#include <stdio.h>
#include <math.h>
#include <string.h>

int main (){
    int cont, voga, conso, carac;
    char string[100];

    cont = 1;

    while (cont == 1){
        conso = 0;
        voga = 0;
        carac = -1;

        printf ("Digite uma frase.\n");
        gets (string);

        for (int i = 0; i < strlen(string); i++){
            if (string[i] == 'a' || string[i] == 'e' || string[i] == 'i' || string[i] == 'o' || string[i] == 'u'){
                voga++;
            } else if (string[i] >= 'b' && string [i] <= 'z'){
                conso++;
            } else {
                carac++;
            }
        }

        printf ("Sua frase: %s\n", string);
        printf ("Total de vogais: %d\n", voga);
        printf ("Total de consoantes: %d\n", conso);
        printf ("Total de outros caracteres: %d\n", carac);

        printf ("\n");

        printf ("Digite 1 para continuar, 0 para sair.\n");
        scanf ("%d", &cont);
    }
}