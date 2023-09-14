using System;

namespace SistemaColegio.Entidades
{
    public class Pessoa
    {
        private string _nome;
        private string _sexo;
        private DateTime _dataNasc;
        private string _status;

        public Pessoa()
        {  
        }
        public Pessoa(string nome)
        {
            this._nome = nome;
        }

        public string Nome { get => _nome; set => _nome = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public DateTime DataNasc { get => _dataNasc; set => _dataNasc = value; }
        public string Status { get => _status; set => _status = value; }

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
