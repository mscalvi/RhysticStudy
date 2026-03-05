import java.util.Scanner;

class Pessoa {
    protected String nome;
    protected String telefone;
    protected int dia, mes, ano;
    protected String rg;
    protected String rua, cidade, estado, cep;

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getTelefone() {
        return telefone;
    }

    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }

    public void setNascimento(int d, int m, int a) {
        dia = d;
        mes = m;
        ano = a;
    }

    public void setRG(String rg) {
        this.rg = rg;
    }

    public void setEndereco(String rua, String cidade, String estado, String cep) {
        this.rua = rua;
        this.cidade = cidade;
        this.estado = estado;
        this.cep = cep;
    }
}

class Aluno extends Pessoa {        
    private int ra;
    private double cr;

    public int getRA() {
        return ra;
    }

    public void setRA(int ra) {
        this.ra = ra;
    }

    public double getCR() {
        return cr;
    }

    public void setCR(double cr) {
        this.cr = cr;
    }

    public void ImprimirAluno() {
        System.out.println("Nome: " + nome);
        System.out.println("Nascimento: " + dia + "/" + mes + "/" + ano);
        System.out.println("RG: " + rg);
        System.out.println("Endereço: " + rua + ", " + cidade + ", " + estado + " - " + cep);
        System.out.println("Telefone: " + telefone);
        System.out.println("RA: " + ra);
        System.out.println("CR: " + cr);
        System.out.println("-----------------------\n");
    }
}   

public class Objetos_Alunos {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        Aluno[] alunos = new Aluno[100];
        int total = 0;

        int opcao;

        do {
            System.out.println("1 - Inserir aluno");
            System.out.println("2 - Buscar por RA");
            System.out.println("3 - Imprimir cadastro");
            System.out.println("0 - Sair");

            opcao = sc.nextInt();
            sc.nextLine();

            switch(opcao) {
                case 1:
                    if (total >= 100){
                        System.out.println("Lista lotada.");
                        break;
                    }

                    Aluno al = new Aluno();

                    System.out.print("Nome: ");
                    al.setNome(sc.nextLine());

                    System.out.print("Telefone: ");
                    al.setTelefone(sc.nextLine());

                    System.out.print("Dia de nascimento: ");
                    int d = sc.nextInt();

                    System.out.print("Mes de nascimento: ");
                    int m = sc.nextInt();

                    System.out.print("Ano de nascimento: ");
                    int y = sc.nextInt();
                    sc.nextLine();

                    al.setNascimento(d, m, y);

                    System.out.print("RG: ");
                    al.setRG(sc.nextLine());

                    System.out.print("Rua: ");
                    String rua = sc.nextLine();

                    System.out.print("Cidade: ");
                    String cidade = sc.nextLine();

                    System.out.print("Estado: ");
                    String estado = sc.nextLine();

                    System.out.print("CEP: ");
                    String cep = sc.nextLine();

                    al.setEndereco(rua, cidade, estado, cep);

                    System.out.print("RA: ");
                    al.setRA(sc.nextInt());

                    System.out.print("CR: ");
                    al.setCR(sc.nextDouble());

                    alunos[total] = al;
                    total++;

                    break;

                case 2:
                    System.out.print("Digite o RA: ");
                    int busca = sc.nextInt();

                    boolean registrado = false;

                    for (int i = 0; i<total; i++){
                        if(alunos[i].getRA() == busca){
                            alunos[i].ImprimirAluno();
                            registrado = true;
                        }
                    }

                    if (!registrado)
                        System.out.println("Aluno sem registro.");

                    break;

                case 3:
                    System.out.println("1 - Ordenar por RA");
                    System.out.println("2 - Ordenar por Nome");
                    System.out.println("3 - Ordenar por CR");

                    int tipo = sc.nextInt();

                    if (tipo == 1){
                        for (int i = 0; i < total - 1; i++) {
                            for (int j = 0; j < total - 1 - i; j++) {
                                if (alunos[j].getRA() > alunos[j + 1].getRA()) {
                                    Aluno temp = alunos[j];
                                    alunos[j] = alunos[j + 1];
                                    alunos[j + 1] = temp;
                                }         
                            }
                        }
                    }

                    if (tipo == 2){
                        for (int i = 0; i < total - 1; i++) {
                            for (int j = 0; j < total - 1 - i; j++) {
                                if (alunos[j].getNome().compareTo(alunos[j + 1].getNome()) > 0) {
                                    Aluno temp = alunos[j];
                                    alunos[j] = alunos[j + 1];
                                    alunos[j + 1] = temp;
                                }         
                            }
                        }
                    }

                    if (tipo == 3){
                        for (int i = 0; i < total - 1; i++) {
                            for (int j = 0; j < total - 1 - i; j++) {
                                if (alunos[j].getCR() > alunos[j + 1].getCR()) {
                                    Aluno temp = alunos[j];
                                    alunos[j] = alunos[j + 1];
                                    alunos[j + 1] = temp;
                                }         
                            }
                        }
                    }

                    for (int i = 0; i<total; i++){
                        alunos[i].ImprimirAluno();
                    }

                    break;
            }

        } while (opcao != 0);

        sc.close();
    }
}

