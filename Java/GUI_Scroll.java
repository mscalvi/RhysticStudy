import java.awt.*;
import javax.swing.*;

class Exerc2 extendes JFrame{
    JButton bAbrir = new JButton("Abrir");
    JButton bSalvar = new JButton("Salvar");
    JButton bSComo = new JButton("Salvar Como");
    JButton bFecha = new JButton("Fechar");

    JTextArea texto = new JTextArea(10,40);

    Exerc2(){
        super("Editor de Texto");
        JPanel p = new JPanel(new GridLayout(1,4));
        p.add(bAbrir);
        p.add(pSalvar);
        p.add(pSComo);
        p.add(pFecha);
        add(p, BorderLayout.NORTH);
        JScrollPanel rolagem = new JScrollPane(texto);
        add(rolagem, BorderLayout.CENTER);
        pach();
        setVisible(true);
    }
}
public static void main (string s[]){
    new Exerc2();
}