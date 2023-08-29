using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace SistemaColegio.View
{
    public partial class FormAlunos : Form
    {
        AlunoModel alunoModel = new AlunoModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormAlunos()
        {
            InitializeComponent();
        }
        private void FormAlunos_Load(object sender, EventArgs e)
        {
            ListarAlunos();
            timer.Start();
            hora.Text = DateTime.Now.ToLongTimeString();
            data.Text = DateTime.Now.ToLongDateString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarAlunos()
        {
            try
            {
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                grid.DataSource = alunoModel.ListarAlunos();
                grid.Columns[0].HeaderText = "RA";
                grid.Columns[1].HeaderText = "Nome";
                grid.Columns[2].HeaderText = "Sexo";
                grid.Columns[3].HeaderText = "Data de Nascimento";
                grid.Columns[4].HeaderText = "Classe";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os dados!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                ListarAlunos();
                return;
            }
            BuscarAlunos(buscar.Text);
        }
        private void buscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A busca é feita por RA.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void sairAlunos_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void voltarAlunos_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
