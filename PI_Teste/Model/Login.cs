using Repository;

namespace model;

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa() { }

    public Pessoa(string nome, int idade)
    {
        
        Nome = nome;
        Idade = idade;

        RepositoryPessoa.Criar(this);
    }

    public void MostrarDados()
    {
        MessageBox.Show($"O aluno {Nome}, {Idade} anos de idade. Está cadastrado em nosso sistema");
    }
}