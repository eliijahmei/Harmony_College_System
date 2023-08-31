using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace SistemaColegio.View
{
    public partial class FormMedia : Form
    {
        ProvaModel provaModel = new ProvaModel();
        AlunoModel alunoModel = new AlunoModel();
        ClassesModel classesModel = new ClassesModel();
        MateriasModel materiasModel = new MateriasModel();
        MediaModel mediaModel = new MediaModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormMedia()
        {
            InitializeComponent();
        }
        private void FormMedia_Load(object sender, System.EventArgs e)
        {
            comboMateria.ValueMember = "ID";
            comboMateria.DisplayMember = "Materia";
            comboTurma.ValueMember = "ID";
            comboTurma.DisplayMember = "Classe";
            comboRa.ValueMember = "RA";

            timer.Start();

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();

            comboMateria.DataSource = materiasModel.ListarMateria();
            comboTurma.DataSource = classesModel.ListarClasses();
            int raAluno = Convert.ToInt32(comboRa.SelectedValue);
            ListarMedias(raAluno);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        private void turmaMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurma.SelectedValue != null)
            {
                int turmaId = Convert.ToInt32(comboTurma.SelectedValue);
                comboRa.DataSource = alunoModel.ListarRAPorsala(turmaId);
            }
        }
        private void materia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMateria.SelectedValue != null)
            {

                int ra = Convert.ToInt32(comboRa.SelectedValue);
                int materiaId = Convert.ToInt32(comboMateria.SelectedValue);
                int turmaId = Convert.ToInt32(comboTurma.SelectedValue);
                comboRa.DataSource = alunoModel.ListarRAPorsala(turmaId);
                ListarNotas(ra, materiaId);
            }
        }
        private void raMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRa.SelectedValue != null)
            {

                int ra = Convert.ToInt32(comboRa.SelectedValue);
                int materiaId = Convert.ToInt32(comboMateria.SelectedValue);
                txtRaNotas.Text = ra.ToString();
                txtRa.Text = ra.ToString();
                ListarNotas(ra, materiaId);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarNotas(int ra, int materia)
        {
            try
            {
                gridNotas.EnableHeadersVisualStyles = false;
                gridNotas.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                gridNotas.DataSource = provaModel.ListarNotas(ra, materia);
                gridNotas.Columns[0].HeaderText = "RA";
                gridNotas.Columns[0].Visible = false;
                gridNotas.Columns[1].HeaderText = "Prova";
                gridNotas.Columns[2].HeaderText = "Nota";
                gridNotas.Columns[3].HeaderText = "Professor avaliador";
                gridNotas.Columns[4].HeaderText = "Materia";
                gridNotas.Columns[4].Visible = false;

                foreach (DataGridViewRow row in gridNotas.Rows)
                {
                    double nota = Convert.ToDouble(row.Cells["Nota"].Value);
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                    if (nota < 6)
                    {
                        cellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        cellStyle.ForeColor = Color.Green;
                    }
                    row.Cells["Nota"].Style = cellStyle;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar as notas! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ListarMedias(int ra)
        {
            try
            {
                dgvMedias.EnableHeadersVisualStyles = false;
                dgvMedias.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                dgvMedias.DataSource = mediaModel.ListarMedias(ra);
                dgvMedias.Columns[0].HeaderText = "RA";
                dgvMedias.Columns[0].Visible = false;
                dgvMedias.Columns[1].HeaderText = "Matéria";
                dgvMedias.Columns[2].HeaderText = "Média";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar as médias! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gridNotas2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSalvar.Enabled = false;
            comboRa.Text = gridNotas.CurrentRow.Cells[0].Value.ToString();
            comboMateria.Text = gridNotas.CurrentRow.Cells[1].Value.ToString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SalvarMedias(Media medias)
        {
            try
            {
                medias.Mediaa = Convert.ToDouble(txtMedia.Text);

                mediaModel.SalvarMedia(medias);
                MessageBox.Show("Média atribuída com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Não se pode atribuir mais de uma média da mesma matéria por aluno.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void calcular_Click(object sender, EventArgs e)
        {
            Media medias = new Media();
            List<double> notas = new List<double>();
            int ra = Convert.ToInt32(comboRa.SelectedValue);
            int materia = Convert.ToInt32(comboMateria.SelectedValue);

            medias.Aluno = new Aluno();
            medias.Aluno.Ra = ra;
            medias.Materia = new Materia();
            medias.Materia.Id = materia;

            notas = mediaModel.NotasMedia(ra, materia);

            double calculatedMedia = medias.CalcularMedia(notas);

            if (calculatedMedia != -1)
            {
                txtMedia.Text = calculatedMedia.ToString("F2");
            }
            else
            {
                txtMedia.Text = string.Empty;
                MessageBox.Show("É necessário ter exatamente 4 notas para calcular a média.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void salvarMedia_Click(object sender, EventArgs e)
        {
            try
            {
                Media medias = new Media();
                medias.Aluno = new Aluno();
                medias.Materia = new Materia();
                medias.Aluno.Ra = Convert.ToInt32(comboRa.SelectedValue);
                medias.Materia.Id = Convert.ToInt32(comboMateria.SelectedValue);
                if (MessageBox.Show("Tem certeza que deseja atribuir a média? Após a atribuição a média não pode ser alterada.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                SalvarMedias(medias);
                ListarMedias(medias.Aluno.Ra);
            }
            catch (Exception)
            {
                MessageBox.Show("Não se pode atribuir mais de uma média da mesma matéria por aluno.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void voltarMedias_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void sairMedias_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
