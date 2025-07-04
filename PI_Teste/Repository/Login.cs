using model;
using MySqlConnector;

namespace Repository;

public class RepositoryPessoa
{
    
    static List<Pessoa> pessoas = [];
    private static MySqlConnection conexao;
    private static void StartConexao()
    {
        string info = "server=localhost;database=projetointegrador;user id=root;password=''";
        conexao = new MySqlConnection(info);
        try
        {
            conexao.Open();
        }
        catch (System.Exception)
        {
            MessageBox.Show("Erro de conexão");
        }
    }
    public static void EndConexao()
    {
        conexao.Close();
    }

    public static List<Pessoa> Sincronizar()
    {
        StartConexao();
        string query = "SELECT * FROM pessoas";
        MySqlCommand command = new MySqlCommand(query, conexao);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Id = Convert.ToInt32(reader["id"].ToString);
            pessoa.Nome = reader["nome"].ToString();
            pessoa.Idade = Convert.ToInt32(reader["idade"].ToString);

            pessoas.Add(pessoa);
        }

        EndConexao();
        return pessoas;
    }
    public static void Criar(Pessoa pessoa)
    {
        pessoas.Add(pessoa);
    }

    public static List<Pessoa> Listar()
    {
        return pessoas;
    }

    public static void Alternar(int id, string nome, int idade)
    {
        pessoas[id].Nome = nome;
        pessoas[id].Idade = idade;
    }

    public static void Deletar(int id)
    {
        pessoas.RemoveAt(id);
    }
}