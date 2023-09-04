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

            totalNotas += notas.Sum();

            if (quantidadeNotas == 4)
            {
                media = totalNotas / quantidadeNotas;
            }
            else
            {
                media = -1;
            }
            return media;
        }
    }
}
