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
    }
}
