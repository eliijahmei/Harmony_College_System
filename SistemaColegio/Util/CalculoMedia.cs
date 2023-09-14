using System.Collections.Generic;
using System.Linq;

namespace SistemaColegio
{
    public class CalculoMedia
    {
        public double CalcularMedia(List<double> notas)
        {
            double media;
            double totalNotas = 0;
            int quantidadeNotas = notas.Count;
            const int qtdeNecessaria = 4;
            const int qtdeErradaDeNotasParaCalculo = 1;

            totalNotas += notas.Sum();

            if (quantidadeNotas == qtdeNecessaria)
            {
                media = totalNotas / quantidadeNotas;
            }
            else
            {
                media = qtdeErradaDeNotasParaCalculo;
            }
            return media;
        }
    }
}
