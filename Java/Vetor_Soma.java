import java.util.Scanner;

public class Vetor_Soma {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        System.out.print("Digite o numero de linhas: ");
        int linhas = scanner.nextInt();

        System.out.print("Digite o numero de colunas: ");
        int colunas = scanner.nextInt();

        int[][] matriz1 = new int[linhas][colunas];
        int[][] matriz2 = new int[linhas][colunas];
        int[][] soma = new int[linhas][colunas];

        System.out.println("Digite os valores da primeira matriz:");

        for (int i = 0; i < linhas; i++) {
            for (int j = 0; j < colunas; j++) {
                System.out.print("[" + (i+1) + "][" + (j+1) + "]: ");
                matriz1[i][j] = scanner.nextInt();
            }
        }

        System.out.println("Digite os valores da segunda matriz:");

        for (int i = 0; i < linhas; i++) {
            for (int j = 0; j < colunas; j++) {
                System.out.print("[" + (i+1) + "][" + (j+1) + "]: ");
                matriz2[i][j] = scanner.nextInt();
            }
        }

        // Soma das matrizes
        for (int i = 0; i < linhas; i++) {
            for (int j = 0; j < colunas; j++) {
                soma[i][j] = matriz1[i][j] + matriz2[i][j];
            }
        }

        // Impressão da matriz resultante
        System.out.println("Matriz soma:");

        for (int i = 0; i < linhas; i++) {
            for (int j = 0; j < colunas; j++) {
                System.out.print(soma[i][j] + " ");
            }
            System.out.println();
        }

        scanner.close();
    }
}