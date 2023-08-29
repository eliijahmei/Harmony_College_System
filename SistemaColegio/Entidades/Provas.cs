using System;

namespace SistemaColegio.Entidades
{
    public class Provas
    {
        private int id;
        private DateTime dataProva;
        private Materias materia;
        private Classes classe;
        private Bimestres bimestre;

        public int Id { get => id; set => id = value; }
        public DateTime DataProva { get => dataProva; set => dataProva = value; }
        public Materias Materia { get => materia; set => materia = value; }
        public Classes Classe { get => classe; set => classe = value; }
        public Bimestres Bimestre { get => bimestre; set => bimestre = value; }
    }
}
