import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.sql.*;

public class DataBase_Introduction extends JFrame {

    JTextField txtDesc = new JTextField(10);
    JTextField txtQtd = new JTextField(5);
    JTextField txtId = new JTextField(5);

    DefaultTableModel model;
    Connection conn;

    public DataBase_Introduction() {
        setTitle("Estoque");
        setLayout(new BorderLayout());

        conectarBanco();

        // Painel de entrada
        JPanel painel = new JPanel();
        painel.add(new JLabel("ID:"));
        painel.add(txtId);
        painel.add(new JLabel("Descrição:"));
        painel.add(txtDesc);
        painel.add(new JLabel("Qtd:"));
        painel.add(txtQtd);

        JButton btnAdd = new JButton("Adicionar");
        JButton btnUpdate = new JButton("Atualizar");
        JButton btnList = new JButton("Listar");

        painel.add(btnAdd);
        painel.add(btnUpdate);
        painel.add(btnList);

        add(painel, BorderLayout.NORTH);

        // Tabela
        model = new DefaultTableModel(new String[]{"ID", "Descrição", "Qtd"}, 0);
        JTable tabela = new JTable(model);
        add(new JScrollPane(tabela), BorderLayout.CENTER);

        // Eventos
        btnAdd.addActionListener(e -> adicionar());
        btnUpdate.addActionListener(e -> atualizar());
        btnList.addActionListener(e -> listar());

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(600, 300);
        setVisible(true);
    }

    void conectarBanco() {
        try {
            conn = DriverManager.getConnection("jdbc:sqlite:estoque.db");
            Statement st = conn.createStatement();
            st.execute("CREATE TABLE IF NOT EXISTS itens (id INTEGER PRIMARY KEY, descricao TEXT, qtd INTEGER)");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    void adicionar() {
        try {
            PreparedStatement ps = conn.prepareStatement("INSERT INTO itens VALUES (?, ?, ?)");
            ps.setInt(1, Integer.parseInt(txtId.getText()));
            ps.setString(2, txtDesc.getText());
            ps.setInt(3, Integer.parseInt(txtQtd.getText()));
            ps.execute();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(this, "Erro ao adicionar");
        }
    }

    void atualizar() {
        try {
            PreparedStatement ps = conn.prepareStatement("UPDATE itens SET qtd=? WHERE id=?");
            ps.setInt(1, Integer.parseInt(txtQtd.getText()));
            ps.setInt(2, Integer.parseInt(txtId.getText()));
            ps.execute();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(this, "Erro ao atualizar");
        }
    }

    void listar() {
        try {
            model.setRowCount(0);
            Statement st = conn.createStatement();
            ResultSet rs = st.executeQuery("SELECT * FROM itens");

            while (rs.next()) {
                model.addRow(new Object[]{
                        rs.getInt("id"),
                        rs.getString("descricao"),
                        rs.getInt("qtd")
                });
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void main(String[] args) {
        new DataBase_Introduction();
    }
}