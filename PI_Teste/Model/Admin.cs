using Repository;

namespace model;

public class Pessoa
{
    internal readonly string? Matricula;

    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Senha { get; set; }
    public string? Email { get; set; }
    public int Permissao { get; set; }

    public Pessoa() { }

    public Pessoa(string nome, string senha, string email, int permissao)
    {
        
        Nome = nome;
        Senha = senha;
        Email = email;
        Permissao = permissao;
        

        RepositoryPessoa.Criar(this);
    }

    public void MostrarDados()
    {
        MessageBox.Show($"O aluno {Nome}, de email {Email} está cadastrado em nosso sistema");
    }
}