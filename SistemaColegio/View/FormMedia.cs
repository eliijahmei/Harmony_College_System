using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;

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
            materia.ValueMember = "ID";
            materia.DisplayMember = "Materia";
            turma.ValueMember = "ID";
            turma.DisplayMember = "Classe";
            ra.ValueMember = "RA";

            timer.Start();
            hora.Text = DateTime.Now.ToLongTimeString();
            data.Text = DateTime.Now.ToLongDateString();

            materia.DataSource = materiasModel.ListarMateria();
            turma.DataSource = classesModel.ListarClasses();
            int raAluno = Convert.ToInt32(ra.SelectedValue);
            ListarMedias(raAluno);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        private void turmaMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turma.SelectedValue != null)
            {
                int turmaId = Convert.ToInt32(turma.SelectedValue);
                ra.DataSource = alunoModel.ListarRAPorsala(turmaId);
            }
        }
        private void materia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materia.SelectedValue != null)
            {

                int ra = Convert.ToInt32(this.ra.SelectedValue);
                int materiaId = Convert.ToInt32(materia.SelectedValue);
                int turmaId = Convert.ToInt32(turma.SelectedValue);
                this.ra.DataSource = alunoModel.ListarRAPorsala(turmaId);
                ListarNotas(ra, materiaId);
            }
        }
        private void raMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ra.SelectedValue != null)
            {

                int ra = Convert.ToInt32(this.ra.SelectedValue);
                int materiaId = Convert.ToInt32(materia.SelectedValue);
                ra1.Text = ra.ToString();
                ra2.Text = ra.ToString();
                ListarNotas(ra, materiaId);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CalculoDeMedia()
        {
            try
            {
                if (ra.SelectedValue != null && materia.SelectedValue != null)
                {
                    int selectedRa = Convert.ToInt32(ra.SelectedValue);
                    int selectedMateriaId = Convert.ToInt32(materia.SelectedValue);
                    double mediaNotas = 0;
                    int selecao = 0;

                    foreach (DataGridViewRow row in gridNotas.Rows)
                    {
                        if (row.Cells["RA"].Value.ToString() == selectedRa.ToString() && Convert.ToInt32(row.Cells["Materia"].Value) == selectedMateriaId)
                        {
                            double nota = Convert.ToDouble(row.Cells["Nota"].Value);
                            mediaNotas += nota;
                            selecao++;
                        }
                    }
                    if (selecao == 4)
                    {
                        mediaNotas /= selecao;
                        media.Text = mediaNotas.ToString("F2");
                    }
                    else
                    {
                        media.Text = string.Empty;
                        MessageBox.Show("É necessário ter exatamente 4 notas para calcular a média.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } 
            }
            catch (Exception)
            {
                MessageBox.Show("É necessário ter exatamente 4 notas para calcular a média.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
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
                gridMedias.EnableHeadersVisualStyles = false;
                gridMedias.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                gridMedias.DataSource = mediaModel.ListarMedias(ra);
                gridMedias.Columns[0].HeaderText = "RA";
                gridMedias.Columns[0].Visible = false;
                gridMedias.Columns[1].HeaderText = "Matéria";
                gridMedias.Columns[2].HeaderText = "Média";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar as médias! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gridNotas2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            salvar.Enabled = false;
            ra.Text = gridNotas.CurrentRow.Cells[0].Value.ToString();
            materia.Text = gridNotas.CurrentRow.Cells[1].Value.ToString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SalvarMedias(Medias medias)
        {
            try
            {
                medias.Media = Convert.ToDouble(media.Text);

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
            CalculoDeMedia();
        }
        private void salvarMedia_Click(object sender, EventArgs e)
        {
            try
            {
                Medias medias = new Medias();
                medias.Aluno = new Aluno();
                medias.Materia = new Materias();
                medias.Aluno.Ra = Convert.ToInt32(ra.SelectedValue);
                medias.Materia.Id = Convert.ToInt32(materia.SelectedValue);
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
