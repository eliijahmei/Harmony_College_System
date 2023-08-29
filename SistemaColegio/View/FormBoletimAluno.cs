using SistemaColegio.Entidades;
using SistemaColegio.Model;
using System.Windows.Forms;
using System;

namespace SistemaColegio.View
{
    public partial class FormBoletimAluno : Form
    {
        Aluno aluno;
        ProvaModel provaModel = new ProvaModel();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FormBoletimAluno(Entidades.Aluno aluno)
        {
            InitializeComponent();
            this.aluno = aluno;
        }
        private void FormBoletimAluno_Load(object sender, EventArgs e)
        {
            NOME.Text = aluno.Nome;
            RA.Text = aluno.Ra.ToString();
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
        }
        private void Artes()
        {
            n1Artes.Text = provaModel.ReceberNotaProva(aluno, 1, 1);
            n2Artes.Text = provaModel.ReceberNotaProva(aluno, 1, 2);
            n3Artes.Text = provaModel.ReceberNotaProva(aluno, 1, 3);
            n4Artes.Text = provaModel.ReceberNotaProva(aluno, 1, 4);
            mediaArtes.Text = provaModel.ReceberNotaMedia(aluno, 1);

        }
        private void Biologia()
        {
            n1Biologia.Text = provaModel.ReceberNotaProva(aluno, 2, 1);
            n2Biologia.Text = provaModel.ReceberNotaProva(aluno, 2, 2);
            n3Biologia.Text = provaModel.ReceberNotaProva(aluno, 2, 3);
            n4Biologia.Text = provaModel.ReceberNotaProva(aluno, 2, 4);
            mediaBiologia.Text = provaModel.ReceberNotaMedia(aluno, 2);
        }
        private void EducacaoAmbiental()
        {
            n1EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, 3, 1);
            n2EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, 3, 2);
            n3EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, 3, 3);
            n4EdAmbiental.Text = provaModel.ReceberNotaProva(aluno, 3, 4);
            mediaEdAmbiental.Text = provaModel.ReceberNotaMedia(aluno, 3);
        }
        private void Educacaofisica()
        {
            n1EdFisica.Text = provaModel.ReceberNotaProva(aluno, 4, 1);
            n2EdFisica.Text = provaModel.ReceberNotaProva(aluno, 4, 2);
            n3EdFisica.Text = provaModel.ReceberNotaProva(aluno, 4, 3);
            n4EdFisica.Text = provaModel.ReceberNotaProva(aluno, 4, 4);
            mediaEdFisica.Text = provaModel.ReceberNotaMedia(aluno, 4);
        }
        private void Filosofia()
        {
            n1Filosofia.Text = provaModel.ReceberNotaProva(aluno, 5, 1);
            n2Filosofia.Text = provaModel.ReceberNotaProva(aluno, 5, 2);
            n3Filosofia.Text = provaModel.ReceberNotaProva(aluno, 5, 3);
            n4Filosofia.Text = provaModel.ReceberNotaProva(aluno, 5, 4);
            mediaFilosofia.Text = provaModel.ReceberNotaMedia(aluno, 5);
        }
        private void Fisica()
        {
            n1Fisica.Text = provaModel.ReceberNotaProva(aluno, 6, 1);
            n2Fisica.Text = provaModel.ReceberNotaProva(aluno, 6, 2);
            n3Fisica.Text = provaModel.ReceberNotaProva(aluno, 6, 3);
            n4Fisica.Text = provaModel.ReceberNotaProva(aluno, 6, 4);
            mediaFisica.Text = provaModel.ReceberNotaMedia(aluno, 6);
        }
        private void Geografia()
        {
            n1Geografia.Text = provaModel.ReceberNotaProva(aluno, 7, 1);
            n2Geografia.Text = provaModel.ReceberNotaProva(aluno, 7, 2);
            n3Geografia.Text = provaModel.ReceberNotaProva(aluno, 7, 3);
            n4Geografia.Text = provaModel.ReceberNotaProva(aluno, 7, 4);
            mediaGeografia.Text = provaModel.ReceberNotaMedia(aluno, 7);
        }
        private void Historia()
        {
            n1Historia.Text = provaModel.ReceberNotaProva(aluno, 8, 1);
            n2Historia.Text = provaModel.ReceberNotaProva(aluno, 8, 2);
            n3Historia.Text = provaModel.ReceberNotaProva(aluno, 8, 3);
            n4Historia.Text = provaModel.ReceberNotaProva(aluno, 8, 4);
            mediaHistoria.Text = provaModel.ReceberNotaMedia(aluno, 8);
        }
        private void Ingles()
        {
            n1Ingles.Text = provaModel.ReceberNotaProva(aluno, 9, 1);
            n2Ingles.Text = provaModel.ReceberNotaProva(aluno, 9, 2);
            n3Ingles.Text = provaModel.ReceberNotaProva(aluno, 9, 3);
            n4Ingles.Text = provaModel.ReceberNotaProva(aluno, 9, 4);
            mediaIngles.Text = provaModel.ReceberNotaMedia(aluno, 9);
        }
        private void Portugues()
        {
            n1Portugues.Text = provaModel.ReceberNotaProva(aluno, 10, 1);
            n2Portugues.Text = provaModel.ReceberNotaProva(aluno, 10, 2);
            n3Portugues.Text = provaModel.ReceberNotaProva(aluno, 10, 3);
            n4Portugues.Text = provaModel.ReceberNotaProva(aluno, 10, 4);
            mediaPortugues.Text = provaModel.ReceberNotaMedia(aluno, 10);
        }
        private void Matematica()
        {
            n1Matematica.Text = provaModel.ReceberNotaProva(aluno, 11, 1);
            n2Matematica.Text = provaModel.ReceberNotaProva(aluno, 11, 2);
            n3Matematica.Text = provaModel.ReceberNotaProva(aluno, 11, 3);
            n4Matematica.Text = provaModel.ReceberNotaProva(aluno, 11, 4);
            mediaMatematica.Text = provaModel.ReceberNotaMedia(aluno, 11);
        }
        private void Quimica()
        {
            n1Quimica.Text = provaModel.ReceberNotaProva(aluno, 12, 1);
            n2Quimica.Text = provaModel.ReceberNotaProva(aluno, 12, 2);
            n3Quimica.Text = provaModel.ReceberNotaProva(aluno, 12, 3);
            n4Quimica.Text = provaModel.ReceberNotaProva(aluno, 12, 4);
            mediaQuimica.Text = provaModel.ReceberNotaMedia(aluno, 12);
        }
        private void Saude()
        {
            n1Saude.Text = provaModel.ReceberNotaProva(aluno, 13, 1);
            n2Saude.Text = provaModel.ReceberNotaProva(aluno, 13, 2);
            n3Saude.Text = provaModel.ReceberNotaProva(aluno, 13, 3);
            n4Saude.Text = provaModel.ReceberNotaProva(aluno, 13, 4);
            mediaSaude.Text = provaModel.ReceberNotaMedia(aluno, 13);
        }
        private void Sociologia()
        {
            n1Sociologia.Text = provaModel.ReceberNotaProva(aluno, 14, 1);
            n2Sociologia.Text = provaModel.ReceberNotaProva(aluno, 14, 2);
            n3Sociologia.Text = provaModel.ReceberNotaProva(aluno, 14, 3);
            n4Sociologia.Text = provaModel.ReceberNotaProva(aluno, 14, 4);
            mediaSociologia.Text = provaModel.ReceberNotaMedia(aluno, 14);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormBoletim form = new FormBoletim();
            form.Show();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
