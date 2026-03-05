import java.util.Scanner;

public class Basico_Classe {
	private String Name;
	private String Adress;
	private String Phone;
	private int Age;
	
	public String getName() {
        return Name;
    }

    public String getAdress() {
        return Adress;
    }

    public String getPhone() {
        return Phone;
    }

    public int getAge() {
        return Age;
    }

    public void setName(String Name) {
        this.Name = Name;
    }

    public void setAdress(String Adress) {
        this.Adress = Adress;
    }

    public void setPhone(String Phone) {
        this.Phone = Phone;
    }

    public void setAge(int Age) {
        this.Age = Age;
    }


    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
		
        Basico_Classe p1 = new Basico_Classe();

        System.out.print("Digite o nome: ");
        p1.setName(sc.nextLine());

        System.out.print("Digite o endereço: ");
        p1.setAdress(sc.nextLine());

        System.out.print("Digite o telefone: ");
        p1.setPhone(sc.nextLine());

        System.out.print("Digite a idade: ");
        p1.setAge(sc.nextInt());

        System.out.println("\n--- Dados da Pessoa ---");
        System.out.println("Nome: " + p1.getName());
        System.out.println("Endereço: " + p1.getAdress());
        System.out.println("Telefone: " + p1.getPhone());
        System.out.println("Idade: " + p1.getAge());
		
		sc.close();
    }
}