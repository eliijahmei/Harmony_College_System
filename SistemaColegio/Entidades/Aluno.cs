using System;

namespace SistemaColegio.Entidades
{
    public class Aluno : Pessoa
    {
        private int _ra;
        private Classe _classe;

        public int Ra { get => _ra; set => _ra = value; }
        public Classe Classe { get => _classe; set => _classe = value; }

        public Aluno()
        {
        }

        public Aluno(int alunoRA, string nome) : base(nome)
        {
            this._ra = alunoRA;
        }

        public int CalcularIdade(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataAtual.Month < DataNasc.Month || (dataAtual.Month == DataNasc.Month && dataAtual.Day < DataNasc.Day))
            {
                idade--;
            }

            return idade;
        }
    }
}
