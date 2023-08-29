namespace SistemaColegio.Entidades
{
    public class Professor : Pessoa
    {
        private int id;
        private Materias materia;
        private string situacao;

        public int Id { get => id; set => id = value; }
        public Materias Materia { get => materia; set => materia = value; }
        public string Situacao { get => situacao; set => situacao = value; }
    }
}
