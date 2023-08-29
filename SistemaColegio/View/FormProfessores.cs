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
            hora.Text = DateTime.Now.ToLongTimeString();
            data.Text = DateTime.Now.ToLongDateString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarProfessores()
        {
            try
            {
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                grid.DataSource = professorModel.ListarProfessores();
                grid.Columns[0].HeaderText = "ID";
                grid.Columns[1].HeaderText = "Nome";
                grid.Columns[2].HeaderText = "Sexo";
                grid.Columns[3].HeaderText = "Data de Nascimento";
                grid.Columns[4].HeaderText = "Matéria";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os dados!  ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
