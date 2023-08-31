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
            comboTurma.ValueMember = "ID";
            comboTurma.DisplayMember = "Classe";

            timer.Start();

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();

            comboTurma.DataSource = classesModel.ListarClasses();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurma.SelectedValue != null)
            {
                int sala = Convert.ToInt32(comboTurma.SelectedValue);
                ListarAlunosPorTurma(sala);
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                int sala = Convert.ToInt32(comboTurma.SelectedValue);
                ListarAlunosPorTurma(sala);
                return;
            }
            BuscarAlunos(txtBuscar.Text);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarAlunosPorTurma(int sala)
        {
            try
            {
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dgv.DataSource = alunoModel.ListarAlunosPorsala(sala);

                dgv.Columns[0].HeaderText = "RA";
                dgv.Columns[1].HeaderText = "Nome";
                dgv.Columns[2].HeaderText = "Sexo";
                dgv.Columns[3].HeaderText = "Data de Nascimento";
                dgv.Columns[4].HeaderText = "Classe";
                dgv.Columns[4].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os alunos pela turma! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuscarAlunos(string ra)
        {
            try
            {
                dgv.DataSource = alunoModel.BuscarAlunosPorRA(ra);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os dados do aluno! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int alunoRa = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
            Aluno aluno = alunoModel.AlunoPorRA(alunoRa);
            this.Close();
            FormBoletimAluno form = new FormBoletimAluno(aluno);
            form.Show();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
