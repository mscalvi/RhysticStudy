import java.awt.*;
import java.awt.event.*;

public class GUI_Combo2 extends Frame {
    TextField campo1;
    TextField campo2;
    Choice operacoes;
    Label resultado;
    Button calcular;

    GUI_Combo2() {
        super("Calculadora");

        setLayout(new BorderLayout());

        // Painel central
        Panel centro = new Panel();
        centro.setLayout(new FlowLayout());

        campo1 = new TextField(10);
        campo2 = new TextField(10);

        operacoes = new Choice();
        operacoes.add("+");
        operacoes.add("-");
        operacoes.add("*");
        operacoes.add("/");

        centro.add(campo1);
        centro.add(operacoes);
        centro.add(campo2);

        add(centro, BorderLayout.CENTER);

        // Resultado à direita
        resultado = new Label("Resultado: ");
        add(resultado, BorderLayout.EAST);

        // Botão embaixo ocupando tudo
        calcular = new Button("Calcular");
        Panel painelBotao = new Panel();
        painelBotao.add(calcular);
        add(painelBotao, BorderLayout.SOUTH);

        // Evento do botão
        calcular.addActionListener(e -> calcular());

        // Fechar janela
        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        });

        setSize(400, 150);
        setVisible(true);
    }

    void calcular() {
        try {
            double a = Double.parseDouble(campo1.getText().trim());
            double b = Double.parseDouble(campo2.getText().trim());
            String op = operacoes.getSelectedItem();

            double res = 0;

            switch (op) {
                case "+":
                    res = a + b;
                    break;
                case "-":
                    res = a - b;
                    break;
                case "*":
                    res = a * b;
                    break;
                case "/":
                    if (b == 0) {
                        resultado.setText("Erro: /0");
                        return;
                    }
                    res = a / b;
                    break;
            }

            resultado.setText("Resultado: " + res);

        } catch (Exception e) {
            resultado.setText("Erro");
        }
    }

    public static void main(String[] args) {
        new GUI_Combo2();
    }
}