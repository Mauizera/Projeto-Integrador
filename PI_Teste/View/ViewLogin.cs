
using System;
using System.Windows.Forms;
using Model;
using Controller;
using Repository;
using View;

namespace PI_Teste
{
    public partial class ViewLogin : Form
    {
        private readonly Label lblLogin;
        private readonly Label lblSenha;
        private readonly TextBox txtLogin;
        private readonly TextBox txtSenha;
        private readonly Button btnEntrar;

        // For demonstration, a static list of professors
        private static readonly List<Professor> professores = new List<Professor>
        {
            new Professor(1, "prof1", "prof1@email.com", "senha1", "Matemática"),
            new Professor(2, "prof2", "prof2@email.com", "senha2", "História")
        };

        public ViewLogin()
        {
            Text = "Login";
            Size = new System.Drawing.Size(400, 300);
            StartPosition = FormStartPosition.CenterScreen;

            lblLogin = new Label { Text = "Login:", Location = new System.Drawing.Point(40, 40), Size = new System.Drawing.Size(60, 30), TextAlign = System.Drawing.ContentAlignment.MiddleRight };
            lblSenha = new Label { Text = "Senha:", Location = new System.Drawing.Point(40, 90), Size = new System.Drawing.Size(60, 30), TextAlign = System.Drawing.ContentAlignment.MiddleRight };
            txtLogin = new TextBox { Location = new System.Drawing.Point(110, 40), Size = new System.Drawing.Size(220, 30) };
            txtSenha = new TextBox { Location = new System.Drawing.Point(110, 90), Size = new System.Drawing.Size(220, 30), PasswordChar = '*' };


            btnEntrar = new Button { Text = "Entrar", Location = new System.Drawing.Point(160, 200), Size = new System.Drawing.Size(80, 35) };
            btnEntrar.Click += BtnEntrar_Click;

            Controls.Add(lblLogin);
            Controls.Add(lblSenha);
            Controls.Add(txtLogin);
            Controls.Add(txtSenha);

            Controls.Add(btnEntrar);
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha login e senha.");
                return;
            }

            // Try Aluno first
            RepositoryAluno.SincronizarComBanco();
            var alunos = ControllerAluno.ListarAlunos();
            var aluno = alunos.Find(a => a.Nome == login && a.Matricula == senha);
            if (aluno != null)
            {
                MessageBox.Show($"Bem-vindo, Aluno {aluno.Nome}!");
                // new ViewAluno(aluno).Show();
                // this.Hide();
                return;
            }

            // Try Professor
            var professor = professores.Find(p => p.Nome == login && p.Senha == senha);
            if (professor != null)
            {
                MessageBox.Show($"Bem-vindo, Professor {professor.Nome}!");
                var viewProfessor = new ViewProfessor(professor);
                viewProfessor.Show();
                this.Hide();
                return;
            }

            MessageBox.Show("Usuário não encontrado ou senha incorreta.");
        }
    }
}
