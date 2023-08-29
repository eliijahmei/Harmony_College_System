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
        int anoAtual = DateTime.Now.Year;
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormCadastroProfesor()
        {
            InitializeComponent();
        }
        private void FormCadProfesor_Load(object sender, EventArgs e)
        {
            sexo.SelectedIndex = 0;
            materia.ValueMember = "ID";
            materia.DisplayMember = "Materia";
            ListarProfessores();
            timer.Start();
            hora.Text = DateTime.Now.ToLongTimeString();
            data.Text = DateTime.Now.ToLongDateString();
            materia.DataSource = ListarMaterias();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void HabilitarCampos()
        {
            nome.Enabled = true;
            sexo.Enabled = true;
            dataNasc.Enabled = true;
            materia.Enabled = true;
        }
        public void DesabilitarCampos()
        {
            nome.Enabled = false;
            sexo.Enabled = false;
            dataNasc.Enabled = false;
            materia.Enabled = false;
        }
        public void LimparCampos()
        {
            id.Text = "";
            nome.Text = "";
            sexo.SelectedIndex = 0;
            dataNasc.Value = DateTime.Now;
            materia.SelectedIndex = 0;
            situacao.Text = "";
        }
        public int CalcularIdadeProfessor(Professor professor)
        {
            int idade = anoAtual - dataNasc.Value.Year;
            return idade;
        }
        private void nomeProfessor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void nomeProfessor_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public DataTable ListarMaterias()
        {
            try
            {
                return materiasModel.ListarMateria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void gridCadProfessores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            salvar.Enabled = false;
            editar.Enabled = true;
            AlterarLecionando.Enabled = true;
            AlterarNaoLecionando.Enabled = true;
            novo.Enabled = true;
            id.Text = grid.CurrentRow.Cells[0].Value.ToString();
            nome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            sexo.Text = grid.CurrentRow.Cells[2].Value.ToString();
            dataNasc.Text = grid.CurrentRow.Cells[3].Value.ToString();
            materia.Text = grid.CurrentRow.Cells[4].Value.ToString();
            situacao.Text = grid.CurrentRow.Cells[5].Value.ToString();
            HabilitarCampos();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SalvarProfessor(Professor professor)
        {
            try
            {
                professor.Materia = new Materias();
                DateTime dataAtual = DateTime.Now;
                int idade = CalcularIdadeProfessor(professor);
                string nome = this.nome.Text.Trim();

                professor.Nome = this.nome.Text;
                professor.Sexo = sexo.Text;
                professor.DataNasc = Convert.ToDateTime(this.dataNasc.Text);
                professor.Materia.Id = Convert.ToInt32(materia.SelectedValue);
                professor.Situacao = "Lecionando";

                if (string.IsNullOrWhiteSpace(this.nome.Text))
                {
                    MessageBox.Show("Nome do professor não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}\s'-]+|[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nome do professor deve conter apenas letras!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParse(dataNasc.Text, out DateTime dataNascimento))
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
                LimparCampos();
                MessageBox.Show("Professor salvo com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                professor.Materia = new Materias();
                DateTime dataAtual = DateTime.Now;
                int idade = CalcularIdadeProfessor(professor);
                string nome = this.nome.Text.Trim();

                professor.Nome = this.nome.Text;
                professor.Sexo = sexo.Text;
                professor.DataNasc = Convert.ToDateTime(this.dataNasc.Text);
                professor.Materia.Id = Convert.ToInt32(materia.SelectedValue);
                professor.Situacao = "Lecionando";

                if (string.IsNullOrWhiteSpace(this.nome.Text))
                {
                    MessageBox.Show("Nome do professor não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}\s'-]+|[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nome do professor deve conter apenas letras!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParse(dataNasc.Text, out DateTime dataNascimento))
                {
                    MessageBox.Show("Data de nascimento inválida.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DateTime dataAtual = DateTime.Now;
                int idade = dataAtual.Year - professor.DataNasc.Year;
                string nome = this.nome.Text.Trim();
                professorModel.AtualizarNaoLecionando(professor);

                MessageBox.Show("Professor atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o professor!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AtualizarLecionando(Professor professor)
        {
            try
            {
                DateTime dataAtual = DateTime.Now;
                int idade = dataAtual.Year - professor.DataNasc.Year;
                string nome = this.nome.Text.Trim();
                professorModel.AtualizarLecionando(professor);

                MessageBox.Show("Professor atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o professor!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void novoProfessor_Click(object sender, EventArgs e)
        {
            salvar.Enabled = true;
            editar.Enabled = false;
            AlterarLecionando.Enabled = false;
            AlterarNaoLecionando.Enabled = false;
            novo.Enabled = false;
            HabilitarCampos();
            LimparCampos();
        }
        private void salvarProfessor_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            salvar.Enabled = false;
            editar.Enabled = false;
            AlterarLecionando.Enabled = false;
            AlterarNaoLecionando.Enabled = false;
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
            AlterarLecionando.Enabled = false;
            AlterarNaoLecionando.Enabled = false;
            novo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar a situação do professor para 'Não lecionando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
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
            AlterarLecionando.Enabled = false;
            AlterarNaoLecionando.Enabled = false;
            novo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar a situação do professor para 'Lecionando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
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
