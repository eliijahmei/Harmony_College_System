namespace SistemaColegio.Entidades
{
    public class StatusAluno
    {
        private int _id;
        private string _status;

        public string Status { get => _status; set => _status = value; }
        public int Id { get => _id; set => _id = value; }

        public override string ToString()
        {
            return _status;
        }
    }
}
