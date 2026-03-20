import java.util.Scanner;

public class Main {

    public static void Sorter(String[] array) {
        for (int i = 1; i < array.length; i++) {
            String atual = array[i];
            int j = i - 1;

            while (j >= 0 && array[j].length() < atual.length()) {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = atual;
        }
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int N = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < N; i++) {
            String linha = sc.nextLine();

            String[] palavras = linha.split(" ");

            Sorter(palavras);

            for (int j = 0; j < palavras.length; j++) {
                System.out.print(palavras[j]);
                if (j < palavras.length - 1) {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        sc.close();
    }
}