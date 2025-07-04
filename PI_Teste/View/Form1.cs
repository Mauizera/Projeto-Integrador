using controller;
using model;

namespace PI_Teste;

public partial class ViewPessoa : Form 
{
    private readonly Label Lbllogin;
    private readonly Label LblSenha;
    private readonly TextBox InptLogin;
    private readonly TextBox InptSenha;
    private readonly Button BttnLogar;
    private readonly Button BttnAlterar;
    private readonly Button BttnDeletar;
    private readonly DataGridView DgvAlunos;

    public ViewPessoa()
    {
        ControllerPessoa.Sincronizar();

        Size = new Size(800, 800);
        StartPosition = FormStartPosition.CenterScreen;

        Lbllogin = new Label
        {
            Text = "User: ",
            Location = new Point(50, 50)
        };

        LblSenha = new Label
        {
            Text = "Senha: ",
            Location = new Point(100, 100),

        };

        InptLogin = new TextBox
        {
            Text = " ",
            Location = new Point(50, 100),
            Size = new Size(150, 100)
        };

        InptSenha = new TextBox
        {
            Text = " ",
            Location = new Point(150, 100),
            Size = new Size(200, 100)
        };

        BttnLogar = new Button
        {
            Text = "Login ",
            Location = new Point(300, 100),
        }; BttnLogar.Click += Criar;

        BttnAlterar = new Button
        {
            Text = "Alterar",
            Location = new Point(300, 200),
        }; BttnAlterar.Click += Alterar;

        BttnDeletar = new Button
        {
            Text = "Deletar",
            Location = new Point(300, 300)
        }; BttnDeletar.Click += Deletar;


        Controls.Add(Lbllogin);
        Controls.Add(LblSenha);
        Controls.Add(InptLogin);
        Controls.Add(InptSenha);
        Controls.Add(BttnLogar);
        Controls.Add(BttnAlterar);
        Controls.Add(BttnDeletar);
        Controls.Add(DgvAlunos);

    }
    private void Listar()
    {
        List<Pessoa> pessoas = ControllerPessoa.Listar();
        DgvAlunos.DataSource = pessoas;
        DgvAlunos.AutoGenerateColumns = false;
        DgvAlunos.Columns.Clear();

        DgvAlunos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Nome",
            HeaderText = "Nome",
        });

        DgvAlunos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Idade",
            HeaderText = "Idade",
        });
    }

    private void Criar(object? sender, EventArgs e)
    {
        if (InptLogin.Text.Length < 1)
        {
            MessageBox.Show("Preencha o seu login");
            return;
        }
        else if (InptSenha.Text.Length < 1)
        {
            MessageBox.Show("Preencha a sua senha");
            return;
        }
        MessageBox.Show("Aluno Cadastrado com sucesso!");
        ControllerPessoa.Criar(InptLogin.Text, Convert.ToInt32(InptSenha.Text));
        Listar();
    }

    private void Alterar(object? sender, EventArgs e)
    {
        int Id = DgvAlunos.SelectedRows[0].Index;

        if (InptLogin.Text.Length < 1)
        {
            MessageBox.Show("Preencha o seu login novamente");
            return;
        }
        else if (InptSenha.Text.Length < 1)
        {
            MessageBox.Show("Preencha a sua senha novamente");
            return;
        }
        MessageBox.Show("Dados alterados com sucesso!");

        ControllerPessoa.Alternar(Id, InptLogin.Text, Convert.ToInt32(InptSenha.Text));
        Listar();
    }

    private void Deletar(object? sender, EventArgs e)
    {
        int index = DgvAlunos.SelectedRows[0].Index;

        ControllerPessoa.Deletar(index);

        MessageBox.Show("Usuário deletado com sucesso");
        Listar();
    }
}

