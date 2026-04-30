import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Listener_Jogo extends JPanel implements KeyListener {

    int x = 50, y = 50;

    public Listener_Jogo() {
        setFocusable(true);
        addKeyListener(this);

        Timer timer = new Timer(16, e -> repaint()); 
        timer.start();
    }

    protected void paintComponent(Graphics g) {
        super.paintComponent(g);

        g.setColor(Color.BLUE);
        g.fillRect(x, y, 50, 50);
    }

    public void keyPressed(KeyEvent e) {
        int tecla = e.getKeyCode();

        if (tecla == KeyEvent.VK_LEFT || tecla == KeyEvent.VK_A) x -= 10;
        if (tecla == KeyEvent.VK_RIGHT || tecla == KeyEvent.VK_D) x += 10;
        if (tecla == KeyEvent.VK_UP || tecla == KeyEvent.VK_W) y -= 10;
        if (tecla == KeyEvent.VK_DOWN || tecla == KeyEvent.VK_S) y += 10;
    }

    public void keyReleased(KeyEvent e) {}
    public void keyTyped(KeyEvent e) {}

    public static void main(String[] args) {
        JFrame frame = new JFrame("Jogo");
        Listener_Jogo jogo = new Listener_Jogo();

        frame.add(jogo);
        frame.setSize(400, 400);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
    }
}