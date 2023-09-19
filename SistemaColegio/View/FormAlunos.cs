using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace SistemaColegio.View
{
    public partial class FormAlunos : Form
    {

        ClassesModel classesModel = new ClassesModel();
        StatusModel statusModel = new StatusModel();
        AlunoModel alunoModel = new AlunoModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormAlunos()
        {
            InitializeComponent();
        }
        private void FormAlunos_Load(object sender, EventArgs e)
        {
            comboClasseFiltro.ValueMember = "ID";
            comboStatusFiltro.ValueMember = "ID";
            comboClasse.ValueMember = "ID";
            comboStatus.ValueMember = "ID";
            comboClasseFiltro.DisplayMember = "Classe";
            comboStatusFiltro.DisplayMember = "Status";
            comboClasse.DisplayMember = "Classe";
            comboStatus.DisplayMember = "Status";

            comboStatusFiltro.SelectedValue = 0;
            comboClasse.SelectedValue = 0;
            comboSexo.SelectedIndex = 0;

            comboStatusFiltro.DataSource = statusModel.ListarStatusAluno();
            comboClasseFiltro.DataSource = classesModel.ListarClasses();
            comboStatus.DataSource = statusModel.ListarStatusAluno();
            comboClasse.DataSource = classesModel.ListarClasses();

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
        public void KeyPressTXTra(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
        private void txtBuscarRa_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressTXTra(sender, e);
        }

        #endregion

        #region Eventos dos txt e combo changed.

        private void txtBuscarRa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PopulandoDgv();
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
                PopulandoDgv();
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
                PopulandoDgv();
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
                PopulandoDgv();
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
            comboStatus.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnNovo.Enabled = true;

            if (e.RowIndex < 0)
                return;

            txtRa.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            comboSexo.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            dtDataNasc.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            comboClasse.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            comboStatus.Text = dgv.CurrentRow.Cells[5].Value.ToString();

            HabilitarCampos();
        }
        public void PopulandoDgv()
        {
            if (comboClasseFiltro.Items.Count == 13 && comboStatusFiltro.Items.Count == 3)
            {
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dgv.EnableHeadersVisualStyles = false;
                dgv.AutoGenerateColumns = false;

                string ra = txtBuscarRa.Text;
                string nome = txtBuscarNome.Text;
                string classe = comboClasseFiltro.SelectedValue.ToString();
                string status = comboStatusFiltro.SelectedValue.ToString();

                //Atualiza a grid:
                if (txtBuscarRa.Text == "" && (txtBuscarNome.Text == "") && Convert.ToInt32(comboClasseFiltro.SelectedValue) == 0 && Convert.ToInt32(comboStatusFiltro.SelectedValue) == 0)
                {
                    dgv.DataSource = null;
                }
                else
                {
                    dgv.DataSource = alunoModel.ListarAlunos(ra, nome, classe, status);
                }
            }

        }
        #endregion

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

                btnSalvar.Enabled = false;

                DesabilitarCampos();
                LimparCampos();
                PopulandoDgv();
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

                aluno.Status = new StatusAluno();
                aluno.Classe = new Classe();

                DateTime dataNascimento = Convert.ToDateTime(dtDataNasc.Value.ToString());

                int idade = pessoa.CalcularIdade(dataNascimento);
                string nome = this.txtNome.Text.Trim();

                aluno.Nome = this.txtNome.Text;
                aluno.Sexo = comboSexo.Text;
                aluno.DataNasc = Convert.ToDateTime(this.dtDataNasc.Text);
                aluno.Classe.Id = Convert.ToInt32(comboClasse.SelectedValue);
                aluno.Status.Id = Convert.ToInt32(comboStatus.SelectedValue);

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

                PopulandoDgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao editar o aluno!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;

            LimparCampos();
            HabilitarCampos();
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
