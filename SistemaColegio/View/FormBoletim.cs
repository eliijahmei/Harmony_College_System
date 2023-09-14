using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Runtime.InteropServices;

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
            comboSituacao.SelectedIndex = 0;

            timer.Start();

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();

            comboTurma.DataSource = classesModel.ListarClasses();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        //}
        //private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int classe = Convert.ToInt32(comboTurma.SelectedValue);
        //    string situacao = comboSituacao.Text.ToString();
        //    ListarAlunosPorClasseSituacao(classe, situacao);
        //}
        //private void comboSituacao_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int classe = Convert.ToInt32(comboTurma.SelectedValue);
        //    string situacao = comboSituacao.Text.ToString();
        //    ListarAlunosPorClasseSituacao(classe, situacao);
        }
        //private void txtBuscar_TextChanged(object sender, EventArgs e)
        //{
        //    int classe = Convert.ToInt32(comboTurma.SelectedValue);
        //    string situacao = comboSituacao.Text.ToString();
        //    if (txtBuscar.Text == "")
        //    {
        //        ListarAlunosPorClasseSituacao(classe, situacao);
        //        return;
        //    }
        //    BuscarAlunos(txtBuscar.Text);
        //}
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //public void BuscarAlunos(string ra)
        //{
        //    try
        //    {
        //        dgv.DataSource = alunoModel.BuscarAlunosPorRA(ra);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Erro ao listar buscar os dados do aluno! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        //public void ListarAlunosPorClasseSituacao(int classe, string situacao)
        //{
        //    try
        //    {
        //        dgv.EnableHeadersVisualStyles = false;
        //        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
        //        dgv.DataSource = alunoModel.ListarAlunosPorClasse(classe, situacao);

        //        dgv.Columns[0].HeaderText = "RA";
        //        dgv.Columns[1].HeaderText = "Nome";
        //        dgv.Columns[2].HeaderText = "Sexo";
        //        dgv.Columns[3].HeaderText = "Data de Nascimento";
        //        dgv.Columns[4].HeaderText = "Classe";
        //        dgv.Columns[4].Visible = false;
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Erro ao listar os alunos pela classe e situação! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) 
                return;
            int ra = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
            Aluno aluno = alunoModel.PegaBoletimAlunoPorRa(ra);
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
