import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int N = sc.nextInt();

        for (int i = 0; i < N; i++) {
            int M = sc.nextInt();

            Map<String, Double> precos = new HashMap<>();

            for (int j = 0; j < M; j++) {
                String nome = sc.next();
                double preco = sc.nextDouble();
                precos.put(nome, preco);
            }

            int P = sc.nextInt();

            double total = 0.0;

            for (int j = 0; j < P; j++) {
                String nome = sc.next();
                int quantidade = sc.nextInt();

                double preco = precos.get(nome);
                total += preco * quantidade;
            }

            System.out.printf("R$ %.2f\n", total);
        }

        sc.close();
    }
}