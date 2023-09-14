using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Data;
using SistemaColegio.Entidades;

namespace SistemaColegio.View
{
    public partial class FormAlunos : Form
    {
        AlunoModel alunoModel = new AlunoModel();
        ClassesModel classesModel = new ClassesModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormAlunos()
        {
            InitializeComponent();
        }
        private void FormAlunos_Load(object sender, EventArgs e)
        {
            comboSexo.SelectedIndex = 0;
            comboStatusFiltro.SelectedIndex = 0;
            comboStatus.SelectedIndex = 0;
            comboClasse.ValueMember = "ID";
            comboClasse.DisplayMember = "Classe";
            comboClasseFiltro.ValueMember = "ID";
            comboClasseFiltro.DisplayMember = "Classe";
            comboClasse.DataSource = ListarClasses();
            comboClasseFiltro.DataSource = ListarClasses();

            PopulandoDgv();

            timer.Start();

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region Funções Habilitar, Desabilitar e Limpar os campos.
        public void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            comboSexo.Enabled = false;
            dtDataNasc.Enabled = false;
            comboClasse.Enabled = false;
            comboStatus.Enabled = false;
        }
        public void HabilitarCampos()
        {
            txtNome.Enabled = true;
            comboSexo.Enabled = true;
            dtDataNasc.Enabled = true;
            comboClasse.Enabled = true;
        }
        public void LimparCampos()
        {
            txtRa.Text = "";
            txtNome.Text = "";
            comboSexo.SelectedIndex = 0;
            dtDataNasc.Value = DateTime.Now;
            comboClasse.SelectedIndex = 0;
            comboStatus.Text = "";
        }
        #endregion

        #region Evento KeyPress

        public void KeyPressTXT(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressTXT(sender, e);
        }
        private void txtBuscarNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressTXT(sender, e);
        }

        #endregion

        #region Eventos dos txt e combo changed.

        private void txtBuscarRa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroDgv();
            }
            catch
            {
                MessageBox.Show("Não foi possível listar os alunos buscando pelo RA!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroDgv();
            }
            catch
            {
                MessageBox.Show("Não foi possível listar os alunos buscando pelo nome!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboClasseFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroDgv();
            }
            catch
            {
                MessageBox.Show("Não foi possível listar os alunos buscando pela classe!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboStatusFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroDgv();
            }
            catch
            {
                MessageBox.Show("Não foi possível listar os alunos buscando pelo status!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region dgv.

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnNovo.Enabled = true;

            if (e.RowIndex < 0)
                return;

            HabilitarCampos();
            comboStatus.Enabled = true;

            txtRa.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            comboSexo.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            dtDataNasc.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            comboClasse.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            comboStatus.Text = dgv.CurrentRow.Cells[5].Value.ToString();

            if (e.RowIndex < 0)
                return;
        }
        public void PopulandoDgv()
        {
            dgv.AutoGenerateColumns = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;

            dgv.Columns[0].HeaderText = "RA";
            dgv.Columns[1].HeaderText = "Nome";
            dgv.Columns[2].HeaderText = "Sexo";
            dgv.Columns[3].HeaderText = "Data de Nascimento";
        }
        public void FiltroDgv()
        {
            //Busca apenas por RA:
            if (!(txtBuscarRa.Text == "") && (txtBuscarNome.Text == "") && Convert.ToInt32(comboClasseFiltro.SelectedValue) == 0 && comboStatusFiltro.SelectedIndex == 0)
            {
                string ra = txtBuscarRa.Text;
                dgv.DataSource = alunoModel.ListarAlunosPorRa(ra);
            }
            //Busca apenas por Nome:
            if (!(txtBuscarNome.Text == "") && (txtBuscarRa.Text == "") && Convert.ToInt32(comboClasseFiltro.SelectedValue) == 0 && comboStatusFiltro.SelectedIndex == 0)
            {
                string nome = txtBuscarNome.Text;
                dgv.DataSource = alunoModel.ListarAlunosPorNome(nome);
            }
            //Busca apenas por Classe:
            if (!(Convert.ToInt32(comboClasseFiltro.SelectedValue) == 0) && txtBuscarRa.Text == "" && txtBuscarNome.Text == "" && comboStatusFiltro.SelectedIndex == 0)
            {
                string classe = comboClasse.SelectedValue.ToString();
                dgv.DataSource = alunoModel.ListarAlunosPorClasse(classe);
            }
            //Busca apenas por Status:
            if (!(comboStatusFiltro.SelectedIndex == 0) && txtBuscarRa.Text == "" && txtBuscarNome.Text == "" && Convert.ToInt32(comboClasseFiltro.SelectedValue) == 0)
            {
                string status = comboStatusFiltro.Text;
                dgv.DataSource = alunoModel.ListarAlunosPorStatus(status);
            }
            //Busca por RA e Status:
            if (!(txtBuscarRa.Text == "") && !(comboStatusFiltro.SelectedIndex == 0) && (txtBuscarNome.Text == "") && Convert.ToInt32(comboClasseFiltro.SelectedValue) == 0)
            {
                string ra = txtBuscarRa.Text;
                string status = comboStatusFiltro.SelectedIndex.ToString();
                dgv.DataSource = alunoModel.ListarAlunosPorRaStatus(ra, status);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////     
        public DataTable ListarClasses()
        {
            try
            {
                return classesModel.ListarClasses();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as classes!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                aluno.Classe = new Classe();

                DateTime dataNascimento = Convert.ToDateTime(dtDataNasc.Value.ToString());

                int idade = pessoa.CalcularIdade(dataNascimento);

                string nome = txtNome.Text.Trim();

                aluno.Nome = txtNome.Text;
                aluno.Sexo = comboSexo.Text;
                aluno.DataNasc = Convert.ToDateTime(dtDataNasc.Text);
                aluno.Classe.Id = Convert.ToInt32(comboClasse.SelectedValue);

                if (Convert.ToInt32(comboClasse.SelectedValue) == 0)
                {
                    MessageBox.Show("A sala não pode estar vazia!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Nome do aluno não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboSexo.SelectedIndex == 0)
                {
                    MessageBox.Show("O sexo não pode ser vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (idade < 13 || idade > 21)
                {
                    MessageBox.Show("O aluno deve ter entre 13 e 21 anos de idade.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alunoModel.Create(aluno);

                MessageBox.Show("Aluno salvo com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                DesabilitarCampos();
                btnSalvar.Enabled = false;
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
                Pessoa pessoa = new Pessoa();
                aluno.Classe = new Classe();

                DateTime dataNascimento = Convert.ToDateTime(dtDataNasc.Value.ToString());

                int idade = pessoa.CalcularIdade(dataNascimento);

                string nome = this.txtNome.Text.Trim();

                aluno.Nome = this.txtNome.Text;
                aluno.Sexo = comboSexo.Text;
                aluno.DataNasc = Convert.ToDateTime(this.dtDataNasc.Text);
                aluno.Classe.Id = Convert.ToInt32(comboClasse.SelectedValue);
                aluno.Status = comboStatus.Text;

                if (Convert.ToInt32(comboClasse.SelectedValue) == 0)
                {
                    MessageBox.Show("Selecione a sala do aluno!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.txtNome.Text))
                {
                    MessageBox.Show("Nome do aluno não pode estar vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboSexo.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione o sexo do aluno!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (idade < 13 || idade > 21)
                {
                    MessageBox.Show("O aluno deve ter entre 13 e 21 anos de idade.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboStatus.SelectedIndex == 0)
                {
                    MessageBox.Show("selecione o status do aluno!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alunoModel.Update(aluno);
                MessageBox.Show("Aluno editado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao editar o aluno!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnNovo.Enabled = false;

            HabilitarCampos();
            LimparCampos();
            PopulandoDgv();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            btnEditar.Enabled = false;
            btnNovo.Enabled = true;

            SalvarAluno(aluno);
            PopulandoDgv();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnNovo.Enabled = true;

            aluno.Ra = Convert.ToInt32(dgv.CurrentRow.Cells["RA"].Value);

            EditarAluno(aluno);
            PopulandoDgv();
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
