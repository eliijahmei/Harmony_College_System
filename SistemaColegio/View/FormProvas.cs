using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace SistemaColegio.View
{
    public partial class FormProvas : Form
    {
        ProvaModel provaModel = new ProvaModel();
        AlunoModel alunoModel = new AlunoModel();
        ClassesModel classesModel = new ClassesModel();
        MateriasModel materiasModel = new MateriasModel();
        ProfessorModel professorModel = new ProfessorModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormProvas()
        {
            InitializeComponent();
        }
        private void FormProvas_Load(object sender, EventArgs e)
        {
            materiaProva.ValueMember = "ID";
            materiaProva.DisplayMember = "Materia";
            turmaProva.ValueMember = "ID";
            turmaProva.DisplayMember = "Classe";
            bimestreProva.ValueMember = "ID";
            bimestreProva.DisplayMember = "Bimestre";
            materiaNota.ValueMember = "ID";
            materiaNota.DisplayMember = "Materia";
            professor.ValueMember = "ID";
            professor.DisplayMember = "Nome";
            idNota.ValueMember = "ID";
            turmaNota.ValueMember = "ID";
            turmaNota.DisplayMember = "Classe";
            ra.ValueMember = "RA";

            int raAluno = Convert.ToInt32(this.ra.SelectedValue);
            int materiaId = Convert.ToInt32(materiaNota.SelectedValue);
            ListarProvas();
            ListarNotas(raAluno, materiaId);

            timer.Start();
            hora.Text = DateTime.Now.ToLongTimeString();
            data.Text = DateTime.Now.ToLongDateString();

            materiaProva.DataSource = materiasModel.ListarMateria();
            turmaProva.DataSource = classesModel.ListarClasses();
            materiaNota.DataSource = materiasModel.ListarMateria();
            turmaNota.DataSource = classesModel.ListarClasses();
            bimestreProva.DataSource = provaModel.ListarBimestres();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        public void LimparCampos()
        {
            idNota.Text = "";
            idProva.Text = "";
            bimestreProva.Text = "";
            materiaProva.SelectedIndex = 0;
            materiaNota.SelectedIndex = 0;
            turmaNota.SelectedIndex = 0;
            turmaProva.SelectedIndex = 0;
            nota.Text = "";
            dataAgendamento.Value = DateTime.Now;
        }
        private void RaTurma(out int ra, out int turma)
        {
            ra = Convert.ToInt32(this.ra.SelectedValue);
            turma = Convert.ToInt32(turmaNota.SelectedValue);
        }
        private void Notas(out int raAluno, out int materia)
        {
            raAluno = Convert.ToInt32(ra.SelectedValue);
            materia = Convert.ToInt32(materiaNota.SelectedValue);
        }
        private void turmaProvaAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turmaNota.SelectedValue != null)
            {
                int classe = Convert.ToInt32(turmaNota.SelectedValue);
                int materia = Convert.ToInt32(materiaNota.SelectedValue);
                idNota.DataSource = provaModel.ListarProvasPorMateriaTurma(materia, classe);
                ra.DataSource = alunoModel.ListarRAPorsala(classe);
            }
        }
        private void raAlunoAt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turmaNota.SelectedValue != null && ra.SelectedValue != null)
            {
                RaTurma(out int ra, out int turma);
                ra1.Text = ra.ToString();
                ListarNotas(ra, turma);
            }
        }
        private void materiaProvaAT_SelectedIndexChanged(object sender, EventArgs e)
        {

            RaTurma(out int ra, out int turma);
            int professor = Convert.ToInt32(materiaNota.SelectedValue);
            idNota.DataSource = provaModel.ListarProvasPorMateriaTurma(professor, turma);
            this.professor.DataSource = professorModel.ListarProfessoresPorMateria(professor);
            ListarNotas(ra, professor);
        }
        private void valorNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(","))
            {
                e.Handled = true;
            }
        }
        private void idNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idNota.SelectedValue);
            bimestre.Text = provaModel.ListarBimestre(id);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarProvas()
        {
            try
            {
                gridProvas.EnableHeadersVisualStyles = false;
                gridProvas.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                gridProvas.DataSource = provaModel.ListarProvas();
                gridProvas.Columns[0].HeaderText = "ID";
                gridProvas.Columns[1].HeaderText = "Data de agendamento";
                gridProvas.Columns[2].HeaderText = "Matéria";
                gridProvas.Columns[3].HeaderText = "Turma";
                gridProvas.Columns[3].HeaderText = "Bimestre";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar as provas! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                gridNotas.Columns[3].HeaderText = "Professor";
                gridNotas.Columns[4].HeaderText = "Materia";
                gridNotas.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar as notas! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gridProvas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            turmaProva.Enabled = true;
            dataAgendamento.Enabled = true;
            materiaProva.Enabled = true;
            salvarProva.Enabled = false;
            editarProva.Enabled = true;
            excluirProva.Enabled = true;
            novoProva.Enabled = true;
            bimestreProva.Enabled = false;
            idProva.Text = gridProvas.CurrentRow.Cells[0].Value.ToString();
            dataAgendamento.Text = gridProvas.CurrentRow.Cells[1].Value.ToString();
            materiaProva.Text = gridProvas.CurrentRow.Cells[2].Value.ToString();
            turmaProva.Text = gridProvas.CurrentRow.Cells[3].Value.ToString();
            bimestreProva.Text = gridProvas.CurrentRow.Cells[4].Value.ToString();
        }
        private void gridNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            novoNota.Enabled = true;
            salvarNota.Enabled = false;
            editarNota.Enabled = true;
            excluirNota.Enabled = true;
            idNota.Enabled = false;
            bimestre.Enabled = false;
            materiaNota.Enabled = false;
            turmaNota.Enabled = false;
            ra.Enabled = false;
            professor.Enabled = true;
            nota.Enabled = true;
            ra.Text = gridNotas.CurrentRow.Cells[0].Value.ToString();
            idNota.Text = gridNotas.CurrentRow.Cells[1].Value.ToString();
            nota.Text = gridNotas.CurrentRow.Cells[2].Value.ToString();
            professor.Text = gridNotas.CurrentRow.Cells[3].Value.ToString();
            materiaNota.Text = gridNotas.CurrentRow.Cells[4].Value.ToString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SalvarProva(Provas provas)
        {
            try
            {
                provas.Materia = new Materias();
                provas.Classe = new Classes();
                provas.Bimestre =  new Bimestres();
                provas.Materia.Id = Convert.ToInt32(materiaProva.SelectedValue);
                provas.DataProva = Convert.ToDateTime(dataAgendamento.Value);
                provas.Classe.Id = Convert.ToInt32(turmaProva.SelectedValue);
                provas.Bimestre.Id = Convert.ToInt32(bimestreProva.SelectedValue);
                provaModel.SalvarProva(provas);
                MessageBox.Show("Prova agendada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Selecione + para agendar mais alguma prova.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Limite de prova por bimestre dessa matéria pora essa sala atingido.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EditarProva(Provas provas)
        {
            try
            {
                provas.Materia = new Materias();
                provas.Classe = new Classes();
                provas.Bimestre = new Bimestres();
                provas.Materia.Id = Convert.ToInt32(materiaProva.SelectedValue);
                provas.DataProva = Convert.ToDateTime(dataAgendamento.Value);
                provas.Classe.Id = Convert.ToInt32(turmaProva.SelectedValue);

                provaModel.EditarProva(provas);
                MessageBox.Show("Prova editada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Selecione + para agendar mais alguma prova.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar a prova! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ExcluirProva(Provas provas)
        {
            try
            {
                provaModel.ExcluirProva(provas);
                MessageBox.Show("Prova cancelada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cancelar a prova! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SalvarNota(Notas notas)
        {
            try
            {
                notas.Professor = new Professor();
                notas.Materia = new Materias();
                notas.Provas = new Provas();
                notas.Aluno = new Aluno();
                notas.Aluno.Ra = Convert.ToInt32(ra.SelectedValue);
                notas.Provas.Id = Convert.ToInt32(idNota.SelectedValue);
                notas.Nota = Convert.ToDouble(nota.Text);
                notas.Professor.Id = Convert.ToInt32(professor.SelectedValue);
                notas.Materia.Id = Convert.ToInt32(materiaNota.SelectedValue);

                if (idNota.SelectedValue == null)
                {
                    MessageBox.Show("Selecione uma prova!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(nota.Text, out double nt) || nt < 0 || nt > 10)
                {
                    MessageBox.Show("A nota deve estar entre 0 e 10!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                provaModel.SalvarNota(notas);
                MessageBox.Show("Nota atribuida com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Selecione + para atribuir mais alguma nota.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Limite de nota por prova excedido, apenas uma nota em cada prova por aluno.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EditarNota(Notas notas)
        {
            try
            {
                notas.Professor = new Professor();
                notas.Materia = new Materias();
                notas.Provas = new Provas();
                notas.Aluno = new Aluno();
                notas.Aluno.Ra = Convert.ToInt32(ra.SelectedValue);
                notas.Provas.Id = Convert.ToInt32(idNota.SelectedValue);
                notas.Nota = Convert.ToDouble(nota.Text);
                notas.Professor.Id = Convert.ToInt32(professor.SelectedValue);
                notas.Materia.Id = Convert.ToInt32(materiaNota.SelectedValue);

                if (idNota.SelectedValue == null)
                {
                    MessageBox.Show("Selecione uma prova!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(nota.Text, out double nt) || nt < 0 || nt > 10)
                {
                    MessageBox.Show("A nota deve estar entre 0 e 10!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                provaModel.EditarNota(notas);
                MessageBox.Show("Nota editada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Selecione + para atribuir mais alguma nota.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro editar a nota! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ExcluirNota(Notas notas)
        {
            try
            {
                provaModel.ExcluirNota(notas);
                MessageBox.Show("Nota excluida com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir a nota! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void novoProva_Click(object sender, EventArgs e)
        {
            materiaProva.Enabled = true;
            dataAgendamento.Enabled = true;
            turmaProva.Enabled = true;
            salvarProva.Enabled = true;
            editarProva.Enabled = false;
            excluirProva.Enabled = false;
            novoProva.Enabled = false;
            bimestreProva.Enabled = true;
            LimparCampos();
        }
        private void salvarProva_Click(object sender, EventArgs e)
        {
            Provas provas = new Provas();
            salvarProva.Enabled = false;
            editarProva.Enabled = false;
            excluirProva.Enabled = false;
            novoProva.Enabled = true;
            materiaProva.Enabled = false;
            turmaProva.Enabled = false;
            bimestreProva.Enabled = false;
            dataAgendamento.Enabled = false;
            provas.Materia = new Materias();
            SalvarProva(provas);
            ListarProvas();
            LimparCampos();
        }
        private void editarProva_Click(object sender, EventArgs e)
        {
            Provas provas = new Provas();
            provas.Materia = new Materias();
            salvarProva.Enabled = false;
            editarProva.Enabled = false;
            excluirProva.Enabled = false;
            novoProva.Enabled = true;

            provas.Id = Convert.ToInt32(gridProvas.CurrentRow.Cells["ID"].Value);
            EditarProva(provas);
            ListarProvas();
            LimparCampos();
        }
        private void excluirProva_Click(object sender, EventArgs e)
        {
            Provas provas = new Provas();
            bimestreProva.Enabled = false;
            dataAgendamento.Enabled = false;
            salvarProva.Enabled = false;
            editarProva.Enabled = false;
            excluirProva.Enabled = false;
            novoProva.Enabled = true;
            if (MessageBox.Show("Tem certeza que deseja cancelar o agendamento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                materiaProva.Enabled = false;
                turmaProva.Enabled = false;
                dataAgendamento.Enabled = false;
                return;
            }
            provas.Id = Convert.ToInt32(gridProvas.CurrentRow.Cells["ID"].Value);
            ExcluirProva(provas);
            LimparCampos();
            int raAluno = Convert.ToInt32(ra.SelectedValue);
            int materia = Convert.ToInt32(materiaNota.SelectedValue);
            ListarNotas(raAluno, materia);
            ListarProvas();
        }
        private void novoNota_Click(object sender, EventArgs e)
        {
            materiaNota.Enabled = true;
            turmaNota.Enabled = true;
            idNota.Enabled = true;
            ra.Enabled = true;
            professor.Enabled = true;
            nota.Enabled = true;
            salvarNota.Enabled = true;
            editarNota.Enabled = false;
            excluirNota.Enabled = false;
            novoNota.Enabled = false;
            LimparCampos();
        }
        private void salvarNota_Click(object sender, EventArgs e)
        {
            Notas(out int raAluno, out int materia);
            Notas notas = new Notas();
            salvarNota.Enabled = false;
            editarNota.Enabled = false;
            excluirNota.Enabled = false;
            novoNota.Enabled = true;
            materiaNota.Enabled = false;
            turmaNota.Enabled = false;
            idNota.Enabled = false;
            ra.Enabled = false;
            professor.Enabled = false;
            nota.Enabled = false;
            idNota.Enabled = false;
            idNota.Enabled = false;
            SalvarNota(notas);
            LimparCampos();
            ListarNotas(raAluno, materia);
        }
        private void editarNota_Click(object sender, EventArgs e)
        {
            Notas(out int raAluno, out int materia);
            Notas notas = new Notas();
            notas.Provas = new Provas();
            notas.Provas.Id = Convert.ToInt32(gridNotas.CurrentRow.Cells["ID"].Value);
            EditarNota(notas);
            ListarNotas(raAluno, materia);
        }
        private void excluirNota_Click(object sender, EventArgs e)
        {
            Notas(out int raAluno, out int materia);
            Notas notas = new Notas();
            notas.Provas = new Provas();
            if (MessageBox.Show("Tem certeza que deseja excluir a nota?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            notas.Provas.Id = Convert.ToInt32(gridProvas.CurrentRow.Cells["ID"].Value);
            ExcluirNota(notas);
            LimparCampos();
            ListarNotas(raAluno, materia);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void sairProvas_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void voltarProvas_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
