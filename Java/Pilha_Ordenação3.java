import java.util.Scanner;
import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int N = sc.nextInt();
        sc.nextLine();

        TreeSet<String> alunos = new TreeSet<>();

        for (int i = 0; i < P; i++)
        {
            alunos.add(br.readLine());
        }

        for (int i = 0; i < P; i++)
        {
            System.out.print(alunos.get(i));
        }

        sc.close();
    }
}