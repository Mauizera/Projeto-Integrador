namespace Model;

using System;
using System.Collections.Generic;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Disciplina { get; set; }
    // List of attendance records (optional, can be implemented later)
    public List<Frequencia> Frequencias { get; set; } = new List<Frequencia>();

    public Professor(int id, string nome, string email, string senha, string disciplina)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
        Disciplina = disciplina;
    }
}
// Example of an attendance record class
public class Frequencia
{
    public int AlunoId { get; set; }
    public DateTime Data { get; set; }
    public bool Presente { get; set; }
}