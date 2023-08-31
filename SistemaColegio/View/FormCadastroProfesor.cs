using System.Text.RegularExpressions;
using SistemaColegio.Entidades;
using System.Windows.Forms;
using SistemaColegio.Model;
using System.Drawing;
using System.Data;
using System;

namespace SistemaColegio.View
{
    public partial class FormCadastroProfesor : Form
    {
        ProfessorModel professorModel = new ProfessorModel();
        MateriasModel materiasModel = new MateriasModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormCadastroProfesor()
        {
            InitializeComponent();
        }
        private void FormCadProfesor_Load(object sender, EventArgs e)
        {
            coboSexo.SelectedIndex = 0;
            comboMateria.ValueMember = "ID";
            comboMateria.DisplayMember = "Materia";

            ListarProfessores();

            timer.Start();

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();

            comboMateria.DataSource = ListarMaterias();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void HabilitarCampos()
        {
            txtNome.Enabled = true;
            coboSexo.Enabled = true;
            dtDataNasc.Enabled = true;
            comboMateria.Enabled = true;
        }
        public void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            coboSexo.Enabled = false;
            dtDataNasc.Enabled = false;
            comboMateria.Enabled = false;
        }
        public void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            coboSexo.SelectedIndex = 0;
            dtDataNasc.Value = DateTime.Now;
            comboMateria.SelectedIndex = 0;
            txtStatus.Text = "";
        }
        private void nomeProfessor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                grid.Columns[5].HeaderText = "Situação";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os dados dos professores!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public DataTable ListarMaterias()
        {
            try
            {
                return materiasModel.ListarMateria();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as matérias!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        private void gridCadProfessores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            salvar.Enabled = false;
            editar.Enabled = true;
            btnAlterarLecionando.Enabled = true;
            btnAlterarNaoLecionando.Enabled = true;
            novo.Enabled = true;

            txtId.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            coboSexo.Text = grid.CurrentRow.Cells[2].Value.ToString();
            dtDataNasc.Text = grid.CurrentRow.Cells[3].Value.ToString();
            comboMateria.Text = grid.CurrentRow.Cells[4].Value.ToString();
            txtStatus.Text = grid.CurrentRow.Cells[5].Value.ToString();

            HabilitarCampos();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SalvarProfessor(Professor professor)
        {
            try
            {
                professor.Materia = new Materia();
                DateTime dataNascimento = Convert.ToDateTime(dtDataNasc.Value.ToString());
                int idade = professor.CalcularIdade(dataNascimento);
                string nome = txtNome.Text.Trim();

                professor.Nome = txtNome.Text;
                professor.Sexo = coboSexo.Text;
                professor.DataNasc = Convert.ToDateTime(dtDataNasc.Text);
                professor.Materia.Id = Convert.ToInt32(comboMateria.SelectedValue);
                professor.Situacao = "Lecionando";

                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Nome do professor não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}\s'-]+|[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nome do professor deve conter apenas letras!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParse(dtDataNasc.Text, out dataNascimento))
                {
                    MessageBox.Show("Data de nascimento inválida.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (idade < 19 || idade > 70)
                {
                    MessageBox.Show("O profesor deve ter entre 19 e 70 anos de idade.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                professorModel.SalvarProfessor(professor);
                MessageBox.Show("Professor salvio com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o professor! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EditarProfessor(Professor professor)
        {
            try
            {
                professor.Materia = new Materia();
                DateTime dataNascimento = Convert.ToDateTime(dtDataNasc.Value.ToString());
                int idade = professor.CalcularIdade(dataNascimento);
                string nome = txtNome.Text.Trim();

                professor.Nome = txtNome.Text;
                professor.Sexo = coboSexo.Text;
                professor.DataNasc = Convert.ToDateTime(dtDataNasc.Text);
                professor.Materia.Id = Convert.ToInt32(comboMateria.SelectedValue);
                professor.Situacao = "Lecionando";

                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Nome do professor não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (idade < 19 || idade > 70)
                {
                    MessageBox.Show("O profesor deve ter entre 19 e 70 anos de idade.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                professorModel.EditarProfessor(professor);
                MessageBox.Show("Professor editado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar o professor! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AtualizarNaoLecionando(Professor professor)
        {
            try
            {
                professorModel.AtualizarNaoLecionando(professor);
                MessageBox.Show("Status atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o status!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AtualizarLecionando(Professor professor)
        {
            try
            {
                DateTime dataAtual = DateTime.Now;
                int idade = dataAtual.Year - professor.DataNasc.Year;
                string nome = txtNome.Text.Trim();
                professorModel.AtualizarLecionando(professor);

                MessageBox.Show("Status atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o status!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void novoProfessor_Click(object sender, EventArgs e)
        {
            salvar.Enabled = true;
            editar.Enabled = false;
            btnAlterarLecionando.Enabled = false;
            btnAlterarNaoLecionando.Enabled = false;
            novo.Enabled = false;
            HabilitarCampos();
            LimparCampos();
        }
        private void salvarProfessor_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            salvar.Enabled = false;
            editar.Enabled = false;
            btnAlterarLecionando.Enabled = false;
            btnAlterarNaoLecionando.Enabled = false;
            novo.Enabled = true;
            SalvarProfessor(professor);
            ListarProfessores();
            LimparCampos();
            DesabilitarCampos();
        }
        private void editarProfessor_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            professor.Id = Convert.ToInt32(grid.CurrentRow.Cells["ID"].Value);
            EditarProfessor(professor);
            ListarProfessores();
        }
        private void AlterarNaoLecionando_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            salvar.Enabled = false;
            editar.Enabled = false;
            btnAlterarLecionando.Enabled = false;
            btnAlterarNaoLecionando.Enabled = false;
            novo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar o status do professor para 'Não lecionando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                DesabilitarCampos();
                return;
            }

            professor.Id = Convert.ToInt32(grid.CurrentRow.Cells["ID"].Value);
            AtualizarNaoLecionando(professor);
            LimparCampos();
            ListarProfessores();
        }
        private void AlterarLecionando_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            salvar.Enabled = false;
            editar.Enabled = false;
            btnAlterarLecionando.Enabled = false;
            btnAlterarNaoLecionando.Enabled = false;
            novo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar o status do professor para 'Lecionando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                DesabilitarCampos();
                return;
            }

            professor.Id = Convert.ToInt32(grid.CurrentRow.Cells["ID"].Value);
            AtualizarLecionando(professor);
            LimparCampos();
            ListarProfessores();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void sairCadProfessor_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void voltarCadProfessor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
