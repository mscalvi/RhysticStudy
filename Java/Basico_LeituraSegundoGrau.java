import java.util.Scanner;

public class Basico_LeituraSegundoGrau {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double a, b, c;
        double delta, x1, x2;

        System.out.print("Digite o valor de a: ");
        a = scanner.nextDouble();

        System.out.print("Digite o valor de b: ");
        b = scanner.nextDouble();

        System.out.print("Digite o valor de c: ");
        c = scanner.nextDouble();

        if (a == 0) {
            System.out.println("Nao é uma equacao de segundo grau.");
        } else {
            delta = (b * b) - (4 * a * c);

            if (delta < 0) {
                System.out.println("A equacao nao possui raizes reais.");
            } else if (delta == 0) {
                x1 = -b / (2 * a);
                System.out.println("A equacao possui uma raiz real:");
                System.out.println("x = " + x1);
            } else {
                x1 = (-b + Math.sqrt(delta)) / (2 * a);
                x2 = (-b - Math.sqrt(delta)) / (2 * a);

                System.out.println("A equacao possui duas raizes reais:");
                System.out.println("x1 = " + x1);
                System.out.println("x2 = " + x2);
            }
        }

        scanner.close();
    }
}