using System;

namespace SistemaColegio.Entidades
{
    public class Prova
    {
        private int id;
        private DateTime dataProva;
        private Materia materia;
        private Classe classe;
        private Bimestre bimestre;

        public int Id { get => id; set => id = value; }
        public DateTime DataProva { get => dataProva; set => dataProva = value; }
        public Materia Materia { get => materia; set => materia = value; }
        public Classe Classe { get => classe; set => classe = value; }
        public Bimestre Bimestre { get => bimestre; set => bimestre = value; }
    }
}
