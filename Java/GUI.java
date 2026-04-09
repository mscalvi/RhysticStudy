import java.awt.*;
import java.awt.event.*;

public class GUI extends Frame {
    Button b1 = new Button("Abrir");
    Button b2 = new Button("Salvar");
    Button b3 = new Button("Salvar Como");
    Button b4 = new Button("Fechar");
    TextArea textArea;

    GUI() {
        super("Editor de Texto");

        setLayout(new BorderLayout());

        Panel painelBotoes = new Panel();
        painelBotoes.setLayout(new GridLayout(4, 1));

        painelBotoes.add(b1);
        painelBotoes.add(b2);
        painelBotoes.add(b3);
        painelBotoes.add(b4);

        add(painelBotoes, BorderLayout.WEST);

        textArea = new TextArea(10, 30);
        add(textArea, BorderLayout.CENTER);

        b4.addActionListener(e -> System.exit(0));

        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        });

        pack();
        setVisible(true);
    }

    public static void main(String[] args) {
        new GUI();
    }
}