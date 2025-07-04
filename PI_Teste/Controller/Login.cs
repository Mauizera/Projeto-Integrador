using model;
using Repository;

namespace controller;

public class ControllerPessoa
{
    public static void Sincronizar()
    {
        RepositoryPessoa.Sincronizar();
    }
    public static void Criar(string nome, int idade)
    {
        new Pessoa(nome, idade);
    }

    public static List<Pessoa> Listar()
    {
        return RepositoryPessoa.Listar();
    }

    public static void Alternar(int id, string nome, int idade)
    {
        RepositoryPessoa.Alternar(id, nome, idade);
    }

    public static void Deletar(int id)
    {
        RepositoryPessoa.Deletar(id);
    }
}