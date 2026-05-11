import java.io.*;
import java.net.*;

public class Cliente {
    public static void main(String[] args) {
        try {
            // IP do Servidor
            String servidor = "127.0.0.1";

            // Porta do Servidor
            int porta = 12345;

            Socket socket = new Socket(servidor, porta);

            System.out.println("Conectado!");

            // Mensagem de Entrada
            PrintWriter saida = new PrintWriter(socket.getOutputStream(), true);
            saida.println("Conexão - Marcelo Scalvi");

            // Receber Resposta
            BufferedReader entrada =
                    new BufferedReader(
                            new InputStreamReader(socket.getInputStream()));

            String resposta = entrada.readLine();

            System.out.println("Servidor: " + resposta);

            socket.close();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}