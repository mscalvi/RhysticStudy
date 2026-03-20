import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int N = sc.nextInt();
        sc.nextLine(); // consumir quebra de linha

        for (int i = 0; i < N; i++) {
            String linha = sc.nextLine();

            int abertos = 0;
            int diamantes = 0;

            for (char c : linha.toCharArray()) {
                if (c == '<') {
                    abertos++;
                } else if (c == '>') {
                    if (abertos > 0) {
                        diamantes++;
                        abertos--;
                    }
                }
                // '.' é ignorado automaticamente
            }

            System.out.println(diamantes);
        }

        sc.close();
    }
}