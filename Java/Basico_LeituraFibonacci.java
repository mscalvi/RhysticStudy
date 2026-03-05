import java.util.Scanner;

public class Basico_LeituraFibonacci {
    
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int a;
        int atual = 0, anterior = 0, soma = 0;

        System.out.print("Digite o total de termos: ");
        a = scanner.nextInt();

        if (a == 0) {
            System.out.println("Seria bom ter pelo menos um termo.");
        } else {
                System.out.println("Esses são os " + a + " primeiros termos de Fibonacci:");
            for (int i = 0; i < a; i++){
                if (i == 0){
                    System.out.print("0");
                    atual = 1;
                } else {
                    anterior = atual;

                    atual = soma;

                    soma = anterior + atual;
                    
                    System.out.print(" - " + soma);
                }
            }
        }

        scanner.close();
    }
}
