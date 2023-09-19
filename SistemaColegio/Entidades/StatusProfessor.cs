namespace SistemaColegio.Entidades
{
    internal class StatusProfessor
    {
        private int _id;
        private string _statusProfessor;

        public int Id { get => _id; set => _id = value; }
        public string SttProfessor { get => _statusProfessor; set => _statusProfessor = value; }
    }
}
