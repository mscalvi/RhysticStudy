import java.util.Scanner;
import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int N = sc.nextInt();
        sc.nextLine();

        Set<String> alunos = new HashSet<>();

        for (int i = 0; i < P; i++)
        {
            alunos.add(br.readLine());
        }

        Collections.sort(alunos);

        for (int i = 0; i < P; i++)
        {
            System.out.print(alunos.get(i));
        }

        sc.close();
    }
}