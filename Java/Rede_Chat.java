import java.io.*;
import java.net.*;
import java.util.Scanner;

public class Rede_Chat {

    public static void main(String[] args) {
        try {
            // IP do Servidor
            String servidor = "186.217.118.205";

            // Porta do Servidor
            int porta = 1234;

            // Conecta
            Socket socket = new Socket(servidor, porta);

            // Entrada e Saída
            BufferedReader entrada = new BufferedReader(
                    new InputStreamReader(socket.getInputStream()));

            PrintWriter saida = new PrintWriter(
                    socket.getOutputStream(), true);

            Scanner sc = new Scanner(System.in);

            // Thread para receber mensagens
            Thread receber = new Thread(() -> {
                try {
                    String msg;

                    while ((msg = entrada.readLine()) != null) {
                        System.out.println("Servidor: " + msg);
                    }

                } catch (Exception e) {
                    System.out.println("Desconectado.");
                }
            });

            receber.start();

            // Enviar mensagens
            while (true) {
                String mensagem = sc.nextLine();
                saida.println(mensagem);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}