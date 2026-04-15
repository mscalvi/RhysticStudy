// Aplicação Standalone sem Janela
class HelloWorld {
    public static void main(String[] args) {
        System.out.println("Hello World!");
    }
}

// Aplicação Standalone com Janela
import java.awt.*;
import javax.swing.*;
class HelloWorld extends JFrame {
    public void paint(Graphics g) {
        super.paint(g);
        g.drawString("Hello world!", 40, 100);
    }    
    public static void main(String args[]) {
        HelloWorld hello=new HelloWorld();
        hello.setSize(155, 150);
        hello.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        hello.setVisible(true);
    }
}

// Exceções
class ExemploException {
    static void GeraException() {
        try {
            int i = 0;
            int j = 1 / i;
        } 
        catch (ArithmeticException e) {
            System.out.println("Erro aritmetico:\n " + e);
        }
    }
    public static void main(String args[]) {
        GeraException();
        System.out.println("Vai funcionar.");
    }
}

// Arquivos e Exceções
import java.io.*;
class Main {
    public static void main(String[] args){
        File file = new File(args[0]);
        try {
            FileInputStream in = new FileInputStream(file);
            int c; 
            while ((c = in.read())>-1){
            if (!Character.isSpace((char) c))
                System.out.print((char) c);
            }
            in.close();
            System.out.flush();
        } 
        catch (FileNotFoundException e) {
            System.err.println(file+" is not found");
        } 
        catch (IOException e) {
            e.printStackTrace();
        }
        finally {
            System.out.println("Vai funcionar sempre.");
        }
    }
}

// Lista Dinâmica
import java.util.*;
public class ExemploArrayList {
    public static void main(String[] args) {
        ArrayList<String> lista = new ArrayList<>();
        lista.add("Maçã");
        lista.add("Banana");
        lista.add("Uva");
        for (String fruta : lista) {
            System.out.println(fruta);
        }
    }
}

// Hash Set
import java.util.*;
public class ExemploSet {
    public static void main(String[] args) {
        HashSet<Integer> numeros = new HashSet<>();
        numeros.add(10);
        numeros.add(20);
        numeros.add(10); // Repetido não irá aparecer
        System.out.println(numeros);
    }
}

// Hash Map (Dictionary)
import java.util.*;
public class ExemploMap {
    public static void main(String[] args) {
        HashMap<String, Integer> idades = new HashMap<>();
        idades.put("Ana", 20);
        idades.put("João", 25);
        System.out.println("Ana: " + idades.get("Ana"));
    }
}

// Linked List
import java.util.*;
public class ExemploLinkedList {
    public static void main(String[] args) {
        LinkedList<String> lista = new LinkedList<>();
        lista.add("A");
        lista.add("B");
        lista.addFirst("Início");
        System.out.println(lista);
    }
}

// Lista Ordenada
import java.util.*;
public class ExemploSort {
    public static void main(String[] args) {
        ArrayList<Integer> nums = new ArrayList<>();
        nums.add(5);
        nums.add(1);
        nums.add(3);
        Collections.sort(nums);
        System.out.println(nums);
    }
}

// Fila
import java.util.*;
public class ExemploQueue {
    public static void main(String[] args) {
        Queue<Integer> fila = new LinkedList<>();
        fila.add(10);
        fila.add(20);
        fila.add(30);
        while (!fila.isEmpty()) {
            System.out.println(fila.poll());
        }
    }
}

// TreeSet
import java.util.*;
public class ExemploTreeSet {
    public static void main(String[] args) {
        Set<String> nomes = new TreeSet<>();
        nomes.add("Pedro");
        nomes.add("Ana");
        nomes.add("Carlos");
        System.out.println(nomes);
    }
}

// Iterator -> Permite percorrer manualmente e remover elementos
import java.util.*;
public class ExemploIterator {
    public static void main(String[] args) {
        List<String> lista = new ArrayList<>();
        lista.add("A");
        lista.add("B");
        Iterator<String> it = lista.iterator();
        while (it.hasNext()) {
            String valor = it.next();
            System.out.println(valor);
            if (valor.equals("A")) {
                it.remove();
            }
        }
    }
}

// Generics obrigam todos os elementos a serem do mesmo tipo, mas NÃO aceitam tipos primitivos (usar Integer, Double, etc.)
import java.util.*;
public class ExemploGenerics {
    public static void main(String[] args) {
        List<Integer> lista = new ArrayList<>();
        lista.add(10);
        lista.add(20);
        int x = lista.get(0);
        System.out.println(x);
    }
}

// GUI -> Botões, Área de Texto com Scroll
import javax.swing.*;
import java.awt.*;
public class GUI1 extends JFrame {
    public GUI1() {
        super("Editor");
        setLayout(new BorderLayout());
        // Painel de botões
        JPanel topo = new JPanel(new GridLayout(1, 4));
        topo.add(new JButton("Abrir"));
        topo.add(new JButton("Salvar"));
        topo.add(new JButton("Salvar Como"));
        topo.add(new JButton("Fechar"));
        add(topo, BorderLayout.NORTH);
        // Área de texto com scroll
        JTextArea texto = new JTextArea(10, 30);
        JScrollPane scroll = new JScrollPane(texto);
        add(scroll, BorderLayout.CENTER);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        pack();
        setVisible(true);
    }
    public static void main(String[] args) {
        new GUI1();
    }
}

// GUI -> Eventos, Botão
import javax.swing.*;
import java.awt.*;
public class GUI2 extends JFrame {
    JTextField campo1 = new JTextField(5);
    JTextField campo2 = new JTextField(5);
    JLabel resultado = new JLabel("Resultado:");
    public GUI2() {
        setLayout(new FlowLayout());
        JButton botao = new JButton("Somar");
        add(campo1);
        add(new JLabel("+"));
        add(campo2);
        add(botao);
        add(resultado);
        // Evento
        botao.addActionListener(e -> {
            try {
                int a = Integer.parseInt(campo1.getText());
                int b = Integer.parseInt(campo2.getText());
                resultado.setText("Resultado: " + (a + b));
            } catch (Exception ex) {
                resultado.setText("Erro");
            }
        });
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        pack();
        setVisible(true);
    }
    public static void main(String[] args) {
        new GUI2();
    }
}

// GUI -> Layout, Botão em Espaço, Panel
import javax.swing.*;
import java.awt.*;
public class GUI3 extends JFrame {
    public GUI3() {
        setLayout(new BorderLayout());
        JTextField campo1 = new JTextField();
        JTextField campo2 = new JTextField();
        add(campo1, BorderLayout.WEST);
        add(campo2, BorderLayout.EAST);
        JButton calcular = new JButton("Calcular");
        // Painel para controlar tamanho
        JPanel painel = new JPanel();
        painel.add(calcular);
        add(painel, BorderLayout.SOUTH);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(300, 150);
        setVisible(true);
    }
    public static void main(String[] args) {
        new GUI3();
    }
}

// Listener
import javax.swing.*;
import java.awt.*;

public class Exemplo1 extends JFrame {

    public Exemplo1() {
        setLayout(new FlowLayout());

        JButton botao = new JButton("Clique");

        botao.addActionListener(e -> {
            System.out.println("Botão clicado!");
        });

        add(botao);

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(200, 100);
        setVisible(true);
    }

    public static void main(String[] args) {
        new Exemplo1();
    }
}

// Mouse Listener
import javax.swing.*;
import java.awt.event.*;

public class Exemplo2 extends JFrame {

    public Exemplo2() {
        JButton botao = new JButton("Clique com mouse");

        botao.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent e) {
                System.out.println("Mouse clicou!");
            }
        });

        add(botao);

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(300, 100);
        setVisible(true);
    }

    public static void main(String[] args) {
        new Exemplo2();
    }
}

// Listener -> getSource
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
public class Exemplo3 extends JFrame {
    JButton b1 = new JButton("A");
    JButton b2 = new JButton("B");
    public Exemplo3() {
        setLayout(new FlowLayout());
        MeuListener listener = new MeuListener();
        b1.addActionListener(listener);
        b2.addActionListener(listener);
        add(b1);
        add(b2);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(200, 100);
        setVisible(true);
    }
    class MeuListener implements ActionListener {
        public void actionPerformed(ActionEvent e) {
            JButton origem = (JButton) e.getSource();
            System.out.println("Clicou: " + origem.getText());
        }
    }
    public static void main(String[] args) {
        new Exemplo3();
    }
}