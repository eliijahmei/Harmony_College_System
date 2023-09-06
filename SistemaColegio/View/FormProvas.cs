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
            comboMateriaProva.ValueMember = "ID";
            comboMateriaProva.DisplayMember = "Materia";
            comboTurmaProva.ValueMember = "ID";
            comboTurmaProva.DisplayMember = "Classe";
            comboBimestreProva.ValueMember = "ID";
            comboBimestreProva.DisplayMember = "Bimestre";
            comboMateriaNota.ValueMember = "ID";
            comboMateriaNota.DisplayMember = "Materia";
            comboProfessor.ValueMember = "ID";
            comboProfessor.DisplayMember = "Nome";
            comboId.ValueMember = "ID";
            comboTurmaNota.ValueMember = "ID";
            comboTurmaNota.DisplayMember = "Classe";
            comboRa.ValueMember = "RA";

            int raAluno = Convert.ToInt32(comboRa.SelectedValue);
            int materiaId = Convert.ToInt32(comboMateriaNota.SelectedValue);
            ListarProvas();
            ListarNotas(raAluno, materiaId);

            timer.Start();

            btnHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();

            comboMateriaProva.DataSource = materiasModel.ListarMateria();
            comboTurmaProva.DataSource = classesModel.ListarClasses();
            comboMateriaNota.DataSource = materiasModel.ListarMateria();
            comboTurmaNota.DataSource = classesModel.ListarClasses();
            comboBimestreProva.DataSource = provaModel.ListarBimestres();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            btnHora.Text = DateTime.Now.ToLongTimeString();
        }
        public void LimparCampos()
        {
            comboId.Text = "";
            txtIdProva.Text = "";
            comboBimestreProva.Text = "";
            comboMateriaProva.SelectedIndex = 0;
            comboMateriaNota.SelectedIndex = 0;
            comboTurmaNota.SelectedIndex = 0;
            comboTurmaProva.SelectedIndex = 0;
            txtNota.Text = "";
            dtDataAgendamento.Value = DateTime.Now;
        }
        private void GetRaTurma(out int ra, out int turma)
        {
            ra = Convert.ToInt32(comboRa.SelectedValue);
            turma = Convert.ToInt32(comboTurmaNota.SelectedValue);
        }
        private void GetRaNotas(out int raAluno, out int materia)
        {
            raAluno = Convert.ToInt32(comboRa.SelectedValue);
            materia = Convert.ToInt32(comboMateriaNota.SelectedValue);
        }
        private void turmaProvaAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurmaNota.SelectedValue != null)
            {
                int classe = Convert.ToInt32(comboTurmaNota.SelectedValue);
                int materia = Convert.ToInt32(comboMateriaNota.SelectedValue);
                comboId.DataSource = provaModel.ListarProvasPorMateriaTurma(materia, classe);
                comboRa.DataSource = alunoModel.ListarAlunosPorClasse(classe);
            }
        }
        private void raAlunoAt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurmaNota.SelectedValue != null && comboRa.SelectedValue != null)
            {
                GetRaTurma(out int ra, out int turma);
                txtRaGrid.Text = ra.ToString();
                ListarNotas(ra, turma);
            }
        }
        private void materiaProvaAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRaTurma(out int ra, out int turma);
            int professor = Convert.ToInt32(comboMateriaNota.SelectedValue);
            comboId.DataSource = provaModel.ListarProvasPorMateriaTurma(professor, turma);
            comboProfessor.DataSource = professorModel.ListarProfessoresPorMateria(professor);
            ListarNotas(ra, professor);
        }
        private void idNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboId.SelectedValue);
            txtBimestre.Text = provaModel.ListarBimestre(id);
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarProvas()
        {
            try
            {
                dgvProvas.EnableHeadersVisualStyles = false;
                dgvProvas.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                dgvProvas.DataSource = provaModel.ListarProvas();

                dgvProvas.Columns[0].HeaderText = "ID";
                dgvProvas.Columns[1].HeaderText = "Data de agendamento";
                dgvProvas.Columns[2].HeaderText = "Matéria";
                dgvProvas.Columns[3].HeaderText = "Turma";
                dgvProvas.Columns[3].HeaderText = "Bimestre";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as provas!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ListarNotas(int ra, int materia)
        {
            try
            {
                dgvNotas.EnableHeadersVisualStyles = false;
                dgvNotas.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                dgvNotas.DataSource = provaModel.ListarNotas(ra, materia);

                dgvNotas.Columns[0].HeaderText = "RA";
                dgvNotas.Columns[0].Visible = false;
                dgvNotas.Columns[1].HeaderText = "Prova";
                dgvNotas.Columns[2].HeaderText = "Nota";
                dgvNotas.Columns[3].HeaderText = "Professor";
                dgvNotas.Columns[4].HeaderText = "Materia";
                dgvNotas.Columns[4].Visible = false;

                foreach (DataGridViewRow row in dgvNotas.Rows)
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
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gridProvas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboTurmaProva.Enabled = true;
            dtDataAgendamento.Enabled = true;
            comboMateriaProva.Enabled = true;
            btnSalvarProva.Enabled = false;
            btnEditarProva.Enabled = true;
            btnExcluirProva.Enabled = true;
            btnNovoProva.Enabled = true;
            comboBimestreProva.Enabled = false;

            txtIdProva.Text = dgvProvas.CurrentRow.Cells[0].Value.ToString();
            dtDataAgendamento.Text = dgvProvas.CurrentRow.Cells[1].Value.ToString();
            comboMateriaProva.Text = dgvProvas.CurrentRow.Cells[2].Value.ToString();
            comboTurmaProva.Text = dgvProvas.CurrentRow.Cells[3].Value.ToString();
            comboBimestreProva.Text = dgvProvas.CurrentRow.Cells[4].Value.ToString();
        }
        private void gridNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNovoNota.Enabled = true;
            btnSalvarNota.Enabled = false;
            btnEditarNota.Enabled = true;
            btnExcluirNota.Enabled = true;
            comboId.Enabled = false;
            txtBimestre.Enabled = false;
            comboMateriaNota.Enabled = false;
            comboTurmaNota.Enabled = false;
            comboRa.Enabled = false;
            comboProfessor.Enabled = true;
            txtNota.Enabled = true;

            comboRa.Text = dgvNotas.CurrentRow.Cells[0].Value.ToString();
            comboId.Text = dgvNotas.CurrentRow.Cells[1].Value.ToString();
            txtNota.Text = dgvNotas.CurrentRow.Cells[2].Value.ToString();
            comboProfessor.Text = dgvNotas.CurrentRow.Cells[3].Value.ToString();
            comboMateriaNota.Text = dgvNotas.CurrentRow.Cells[4].Value.ToString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SalvarProva(Prova provas)
        {
            try
            {
                provas.Materia = new Materia();
                provas.Classe = new Classe();
                provas.Bimestre =  new Bimestre();
                provas.Materia.Id = Convert.ToInt32(comboMateriaProva.SelectedValue);
                provas.DataProva = Convert.ToDateTime(dtDataAgendamento.Value);
                provas.Classe.Id = Convert.ToInt32(comboTurmaProva.SelectedValue);
                provas.Bimestre.Id = Convert.ToInt32(comboBimestreProva.SelectedValue);
                provaModel.SalvarProva(provas);
                MessageBox.Show("Prova agendada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Limite de prova por bimestre dessa matéria para essa sala atingido!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EditarProva(Prova provas)
        {
            try
            {
                provas.Materia = new Materia();
                provas.Classe = new Classe();
                provas.Bimestre = new Bimestre();
                provas.Materia.Id = Convert.ToInt32(comboMateriaProva.SelectedValue);
                provas.DataProva = Convert.ToDateTime(dtDataAgendamento.Value);
                provas.Classe.Id = Convert.ToInt32(comboTurmaProva.SelectedValue);

                provaModel.EditarProva(provas);
                MessageBox.Show("Prova editada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao editar a prova!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ExcluirProva(Prova provas)
        {
            try
            {
                provaModel.ExcluirProva(provas);
                MessageBox.Show("Prova cancelada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao cancelar a prova!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SalvarNota(Nota notas)
        {
            try
            {
                notas.Professor = new Professor();
                notas.Materia = new Materia();
                notas.Provas = new Prova();
                notas.Aluno = new Aluno();
                notas.Aluno.Ra = Convert.ToInt32(comboRa.SelectedValue);
                notas.Provas.Id = Convert.ToInt32(comboId.SelectedValue);
                notas.Notaa = Convert.ToDouble(txtNota.Text);
                notas.Professor.Id = Convert.ToInt32(comboProfessor.SelectedValue);
                notas.Materia.Id = Convert.ToInt32(comboMateriaNota.SelectedValue);

                if (!double.TryParse(txtNota.Text, out double nt) || nt < 0 || nt > 10)
                {
                    MessageBox.Show("A nota deve estar entre 0 e 10!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                provaModel.SalvarNota(notas);
                MessageBox.Show("Nota atribuida com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Limite de nota por prova excedido! Apenas uma nota em cada prova por aluno.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EditarNota(Nota notas)
        {
            try
            {
                notas.Professor = new Professor();
                notas.Materia = new Materia();
                notas.Provas = new Prova();
                notas.Aluno = new Aluno();
                notas.Aluno.Ra = Convert.ToInt32(comboRa.SelectedValue);
                notas.Provas.Id = Convert.ToInt32(comboId.SelectedValue);
                notas.Notaa = Convert.ToDouble(txtNota.Text);
                notas.Professor.Id = Convert.ToInt32(comboProfessor.SelectedValue);
                notas.Materia.Id = Convert.ToInt32(comboMateriaNota.SelectedValue);

                if (!double.TryParse(txtNota.Text, out double nt) || nt < 0 || nt > 10)
                {
                    MessageBox.Show("A nota deve estar entre 0 e 10!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                provaModel.EditarNota(notas);
                MessageBox.Show("Nota editada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro editar a nota!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ExcluirNota(Nota notas)
        {
            try
            {
                provaModel.ExcluirNota(notas);
                MessageBox.Show("Nota excluida com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao excluir a nota!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void novoProva_Click(object sender, EventArgs e)
        {
            comboMateriaProva.Enabled = true;
            dtDataAgendamento.Enabled = true;
            comboTurmaProva.Enabled = true;
            btnSalvarProva.Enabled = true;
            btnEditarProva.Enabled = false;
            btnExcluirProva.Enabled = false;
            btnNovoProva.Enabled = false;
            comboBimestreProva.Enabled = true;
            LimparCampos();
        }
        private void salvarProva_Click(object sender, EventArgs e)
        {
            Prova provas = new Prova();
            btnSalvarProva.Enabled = false;
            btnEditarProva.Enabled = false;
            btnExcluirProva.Enabled = false;
            btnNovoProva.Enabled = true;
            comboMateriaProva.Enabled = false;
            comboTurmaProva.Enabled = false;
            comboBimestreProva.Enabled = false;
            dtDataAgendamento.Enabled = false;
            provas.Materia = new Materia();
            SalvarProva(provas);
            ListarProvas();
            LimparCampos();
        }
        private void editarProva_Click(object sender, EventArgs e)
        {
            Prova provas = new Prova();
            provas.Materia = new Materia();
            btnSalvarProva.Enabled = false;
            btnEditarProva.Enabled = false;
            btnExcluirProva.Enabled = false;
            btnNovoProva.Enabled = true;

            provas.Id = Convert.ToInt32(dgvProvas.CurrentRow.Cells["ID"].Value);
            EditarProva(provas);
            ListarProvas();
            LimparCampos();
        }
        private void excluirProva_Click(object sender, EventArgs e)
        {
            Prova provas = new Prova();
            comboBimestreProva.Enabled = false;
            dtDataAgendamento.Enabled = false;
            btnSalvarProva.Enabled = false;
            btnEditarProva.Enabled = false;
            btnExcluirProva.Enabled = false;
            btnNovoProva.Enabled = true;
            if (MessageBox.Show("Tem certeza que deseja cancelar o agendamento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                comboMateriaProva.Enabled = false;
                comboTurmaProva.Enabled = false;
                dtDataAgendamento.Enabled = false;
                return;
            }
            provas.Id = Convert.ToInt32(dgvProvas.CurrentRow.Cells["ID"].Value);
            ExcluirProva(provas);
            LimparCampos();
            int raAluno = Convert.ToInt32(comboRa.SelectedValue);
            int materia = Convert.ToInt32(comboMateriaNota.SelectedValue);
            ListarNotas(raAluno, materia);
            ListarProvas();
        }
        private void novoNota_Click(object sender, EventArgs e)
        {
            comboMateriaNota.Enabled = true;
            comboTurmaNota.Enabled = true;
            comboId.Enabled = true;
            comboRa.Enabled = true;
            comboProfessor.Enabled = true;
            txtNota.Enabled = true;
            btnSalvarNota.Enabled = true;
            btnEditarNota.Enabled = false;
            btnExcluirNota.Enabled = false;
            btnNovoNota.Enabled = false;
            LimparCampos();
        }
        private void salvarNota_Click(object sender, EventArgs e)
        {
            GetRaNotas(out int raAluno, out int materia);
            Nota notas = new Nota();
            btnSalvarNota.Enabled = true;
            btnEditarNota.Enabled = false;
            btnExcluirNota.Enabled = false;
            btnNovoNota.Enabled = true;
            comboMateriaNota.Enabled = false;
            comboTurmaNota.Enabled = false;
            comboId.Enabled = false;
            comboRa.Enabled = false;
            comboProfessor.Enabled = false;
            txtNota.Enabled = false;
            comboId.Enabled = false;
            SalvarNota(notas);
            LimparCampos();
            ListarNotas(raAluno, materia);
        }
        private void editarNota_Click(object sender, EventArgs e)
        {
            GetRaNotas(out int raAluno, out int materia);
            Nota notas = new Nota();
            notas.Provas = new Prova();
            notas.Provas.Id = Convert.ToInt32(dgvNotas.CurrentRow.Cells["ID"].Value);
            EditarNota(notas);
            ListarNotas(raAluno, materia);
        }
        private void excluirNota_Click(object sender, EventArgs e)
        {
            GetRaNotas(out int raAluno, out int materia);
            Nota notas = new Nota();
            notas.Provas = new Prova();
            if (MessageBox.Show("Tem certeza que deseja excluir a nota?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            notas.Provas.Id = Convert.ToInt32(dgvProvas.CurrentRow.Cells["ID"].Value);
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
