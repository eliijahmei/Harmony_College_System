namespace SistemaColegio.Entidades
{
    public class Aluno : Pessoa
    {
        private int ra;
        private Classes classe;

        public Aluno()
        {
        }

        public Aluno(int alunoRA, string nome) : base(nome)
        {
            this.ra = alunoRA;
        }

        public int Ra { get => ra; set => ra = value; }
        public Classes Classe { get => classe; set => classe = value; }
    }
}
