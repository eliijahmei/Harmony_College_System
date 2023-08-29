using System.Text.RegularExpressions;
using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System;

namespace SistemaColegio.View
{
    public partial class FormCadastroAluno : Form
    {
        AlunoModel alunoModel = new AlunoModel();
        ClassesModel classesModel = new ClassesModel();
        int anoAtual = DateTime.Now.Year;
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormCadastroAluno()
        {
            InitializeComponent();
        }
        private void FormCadastroAluno_Load(object sender, System.EventArgs e)
        {
            sexo.SelectedIndex = 0;
            classe.ValueMember = "ID";
            classe.DisplayMember = "Classe";
            ListarAlunos();
            timerCadAlunos.Start();
            hora.Text = DateTime.Now.ToLongTimeString();
            data.Text = DateTime.Now.ToLongDateString();
            classe.DataSource = ListarClasses();
        }
        private void timerCadAlunos_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void HabilitarCampos()
        {
            nome.Enabled = true;
            sexo.Enabled = true;
            dataNasc.Enabled = true;
            classe.Enabled = true;
        }
        public void DesabilitarCampos()
        {
            nome.Enabled = false;
            sexo.Enabled = false;
            dataNasc.Enabled = false;
            classe.Enabled = false;
        }
        public void LimparCampos()
        {
            ra.Text = "";
            nome.Text = "";
            sexo.SelectedIndex = 0;
            dataNasc.Value = DateTime.Now;
            classe.SelectedIndex = 0;
            situacao.Text = "";
        }
        public int CalcularIdadeAluno(Aluno aluno)
        {
            int idade = anoAtual - dataNasc.Value.Year;
            return idade;
        }
        private void nomeAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListarAlunos()
        {
            try
            {
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                grid.DataSource = alunoModel.ListarAlunos();
                grid.Columns[0].HeaderText = "RA";
                grid.Columns[1].HeaderText = "Nome";
                grid.Columns[2].HeaderText = "Sexo";
                grid.Columns[3].HeaderText = "Data de Nascimento";
                grid.Columns[4].HeaderText = "Classe";
                grid.Columns[5].HeaderText = "Situação";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public DataTable ListarClasses()
        {
            try
            {
                return classesModel.ListarClasses();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void gridCadAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            salvar.Enabled = false;
            editar.Enabled = true;
            AlterarEstudando.Enabled = true;
            AlterarNaoEstudando.Enabled = true;
            novo.Enabled = true;
            ra.Text = grid.CurrentRow.Cells[0].Value.ToString();
            nome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            sexo.Text = grid.CurrentRow.Cells[2].Value.ToString();
            dataNasc.Text = grid.CurrentRow.Cells[3].Value.ToString();
            classe.Text = grid.CurrentRow.Cells[4].Value.ToString();
            situacao.Text = grid.CurrentRow.Cells[5].Value.ToString();
            HabilitarCampos();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuscarAlunos(string ra)
        {
            try
            {
                grid.DataSource = alunoModel.BuscarAlunosPorRA(ra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buscarCadAluno_TextChanged(object sender, EventArgs e)
        {
            if (buscar.Text == "")
            {
                ListarAlunos();
                return;
            }
            BuscarAlunos(buscar.Text);
        }
        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                aluno.Classe = new Classes();
                DateTime dataAtual = DateTime.Now;
                int idade = CalcularIdadeAluno(aluno);
                string nome = this.nome.Text.Trim();

                aluno.Nome = this.nome.Text;
                aluno.Sexo = sexo.Text;
                aluno.DataNasc = Convert.ToDateTime(this.dataNasc.Text);
                aluno.Classe.Id = Convert.ToInt32(classe.SelectedValue);

                if (string.IsNullOrWhiteSpace(this.nome.Text))
                {
                    MessageBox.Show("Nome do aluno não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}\s'-]+|[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nome do aluno deve conter apenas letras!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParse(dataNasc.Text, out DateTime dataNascimento))
                {
                    MessageBox.Show("Data de nascimento inválida.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (idade < 13 || idade > 21)
                {
                    MessageBox.Show("O aluno deve ter entre 13 e 21 anos de idade.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alunoModel.SalvarAluno(aluno);
                MessageBox.Show("Aluno salvo com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o aluno! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EditarAluno(Aluno aluno)
        {
            try
            {
                aluno.Classe = new Classes();
                DateTime dataAtual = DateTime.Now;
                int idade = CalcularIdadeAluno(aluno);
                string nome = this.nome.Text.Trim();

                aluno.Nome = this.nome.Text;
                aluno.Sexo = sexo.Text;
                aluno.DataNasc = Convert.ToDateTime(this.dataNasc.Text);
                aluno.Classe.Id = Convert.ToInt32(classe.SelectedValue);

                if (string.IsNullOrWhiteSpace(this.nome.Text))
                {
                    MessageBox.Show("Nome do aluno não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}\s'-]+|[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nome do aluno deve conter apenas letras!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParse(dataNasc.Text, out DateTime dataNascimento))
                {
                    MessageBox.Show("Data de nascimento inválida.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (idade < 13 || idade > 21)
                {
                    MessageBox.Show("O aluno deve ter entre 13 e 21 anos de idade.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alunoModel.EditarAluno(aluno);
                MessageBox.Show("Aluno editado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar o aluno! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AtualizarNaoEstudando(Aluno aluno)
        {
            try
            {
                DateTime dataAtual = DateTime.Now;
                int idade = dataAtual.Year - aluno.DataNasc.Year;
                string nome = this.nome.Text.Trim();
                alunoModel.AtualizarNaoEstudando(aluno);

                MessageBox.Show("Aluno atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o aluno!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AtualizarEstudando(Aluno aluno)
        {
            try
            {
                DateTime dataAtual = DateTime.Now;
                int idade = dataAtual.Year - aluno.DataNasc.Year;
                string nome = this.nome.Text.Trim();
                alunoModel.AtualizarEstudando(aluno);

                MessageBox.Show("Aluno atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o aluno!  " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void novo_Click(object sender, EventArgs e)
        {
            salvar.Enabled = true;
            editar.Enabled = false;
            AlterarEstudando.Enabled = false;
            AlterarNaoEstudando.Enabled = false;
            novo.Enabled = false;
            ListarAlunos();
            LimparCampos();
            HabilitarCampos();
        }
        private void salvarAluno_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            salvar.Enabled = false;
            editar.Enabled = false;
            AlterarEstudando.Enabled = false;
            AlterarNaoEstudando.Enabled = false;
            novo.Enabled = true;
            SalvarAluno(aluno);
            ListarAlunos();
            LimparCampos();
            DesabilitarCampos();
        }
        private void editarAluno_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            salvar.Enabled = false;
            editar.Enabled = false;
            AlterarEstudando.Enabled = false;
            AlterarNaoEstudando.Enabled = false;
            novo.Enabled = true;
            aluno.Ra = Convert.ToInt32(grid.CurrentRow.Cells["RA"].Value);
            EditarAluno(aluno);
            ListarAlunos();
            LimparCampos();
        }
        private void AlterarEstudando_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            salvar.Enabled = false;
            editar.Enabled = false;
            AlterarEstudando.Enabled = false;
            AlterarNaoEstudando.Enabled = false;
            novo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar a situação do aluno para 'Estudando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                DesabilitarCampos();
                return;
            }

            aluno.Ra = Convert.ToInt32(grid.CurrentRow.Cells["RA"].Value);
            AtualizarEstudando(aluno);
            LimparCampos();
            ListarAlunos();
        }
        private void AlterarNaoEstudando_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            salvar.Enabled = false;
            editar.Enabled = false;
            AlterarEstudando.Enabled = false;
            AlterarNaoEstudando.Enabled = false;
            novo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar a situação do aluno para 'Não Estudando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                DesabilitarCampos();
                return;
            }

            aluno.Ra = Convert.ToInt32(grid.CurrentRow.Cells["RA"].Value);
            AtualizarNaoEstudando(aluno);
            LimparCampos();
            ListarAlunos();
        }
        private void buscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A busca é feita por RA.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
