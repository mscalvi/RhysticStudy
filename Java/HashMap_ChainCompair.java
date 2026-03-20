import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws Exception {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        while (true) {
            String[] linha = br.readLine().split(" ");
            int P = Integer.parseInt(linha[0]);
            int A = Integer.parseInt(linha[1]);
            int R = Integer.parseInt(linha[2]);

            if (P == 0 && A == 0 && R == 0) break;

            // Pérolas
            Set<String> perolas = new HashSet<>();
            for (int i = 0; i < P; i++) {
                perolas.add(br.readLine());
            }

            // Contagem
            Map<String, Integer> contagem = new HashMap<>();

            for (int i = 0; i < A; i++) {
                String nome = br.readLine();
                int count = 0;

                for (int j = 0; j < R; j++) {
                    String resposta = br.readLine();
                    if (perolas.contains(resposta)) {
                        count++;
                    }
                }

                contagem.put(nome, count);
            }

            // Encontrar máximo manualmente (evita erro)
            int max = 0;
            for (int v : contagem.values()) {
                if (v > max) max = v;
            }

            // Filtrar melhores
            List<String> melhores = new ArrayList<>();
            for (String nome : contagem.keySet()) {
                if (contagem.get(nome) == max) {
                    melhores.add(nome);
                }
            }

            // Ordenar manualmente (Insertion Sort)
            for (int i = 1; i < melhores.size(); i++) {
                String atual = melhores.get(i);
                int j = i - 1;

                while (j >= 0 && melhores.get(j).compareTo(atual) > 0) {
                    melhores.set(j + 1, melhores.get(j));
                    j--;
                }

                melhores.set(j + 1, atual);
            }

            // Imprimir
            for (int i = 0; i < melhores.size(); i++) {
                System.out.print(melhores.get(i));
                if (i < melhores.size() - 1) {
                    System.out.print(", ");
                }
            }
            System.out.println();
        }
    }
}