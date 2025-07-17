using System.Collections.Generic;
using Model;
using Repository;

namespace Controller
{
    public static class ControllerAluno
    {
        public static void AdicionarAluno(Aluno aluno)
        {
            RepositoryAluno.Adicionar(aluno);
        }

        public static List<Aluno> ListarAlunos()
        {
            return RepositoryAluno.Listar();
        }

        public static Aluno? BuscarAlunoPorId(int id)
        {
            return RepositoryAluno.BuscarPorId(id);
        }

        public static void RemoverAluno(int id)
        {
            RepositoryAluno.Remover(id);
        }

        public static void AtualizarAluno(Aluno aluno)
        {
            RepositoryAluno.Atualizar(aluno);
        }
    }
}
