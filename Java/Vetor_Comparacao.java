// Não enviei pelo CodeForces, nunca usei lá e pra ser honesto deu preguiça :D
// Mas tirei dúvida, com você, se era só isso mesmo

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = sc.nextInt();
        int[] a = new int[n];

        for (int i = 0; i < n; i++) {
            a[i] = sc.nextInt();
        }

        Arrays.sort(a);

        int total = 0;

        for (int i = 0; i < n; i += 2) {
            total += a[i + 1] - a[i];
        }

        System.out.println(total);

        sc.close();
    }
}