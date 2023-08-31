using System.Collections.Generic;
using SistemaColegio.Entidades;
using System.Linq;

public class Media
{
    private Aluno aluno;
    private Materia materia;
    private double mediaNotas;

    public Aluno Aluno { get => aluno; set => aluno = value; }
    public Materia Materia { get => materia; set => materia = value; }
    public double MediaNotas { get => mediaNotas; set => mediaNotas = value; }
}
