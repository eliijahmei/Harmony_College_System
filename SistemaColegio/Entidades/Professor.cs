using System;

namespace SistemaColegio.Entidades
{
    public class Professor : Pessoa
    {
        private int id;
        private Materia materia;
        private string situacao;

        public int Id { get => id; set => id = value; }
        public Materia Materia { get => materia; set => materia = value; }
        public string Situacao { get => situacao; set => situacao = value; }

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
