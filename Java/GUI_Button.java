import java.awt.*;
import javax.swing.*;

public class GUI_Button extends Frame {
    Button b1 = new Button("Abrir");
    Button b2 = new Button("Salvar");
    Button b3 = new Button("Salvar Como");
    Button b4 = new Button("Fechar");
    JTextArea textArea;

    GUI_Button() {
        super("Botao");
        setLayout(new GridLayout(4,1));
        add(b1);
        add(b2);
        add(b3);
        add(b4);
        pack();
        add(textArea = new JTextArea (4,20), BorderLayout.CENTER);
        pack();
        setVisible(true);
    }

    static public void main(String[] args) {
        new GUI_Button();
    }
}