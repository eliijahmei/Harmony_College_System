using System;

namespace SistemaColegio.Entidades
{
    public class Aluno : Pessoa
    {
        private int _ra;
        private Classe _classe;
        private StatusAluno _status;

        public int Ra { get => _ra; set => _ra = value; }
        public Classe Classe { get => _classe; set => _classe = value; }
        public StatusAluno Status { get => _status; set => _status = value; }

        public Aluno()
        {
        }

        public Aluno(int alunoRA, string nome) : base(nome)
        {
            this._ra = alunoRA;
        }
    }
}
