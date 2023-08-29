namespace SistemaColegio.Entidades
{
    public class Medias
    {
        private Aluno aluno;
        private Materias materia;
        private double media;

        public Aluno Aluno { get => aluno; set => aluno = value; }
        public Materias Materia { get => materia; set => materia = value; }
        public double Media { get => media; set => media = value; }
    }
}
