
namespace Model;

public class Aluno
{
  
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Matricula { get; set; }

    // Add other properties or methods as

    public Aluno(int id, string nome, string email, string matricula)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Matricula = matricula;
    }

    // Removed invalid user-defined conversion operator
}
