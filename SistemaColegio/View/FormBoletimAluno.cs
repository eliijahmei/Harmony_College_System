using static SistemaColegio.Enums;
using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace SistemaColegio.View
{
    public partial class FormBoletimAluno : Form
    {
        Aluno aluno;
        ProvaModel provaModel = new ProvaModel();
        MediaModel mediaModel = new MediaModel();   
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormBoletimAluno(Entidades.Aluno aluno)
        {
            InitializeComponent();

            this.aluno = aluno;
        }
        private void FormBoletimAluno_Load(object sender, EventArgs e)
        {
            lblNome.Text = aluno.Nome;
            lblRa.Text = aluno.Ra.ToString();

            Artes();
            Biologia();
            EducacaoAmbiental();
            Educacaofisica();
            Filosofia();
            Fisica();
            Geografia();
            Historia();
            Ingles();
            Portugues();
            Matematica();
            Quimica();
            Saude();
            Sociologia();
            Situacao(aluno.Ra);
        }
        private void Situacao(int ra)
        {
            SituaçãoAluno media = new SituaçãoAluno();
            List<double> medias = new List<double>();
            ra = Convert.ToInt32(aluno.Ra);

            medias = mediaModel.ObterMediasPorRa(ra);

            string aprovacao = media.Situacao(medias);

            if (aprovacao == "Reprovado")
            {
                lblSituacao.ForeColor = System.Drawing.Color.Red;
            }
            if (aprovacao == "Aprovado")
            {
                lblSituacao.ForeColor = System.Drawing.Color.Green;
            }
            if (aprovacao == "Em Análise")
            {
                lblSituacao.ForeColor = System.Drawing.Color.Black;
            }

            lblSituacao.Text = aprovacao;
        }
        private void Artes()
        {
            try
            {
                lblN1Artes.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.ARTES, (int)Bimestres.PRIMEIRO);
                lblN2Artes.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.ARTES, (int)Bimestres.SEGUNDO);
                lblN3Artes.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.ARTES, (int)Bimestres.TERCEIRO);
                lblN4Artes.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.ARTES, (int)Bimestres.QUARTO);
                lblMediaArtes.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAARTES);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Artes!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Biologia()
        {
            try
            {
                lblN1Biologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.BIOLOGIA, (int)Bimestres.PRIMEIRO);
                lblN2Biologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.BIOLOGIA, (int)Bimestres.SEGUNDO);
                lblN3Biologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.BIOLOGIA, (int)Bimestres.TERCEIRO);
                lblN4Biologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.BIOLOGIA, (int)Bimestres.QUARTO);
                lblMediaBiologia.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIABIOLOGIA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Biologia!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void EducacaoAmbiental()
        {
            try
            {
                lblN1EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOAMBIENTAL, (int)Bimestres.PRIMEIRO);
                lblN2EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOAMBIENTAL, (int)Bimestres.SEGUNDO);
                lblN3EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOAMBIENTAL, (int)Bimestres.TERCEIRO);
                lblN4EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOAMBIENTAL, (int)Bimestres.QUARTO);
                lblMediaEdAmbiental.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAEDUCACAOAMBIENTAL);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Educação Ambiental!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Educacaofisica()
        {
            try
            {
                lblN1EdFisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOFISICA, (int)Bimestres.PRIMEIRO);
                lblN2EdFisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOFISICA, (int)Bimestres.SEGUNDO);
                lblN3EdFisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOFISICA, (int)Bimestres.TERCEIRO);
                lblN4EdFisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.EDUCACAOFISICA, (int)Bimestres.QUARTO);
                lblMediaEdFisica.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAEDUCACAOFISICA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Educação Física!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Filosofia()
        {
            try
            {
                lblN1Filosofia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FILOSOFIA, (int)Bimestres.PRIMEIRO);
                lblN2Filosofia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FILOSOFIA, (int)Bimestres.SEGUNDO);
                lblN3Filosofia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FILOSOFIA, (int)Bimestres.TERCEIRO);
                lblN4Filosofia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FILOSOFIA, (int)Bimestres.QUARTO);
                lblMediaFilosofia.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAFILOSOFIA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Filosofia!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Fisica()
        {
            try
            {
                lblN1Fisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FISICA, (int)Bimestres.PRIMEIRO);
                lblN2Fisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FISICA, (int)Bimestres.SEGUNDO);
                lblN3Fisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FISICA, (int)Bimestres.TERCEIRO);
                lblN4Fisica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.FISICA, (int)Bimestres.QUARTO);
                lblMediaFisica.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAFISICA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Física!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Geografia()
        {
            try
            {
                lblN1Geografia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.GEOGRAFIA, (int)Bimestres.PRIMEIRO);
                lblN2Geografia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.GEOGRAFIA, (int)Bimestres.SEGUNDO);
                lblN3Geografia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.GEOGRAFIA, (int)Bimestres.TERCEIRO);
                lblN4Geografia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.GEOGRAFIA, (int)Bimestres.QUARTO);
                lblMediaGeografia.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAGEOGRAFIA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Geografia!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Historia()
        {
            try
            {
                lblN1Historia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.HISTORIA, (int)Bimestres.PRIMEIRO);
                lblN2Historia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.HISTORIA, (int)Bimestres.SEGUNDO);
                lblN3Historia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.HISTORIA, (int)Bimestres.TERCEIRO);
                lblN4Historia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.HISTORIA, (int)Bimestres.QUARTO);
                lblMediaHistoria.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAHISTORIA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de História!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Ingles()
        {
            try
            {
                lblN1Ingles.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.INGLES, (int)Bimestres.PRIMEIRO);
                lblN2Ingles.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.INGLES, (int)Bimestres.SEGUNDO);
                lblN3Ingles.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.INGLES, (int)Bimestres.TERCEIRO);
                lblN4Ingles.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.INGLES, (int)Bimestres.QUARTO);
                lblMediaIngles.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAINGLES);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Inglês!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Portugues()
        {
            try
            {
                lblN1Portugues.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.PORTUGUES, (int)Bimestres.PRIMEIRO);
                lblN2Portugues.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.PORTUGUES, (int)Bimestres.SEGUNDO);
                lblN3Portugues.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.PORTUGUES, (int)Bimestres.TERCEIRO);
                lblN4Portugues.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.PORTUGUES, (int)Bimestres.QUARTO);
                lblMediaPortugues.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAPORTUGUES);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Português!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Matematica()
        {
            try
            {
                lblN1Matematica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.MATEMATICA, (int)Bimestres.PRIMEIRO);
                lblN2Matematica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.MATEMATICA, (int)Bimestres.SEGUNDO);
                lblN3Matematica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.MATEMATICA, (int)Bimestres.TERCEIRO);
                lblN4Matematica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.MATEMATICA, (int)Bimestres.QUARTO);
                lblMediaMatematica.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAMATEMATICA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Matemática!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Quimica()
        {
            try
            {
                lblN1Quimica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.QUIMICA, (int)Bimestres.PRIMEIRO);
                lblN2Quimica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.QUIMICA, (int)Bimestres.SEGUNDO);
                lblN3Quimica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.QUIMICA, (int)Bimestres.TERCEIRO);
                lblN4Quimica.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.QUIMICA, (int)Bimestres.QUARTO);
                lblMediaQuimica.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIAQUIMICA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Química!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Saude()
        {
            try
            {
                lblN1Saude.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SAUDE, (int)Bimestres.PRIMEIRO);
                lblN2Saude.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SAUDE, (int)Bimestres.SEGUNDO);
                lblN3Saude.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SAUDE, (int)Bimestres.TERCEIRO);
                lblN4Saude.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SAUDE, (int)Bimestres.QUARTO);
                lblMediaSaude.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIASAUDE);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Saúde!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Sociologia()
        {
            try
            {
                lblN1Sociologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SOCIOLOGIA, (int)Bimestres.PRIMEIRO);
                lblN2Sociologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SOCIOLOGIA, (int)Bimestres.SEGUNDO);
                lblN3Sociologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SOCIOLOGIA, (int)Bimestres.TERCEIRO);
                lblN4Sociologia.Text = provaModel.ReceberNotaProva(aluno, (int)Materias.SOCIOLOGIA, (int)Bimestres.QUARTO);
                lblMediaSociologia.Text = mediaModel.ReceberNotaMedia(aluno, (int)Medias.MEDIASOCIOLOGIA);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar as notas de Sociologia!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormBoletim form = new FormBoletim();
            form.Show();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
