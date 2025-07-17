using System.Collections.Generic;
using Model;

namespace Repository
{
    public static class RepositoryAluno
    {
        private static List<Aluno> alunos = new List<Aluno>();

        // Synchronize in-memory list with database
        public static void SincronizarComBanco()
        {
            // Fetch all students from the database using RepositoryPessoa
            alunos.Clear();
            var alunosDoBanco = RepositoryPessoa.Listar();
            if (alunosDoBanco != null)
            {
                foreach (var alunoDb in alunosDoBanco)
                {
                    var aluno = new Aluno(alunoDb.Id, alunoDb.Nome, alunoDb.Email ?? "", alunoDb.Matricula ?? "");
                    alunos.Add(aluno);
                }
            }
        }

        public static void Adicionar(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public static List<Aluno> Listar()
        {
            return new List<Aluno>(alunos);
        }

        public static Aluno? BuscarPorId(int id)
        {
            return alunos.Find(a => a.Id == id);
        }

        public static void Remover(int id)
        {
            var aluno = BuscarPorId(id);
            if (aluno != null)
                alunos.Remove(aluno);
        }

        public static void Atualizar(Aluno alunoAtualizado)
        {
            var aluno = BuscarPorId(alunoAtualizado.Id);
            if (aluno != null)
            {
                aluno.Nome = alunoAtualizado.Nome;
                aluno.Email = alunoAtualizado.Email;
                aluno.Matricula = alunoAtualizado.Matricula;
            }
        }
    }
    
}
