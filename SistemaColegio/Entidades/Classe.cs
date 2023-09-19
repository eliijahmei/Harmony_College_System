namespace SistemaColegio.Entidades
{
    public class Classe
    {
        private int id;
        private string classe;

        public string Classee { get => classe; set => classe = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return classe;
        }
    }
}
