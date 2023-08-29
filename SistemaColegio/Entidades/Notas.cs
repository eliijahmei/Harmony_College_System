namespace SistemaColegio.Entidades
{
    public class Notas
    {
        private Aluno aluno;
        private Provas provas;
        private Professor professor;
        private Materias materia;
        private double nota;

        public Aluno Aluno { get => aluno; set => aluno = value; }
        public Provas Provas { get => provas; set => provas = value; }
        public Professor Professor { get => professor; set => professor = value; }
        public Materias Materia { get => materia; set => materia = value; }
        public double Nota { get => nota; set => nota = value; }
    }
}
