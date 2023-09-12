using System.Windows.Forms;
using SistemaColegio.View;
using System;

namespace SistemaColegio
{
    public partial class FormPrincipal : Form
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            timer.Start();
            hora.Text = DateTime.Now.ToLongTimeString ();
            data.Text = DateTime.Now.ToLongDateString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnCadProfessor_Click(object sender, EventArgs e)
        {
            FormCadastroProfessor form = new FormCadastroProfessor();
            form.Show();
        }
        private void btnCadAlunos_Click(object sender, EventArgs e)
        {
            FormCadastroAluno form = new FormCadastroAluno();
            form.Show();
        }
        private void btnProfessores_Click(object sender, EventArgs e)
        {
            FormProfessores form = new FormProfessores();
            form.Show();
        }
        private void btnAlunos_Click(object sender, EventArgs e)
        {
            FormAlunos form = new FormAlunos();
            form.Show();
        }
        private void btnProvas_Click(object sender, EventArgs e)
        {
            FormProvas form = new FormProvas();
            form.Show();
        }
        private void btnMedias_Click(object sender, EventArgs e)
        {
            FormMedia form = new FormMedia();
            form.Show();
        }
        private void btnBoletim_Click(object sender, EventArgs e)
        {
            FormBoletim form = new FormBoletim();
            form.Show();
        }
        private void sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
