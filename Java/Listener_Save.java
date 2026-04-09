import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*; 
import java.util.Scanner;

public class Listener_Save extends JFrame implements ActionListener {
    private JTextArea areaTexto;
    private JButton bAbrir, bSalvar, bSComo, bFechar;

    public Listener_Save() {
        super("Editor de Texto");
        
        areaTexto = new JTextArea(10, 40);
        bAbrir = new JButton("Abrir");
        bSalvar = new JButton("Salvar");
        bSComo = new JButton("Salvar Como");
        bFechar = new JButton("Fechar");

        bAbrir.addActionListener(this);
        bSalvar.addActionListener(this);
        bSComo.addActionListener(this);
        bFechar.addActionListener(this);

        JPanel painelBotoes = new JPanel(new GridLayout(4, 1));
        painelBotoes.add(bAbrir); painelBotoes.add(bSalvar);
        painelBotoes.add(bSComo); painelBotoes.add(bFechar);

        add(painelBotoes, BorderLayout.WEST);
        add(new JScrollPane(areaTexto), BorderLayout.CENTER);

        pack();
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == bFechar) {
            System.exit(0);
        } 
        else if (e.getSource() == bAbrir) {
            abrir();
        } 
        else if (e.getSource() == bSalvar || e.getSource() == bSComo) {
            salvar();
        }
    }

    private void abrir() {
        String nomeArq = JOptionPane.showInputDialog("Nome do arquivo para abrir:");
        if (nomeArq == null || nomeArq.isEmpty()) return;

        try {
            StringBuffer txt = new StringBuffer();
            FileInputStream in = new FileInputStream(nomeArq);
            Scanner sin = new Scanner(in); // [cite: 8]

            while (sin.hasNextLine()) {
                txt.append(sin.nextLine());
                txt.append("\n"); 
            }
            in.close();
            
            areaTexto.setText(txt.toString());
        } catch (FileNotFoundException ex) {
            JOptionPane.showMessageDialog(this, "Arquivo não encontrado!");
        } catch (IOException ex) {
            JOptionPane.showMessageDialog(this, "Erro na leitura do arquivo.");
        }
    }

    private void salvar() {
        String nomeArq = JOptionPane.showInputDialog("Nome do arquivo para salvar:");
        if (nomeArq == null || nomeArq.isEmpty()) return;

        try {
            String txt = areaTexto.getText(); 
            FileOutputStream out = new FileOutputStream(nomeArq);
            out.write(txt.getBytes());
            out.close();
            
            JOptionPane.showMessageDialog(this, "Arquivo salvo!");
        } catch (IOException ex) {
            JOptionPane.showMessageDialog(this, "Erro ao salvar arquivo.");
        }
    }

    public static void main(String[] args) {
        new Listener_Save();
    }
}