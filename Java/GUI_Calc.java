import java.awt.*;
import java.awt.event.*;

public class GUI_Calc extends Frame {
    Button b1 = new Button("Soma");
    Button b2 = new Button("Subtrai");
    Button b3 = new Button("Multiplica");
    Button b4 = new Button("Divide");

    TextArea textArea1;
    TextArea textArea2;
    Label resposta;

    GUI_Calc() {
        super("Calculadora");

        setLayout(new BorderLayout());

        // Campo 1
        textArea1 = new TextArea(1, 10);
        add(textArea1, BorderLayout.WEST);

        // Botões
        Panel painelBotoes = new Panel();
        painelBotoes.setLayout(new GridLayout(4, 1));
        painelBotoes.add(b1);
        painelBotoes.add(b2);
        painelBotoes.add(b3);
        painelBotoes.add(b4);
        add(painelBotoes, BorderLayout.CENTER);

        // Campo 2
        textArea2 = new TextArea(1, 10);
        add(textArea2, BorderLayout.EAST);

        // Resultado
        resposta = new Label("Resultado: ");
        add(resposta, BorderLayout.SOUTH);

        // Eventos dos botões
        b1.addActionListener(e -> calcular("+"));
        b2.addActionListener(e -> calcular("-"));
        b3.addActionListener(e -> calcular("*"));
        b4.addActionListener(e -> calcular("/"));

        // Fechar janela
        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        });

        pack();
        setVisible(true);
    }

    // Método de cálculo
    void calcular(String operacao) {
        try {
            double a = Double.parseDouble(textArea1.getText().trim());
            double b = Double.parseDouble(textArea2.getText().trim());
            double resultado = 0;

            switch (operacao) {
                case "+":
                    resultado = a + b;
                    break;
                case "-":
                    resultado = a - b;
                    break;
                case "*":
                    resultado = a * b;
                    break;
                case "/":
                    if (b == 0) {
                        resposta.setText("Erro: divisão por zero");
                        return;
                    }
                    resultado = a / b;
                    break;
            }

            resposta.setText("Resultado: " + resultado);

        } catch (Exception e) {
            resposta.setText("Erro: entrada inválida");
        }
    }

    public static void main(String[] args) {
        new GUI_Calc();
    }
}