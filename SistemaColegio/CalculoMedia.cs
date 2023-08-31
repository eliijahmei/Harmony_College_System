using System.Collections.Generic;
using System.Linq;

namespace SistemaColegio
{
    public class CalculoMedia
    {
        public double CalcularMedia(List<double> notas)
        {
            double media;
            double totalNotas;
            int quantidadeNotas = 4;

            totalNotas = notas.Sum();

            media = totalNotas / quantidadeNotas;

            return media;
        }
    }
}
