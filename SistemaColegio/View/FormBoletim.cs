using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace SistemaColegio.View
{
    public partial class FormBoletim : Form
    {
        AlunoModel alunoModel = new AlunoModel();
        ClassesModel classesModel = new ClassesModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormBoletim()
        {
            InitializeComponent();
        }
        private void FormBoletim_Load(object sender, EventArgs e)
        {
            turma.ValueMember = "ID";
            turma.DisplayMember = "Classe";

            timer.Start();
            hora.Text = DateTime.Now.ToLongTimeString();
            data.Text = DateTime.Now.ToLongDateString();

            turma.DataSource = classesModel.ListarClasses();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        private void turma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turma.SelectedValue != null)
            {
                int sala = Convert.ToInt32(turma.SelectedValue);
                ListarAlunosPorTurma(sala);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarAlunosPorTurma(int sala)
        {
            try
            {
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                grid.DataSource = alunoModel.ListarAlunosPorsala(sala);
                grid.Columns[0].HeaderText = "RA";
                grid.Columns[1].HeaderText = "Nome";
                grid.Columns[2].HeaderText = "Sexo";
                grid.Columns[3].HeaderText = "Data de Nascimento";
                grid.Columns[4].HeaderText = "Classe";
                grid.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os alunos! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuscarAlunos(string ra)
        {
            try
            {
                grid.DataSource = alunoModel.BuscarAlunosPorRA(ra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buscarAluno_TextChanged(object sender, EventArgs e)
        {
            if (buscar.Text == "")
            {
                int sala = Convert.ToInt32(turma.SelectedValue);
                ListarAlunosPorTurma(sala);
                return;
            }
            BuscarAlunos(buscar.Text);
        }
        private void buscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A busca é feita por RA.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int alunoRa = Convert.ToInt32(grid.CurrentRow.Cells[0].Value);
            Aluno aluno = alunoModel.AlunoPorRA(alunoRa);
            this.Close();
            FormBoletimAluno form = new FormBoletimAluno(aluno);
            form.Show();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
