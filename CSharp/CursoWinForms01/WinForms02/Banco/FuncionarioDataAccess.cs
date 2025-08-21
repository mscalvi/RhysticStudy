using System;
using System.Data;
using Microsoft.Data.Sqlite;
using WinForms02.Modelos;

namespace WinForms02.Banco
{
    public class FuncionarioDataAccess
    {
        public static DataTable ObterLista()
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\CursoWinForms02\WinForms02\Banco\WFDB2.sqlite";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Funcionarios";
                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }

                con.Close();
            }
        }

        public static void SalvarFuncionario(Funcionario funcionario)
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\CursoWinForms02\WinForms02\Banco\WFDB2.sqlite";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "INSERT INTO Funcionarios (Nome, Email, Salario, Sexo, TipoContrato, DataCadastro) " +
                               "VALUES (@Nome, @Email, @Salario, @Sexo, @TipoContrato, @DataCadastro)";

                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    // Adicionar parâmetros ao comando
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Email", funcionario.Email);
                    cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                    cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                    cmd.Parameters.AddWithValue("@TipoContrato", funcionario.TipoContrato);
                    cmd.Parameters.AddWithValue("@DataCadastro", funcionario.DataCadastro);

                    // Executar o comando
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public static Funcionario PegarFuncionario(long id)
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\CursoWinForms02\WinForms02\Banco\WFDB2.sqlite";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Funcionarios WHERE Id = @Id";

                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    // Adicionar parâmetros ao comando
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Funcionario funcionario = new Funcionario
                            {
                                Id = reader.GetInt64(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),
                                Salario = reader.GetDecimal(3),
                                Sexo = reader.GetString(4),
                                TipoContrato = reader.GetString(5)
                            };

                            return funcionario;
                        }
                    }
                }
            }

            return null; // Retorna null se não encontrar o funcionário
        }

        public static void AtualizarFuncionario(Funcionario funcionario)
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\CursoWinForms02\WinForms02\Banco\WFDB2.sqlite";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "UPDATE Funcionarios " +
                       "SET Nome = @Nome, Email = @Email, Salario = @Salario, Sexo = @Sexo, TipoContrato = @TipoContrato, DataAtualizacao = @DataAtualizacao " +
                       "WHERE Id = @Id";

                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    // Adicionar parâmetros ao comando
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Email", funcionario.Email);
                    cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                    cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                    cmd.Parameters.AddWithValue("@TipoContrato", funcionario.TipoContrato);
                    cmd.Parameters.AddWithValue("@DataAtualizacao", DateTime.Now); // Atualiza o campo DataAtualizacao com o horário atual
                    cmd.Parameters.AddWithValue("@Id", funcionario.Id);

                    // Executar o comando
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public static Funcionario ExcluirFuncionario(long id)
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\CursoWinForms02\WinForms02\Banco\WFDB2.sqlite";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "DELETE FROM Funcionarios WHERE Id = @Id";

                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    // Adicionar parâmetros ao comando
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return null; // Retorna null se não encontrar o funcionário
        }
    }
}