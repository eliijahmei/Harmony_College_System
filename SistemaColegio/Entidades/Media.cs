using SistemaColegio.Entidades;
using System.Collections.Generic;
using System.Linq;

public class Media
{
    private Aluno aluno;
    private Materia materia;
    private double media;

    public Aluno Aluno { get => aluno; set => aluno = value; }
    public Materia Materia { get => materia; set => materia = value; }
    public double Mediaa { get => media; set => media = value; }

    public double CalcularMedia(List <double> notas)
    {
        double totalNotas = 0;
        int quantidadeNotas = 0;

        totalNotas = notas.Sum();

        if (quantidadeNotas == 4)
        {
            Mediaa = totalNotas / quantidadeNotas;
        }
        else
        {
            Mediaa = -1;
        }
        return Mediaa;
    }
}
