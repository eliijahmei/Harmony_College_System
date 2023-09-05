using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace SistemaColegio.View
{
    public partial class FormProfessores : Form
    {
        ProfessorModel professorModel = new ProfessorModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormProfessores()
        {
            InitializeComponent();
        }
        private void FormProfessores_Load(object sender, EventArgs e)
        {
            ListarProfessores();

            timer.Start();

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarProfessores()
        {
            try
            {
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dgv.DataSource = professorModel.Listar();

                dgv.Columns[0].HeaderText = "ID";
                dgv.Columns[1].HeaderText = "Nome";
                dgv.Columns[2].HeaderText = "Sexo";
                dgv.Columns[3].HeaderText = "Data de Nascimento";
                dgv.Columns[4].HeaderText = "Matéria";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os dados dos professores!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void sairProfessores_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void voltarProfessores_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
