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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormCadastroAluno()
        {
            InitializeComponent();
        }
        private void FormCadastroAluno_Load(object sender, System.EventArgs e)
        {
            comboSexo.SelectedIndex = 0;
            comboClasse.ValueMember = "ID";
            comboClasse.DisplayMember = "Classe";

            ListarAlunos();

            timer.Start();

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();

            comboClasse.DataSource = ListarClasses();
        }
        private void timerCadAlunos_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void HabilitarCampos()
        {
            txtNome.Enabled = true;
            comboSexo.Enabled = true;
            dtDataNasc.Enabled = true;
            comboClasse.Enabled = true;
        }
        public void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            comboSexo.Enabled = false;
            dtDataNasc.Enabled = false;
            comboClasse.Enabled = false;
        }
        public void LimparCampos()
        {
            txtRa.Text = "";
            txtNome.Text = "";
            comboSexo.SelectedIndex = 0;
            dtDataNasc.Value = DateTime.Now;
            comboClasse.SelectedIndex = 0;
            txtStatus.Text = "";
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
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dgv.DataSource = alunoModel.ListarAlunos();
                dgv.Columns[0].HeaderText = "RA";
                dgv.Columns[1].HeaderText = "Nome";
                dgv.Columns[2].HeaderText = "Sexo";
                dgv.Columns[3].HeaderText = "Data de Nascimento";
                dgv.Columns[4].HeaderText = "Classe";
                dgv.Columns[5].HeaderText = "Situação";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os alunos!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public DataTable ListarClasses()
        {
            try
            {
                return classesModel.ListarClasses();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar os alunos!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        private void gridCadAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnAlterarEstudando.Enabled = true;
            btnAlterarNaoEstudando.Enabled = true;
            btnNovo.Enabled = true;

            txtRa.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            comboSexo.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            dtDataNasc.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            comboClasse.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            txtStatus.Text = dgv.CurrentRow.Cells[5].Value.ToString();

            HabilitarCampos();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuscarAlunos(string ra)
        {
            try
            {
                dgv.DataSource = alunoModel.BuscarAlunosPorRA(ra);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar buscar os dados do aluno! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void buscarCadAluno_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                ListarAlunos();
                return;
            }
            BuscarAlunos(txtBuscar.Text);
        }
        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                aluno.Classe = new Classe();
                DateTime dataNascimento = Convert.ToDateTime(dtDataNasc.Value.ToString());
                int idade = aluno.CalcularIdade(dataNascimento);
                string nome = this.txtNome.Text.Trim();

                aluno.Nome = this.txtNome.Text;
                aluno.Sexo = comboSexo.Text;
                aluno.DataNasc = Convert.ToDateTime(this.dtDataNasc.Text);
                aluno.Classe.Id = Convert.ToInt32(comboClasse.SelectedValue);

                if (string.IsNullOrWhiteSpace(this.txtNome.Text))
                {
                    MessageBox.Show("Nome do aluno não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar o aluno!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EditarAluno(Aluno aluno)
        {
            try
            {
                aluno.Classe = new Classe();
                DateTime dataNascimento = Convert.ToDateTime(dtDataNasc.Value.ToString());
                int idade = aluno.CalcularIdade(dataNascimento);
                string nome = this.txtNome.Text.Trim();

                aluno.Nome = this.txtNome.Text;
                aluno.Sexo = comboSexo.Text;
                aluno.DataNasc = Convert.ToDateTime(this.dtDataNasc.Text);
                aluno.Classe.Id = Convert.ToInt32(comboClasse.SelectedValue);

                if (string.IsNullOrWhiteSpace(this.txtNome.Text))
                {
                    MessageBox.Show("Nome do aluno não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception)
            {
                MessageBox.Show("Erro ao editar o aluno!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AtualizarNaoEstudando(Aluno aluno)
        {
            try
            {
                alunoModel.AtualizarNaoEstudando(aluno);

                MessageBox.Show("Situação atualizada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao atualizar a situação!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AtualizarEstudando(Aluno aluno)
        {
            try
            {
                alunoModel.AtualizarEstudando(aluno);

                MessageBox.Show("Status atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao atualizar o status!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void novo_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnAlterarEstudando.Enabled = false;
            btnAlterarNaoEstudando.Enabled = false;
            btnNovo.Enabled = false;
            ListarAlunos();
            LimparCampos();
            HabilitarCampos();
        }
        private void salvarAluno_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnAlterarEstudando.Enabled = false;
            btnAlterarNaoEstudando.Enabled = false;
            btnNovo.Enabled = true;
            SalvarAluno(aluno);
            ListarAlunos();
            LimparCampos();
            DesabilitarCampos();
        }
        private void editarAluno_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnAlterarEstudando.Enabled = false;
            btnAlterarNaoEstudando.Enabled = false;
            btnNovo.Enabled = true;
            aluno.Ra = Convert.ToInt32(dgv.CurrentRow.Cells["RA"].Value);
            EditarAluno(aluno);
            ListarAlunos();
            LimparCampos();
            DesabilitarCampos();
        }
        private void btnAlterarEstudando_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnAlterarEstudando.Enabled = false;
            btnAlterarNaoEstudando.Enabled = false;
            btnNovo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar o status do aluno para 'Estudando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                DesabilitarCampos();
                return;
            }

            aluno.Ra = Convert.ToInt32(dgv.CurrentRow.Cells["RA"].Value);
            AtualizarEstudando(aluno);
            LimparCampos();
            ListarAlunos();
        }
        private void btnAlterarNaoEstudando_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnAlterarEstudando.Enabled = false;
            btnAlterarNaoEstudando.Enabled = false;
            btnNovo.Enabled = true;

            if (MessageBox.Show("Tem certeza que deseja atualizar o status do aluno para 'Não Estudando'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                LimparCampos();
                DesabilitarCampos();
                return;
            }

            aluno.Ra = Convert.ToInt32(dgv.CurrentRow.Cells["RA"].Value);
            AtualizarNaoEstudando(aluno);
            LimparCampos();
            ListarAlunos();
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
