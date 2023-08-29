using System;

namespace SistemaColegio.Entidades
{
    public class Pessoa
    {
        private string nome;
        private string sexo;
        private DateTime dataNasc;

        public Pessoa()
        {  
        }
        public Pessoa(string nome)
        {
            this.nome = nome;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public DateTime DataNasc { get => dataNasc; set => dataNasc = value; }
    }
}
