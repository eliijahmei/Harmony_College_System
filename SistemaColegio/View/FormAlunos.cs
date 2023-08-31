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

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                ListarAlunos();
                return;
            }
            BuscarAlunos(txtBuscar.Text);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarAlunos()
        {
            try
            {
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dgv.DataSource = alunoModel.ListarAlunos();

                dgv.Columns[0].HeaderText = "RA";
                dgv.Columns[1].HeaderText = "Nome";
                dgv.Columns[2].HeaderText = "Sexo";
                dgv.Columns[3].HeaderText = "Data de Nascimento";
                dgv.Columns[4].HeaderText = "Classe";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os dados dos alunos!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Erro ao buscar os dados do aluno! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
