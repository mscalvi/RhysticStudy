import java.util.Scanner;

public class Vetor_Ordenacao {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        System.out.print("Quantos numeros deseja inserir? ");
        int n = scanner.nextInt();

        int fase = 0;

        int[] vetor = new int[n];

        // Leitura dos valores
        for (int i = 0; i < n; i++) {
            System.out.print("Digite o numero " + (i + 1) + ": ");
            vetor[i] = scanner.nextInt();
        }

        // Mostra o vetor original
        System.out.println("\nVetor original:");
        for (int i = 0; i < n; i++) {
            System.out.print(vetor[i] + " ");
        }

        // Ordenação (Bubble Sort)
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - 1 - i; j++) {

                fase++;
                System.out.println("\n\nFase " + fase + " de Ordenacao:");

                if (vetor[j] > vetor[j + 1]) {
                    System.out.println("  ->Alteracao entre: " + vetor[j] + " e " + vetor[j+1]);
                    int temp = vetor[j];
                    vetor[j] = vetor[j + 1];
                    vetor[j + 1] = temp;
                } else {                    
                    System.out.println("  -> Nenhuma alteração.");
                }
                
                System.out.print("  -> ");
                for (int k = 0; k < n; k++) {
                    System.out.print(vetor[k] + " ");
                }
            }
        }

        // Impressão do vetor ordenado
        System.out.println("\n\nVetor ordenado:");
        for (int i = 0; i < n; i++) {
            System.out.print(vetor[i] + " ");
        }

        scanner.close();
    }
}