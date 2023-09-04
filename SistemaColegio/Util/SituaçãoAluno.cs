using System.Collections.Generic;

namespace SistemaColegio
{
    public class SituaçãoAluno
    {
        public string Situacao(List<double> medias)
        {
            int count = 0;
            int quantidadeMedias = medias.Count;

            if (quantidadeMedias < 14)
            {
                return "Em Análise";
            }

            foreach(double media in medias)
            {
                if (media < 6)
                {
                    count++;
                }
            }
            if (count >= 5)
            {
                return "Reprovado";
            }
            return "Aprovado";
        }
    }
}
