import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Listener_Calc extends JFrame implements ActionListener {
    private JTextField campo1, campo2;
    private JButton bSoma, bSub, bMult, bDiv;
    private JLabel labelResultado;

    public Listener_Calc() {
        super("Calculadora");
        setLayout(new FlowLayout());

        campo1 = new JTextField(5);
        campo2 = new JTextField(5);
        
        labelResultado = new JLabel("0"); 
        
        bSoma = new JButton("Soma");
        bSub = new JButton("Subtrai");
        bMult = new JButton("Multiplica");
        bDiv = new JButton("Divide");

        bSoma.addActionListener(this);
        bSub.addActionListener(this);
        bMult.addActionListener(this);
        bDiv.addActionListener(this);

        add(campo1);
        add(bSoma); add(bSub); add(bMult); add(bDiv);
        add(campo2);
        add(new JLabel("="));
        add(labelResultado);

        pack();
        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        try {
            double n1 = Double.parseDouble(campo1.getText());
            double n2 = Double.parseDouble(campo2.getText());
            double res = 0;

            if (e.getSource() == bSoma) res = n1 + n2;
            else if (e.getSource() == bSub) res = n1 - n2;
            else if (e.getSource() == bMult) res = n1 * n2;
            else if (e.getSource() == bDiv) {
                if (n2 != 0) res = n1 / n2;
                else {
                    JOptionPane.showMessageDialog(this, "Impossibru!");
                    return;
                }
            }

            labelResultado.setText(String.valueOf(res));

        } catch (NumberFormatException ex) {
            JOptionPane.showMessageDialog(this, "Por favor, prestenção.");
        }
    }

    public static void main(String[] args) {
        new Listener_Calc();
    }
}