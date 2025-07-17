
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;
using Repository;

namespace View
{
    public partial class ViewProfessor : Form
    {
        private readonly DateTimePicker datePicker;
        private readonly DataGridView dgvAlunos;
        private readonly Button btnSalvar;
        private List<Aluno> alunos;
        private Professor professor;

        public ViewProfessor(Professor prof)
        {
            professor = prof;
            RepositoryAluno.SincronizarComBanco(); // Sync with DB after any change
            alunos = ControllerAluno.ListarAlunos();
            // InitializeComponent(); // Remove if not using designer

            Text = $"Controle de Presença - {professor.Nome}";
            Size = new System.Drawing.Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;

            datePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 200
            };
            Controls.Add(datePicker);

            dgvAlunos = new DataGridView
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(740, 400),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false
            };
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID" });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
            dgvAlunos.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Presente", HeaderText = "Presente" });
            Controls.Add(dgvAlunos);

            btnSalvar = new Button
            {
                Text = "Salvar Presença",
                Location = new System.Drawing.Point(20, 480)
            };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            LoadAlunosParaData(datePicker.Value);
            datePicker.ValueChanged += (s, e) => LoadAlunosParaData(datePicker.Value);
        }

        private void LoadAlunosParaData(DateTime data)
        {
            // Simula carregamento de presença para cada aluno na data
            var listaPresenca = new List<AlunoPresencaViewModel>();
            foreach (var aluno in alunos)
            {
                var freq = professor.Frequencias.Find(f => f.AlunoId == aluno.Id && f.Data.Date == data.Date);
                listaPresenca.Add(new AlunoPresencaViewModel
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Presente = freq != null ? freq.Presente : false
                });
            }
            dgvAlunos.DataSource = listaPresenca;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var data = datePicker.Value.Date;
            var listaPresenca = dgvAlunos.DataSource as List<AlunoPresencaViewModel>;
            if (listaPresenca == null) return;
            foreach (var presenca in listaPresenca)
            {
                var freq = professor.Frequencias.Find(f => f.AlunoId == presenca.Id && f.Data.Date == data);
                if (freq == null)
                {
                    professor.Frequencias.Add(new Frequencia
                    {
                        AlunoId = presenca.Id,
                        Data = data,
                        Presente = presenca.Presente
                    });
                }
                else
                {
                    freq.Presente = presenca.Presente;
                }
            }
            MessageBox.Show("Presença salva com sucesso!");
        }
    }

    // ViewModel para exibir presença no DataGridView
    public class AlunoPresencaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Presente { get; set; }
    }
}
