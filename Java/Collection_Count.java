import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws Exception {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        int N = Integer.parseInt(br.readLine());
        br.readLine();

        for (int t = 0; t < N; t++) {
            Map<String, Integer> contagem = new HashMap<>();
            int total = 0;

            String linha;

            while ((linha = br.readLine()) != null && !linha.isEmpty()) {
                contagem.put(linha, contagem.getOrDefault(linha, 0) + 1);
                total++;
            }

            List<String> especies = new ArrayList<>(contagem.keySet());
            Collections.sort(especies);

            for (String especie : especies) {
                double percentual = (contagem.get(especie) * 100.0) / total;
                System.out.printf("%s %.4f\n", especie, percentual);
            }

            if (t < N - 1) {
                System.out.println();
            }
        }
    }
}