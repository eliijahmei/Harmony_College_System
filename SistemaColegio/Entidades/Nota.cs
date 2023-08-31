namespace SistemaColegio.Entidades
{
    public class Nota
    {
        private Aluno aluno;
        private Prova provas;
        private Professor professor;
        private Materia materia;
        private double nota;

        public Aluno Aluno { get => aluno; set => aluno = value; }
        public Prova Provas { get => provas; set => provas = value; }
        public Professor Professor { get => professor; set => professor = value; }
        public Materia Materia { get => materia; set => materia = value; }
        public double Notaa { get => nota; set => nota = value; }
    }
}
