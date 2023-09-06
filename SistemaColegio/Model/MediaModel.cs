using System.Collections.Generic;
using SistemaColegio.DAO;
using System.Data;
using System;
using SistemaColegio.Entidades;

namespace SistemaColegio.Model
{
    public class MediaModel
    {
        MediaDAO mediaDAO = new MediaDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool VerificarSeAtingiuLimiteDeMedias(Media medias)
        {
            try
            {
                int quantidadeMedias;
                quantidadeMedias = mediaDAO.ContarNumeroDeMedias(medias);
                return quantidadeMedias >= 1;
            }
            catch
            {
                throw;
            }
        }
        public List<double> ObterMediasPorRa(int ra)
        {
            try
            {
                return mediaDAO.ObterMediasPorRa(ra);
            }
            catch
            {
                throw;
            }
        }
        public string ReceberNotaMedia(Aluno aluno, int idMateria)
        {
            try
            {
                return mediaDAO.ReceberNotaMedia(aluno, idMateria);
            }
            catch
            {
                throw;
            }
        }
        public DataTable ListarMediasPorRa(int ra)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = mediaDAO.ListarMediasPorRa(ra);
                return dt;
            }
            catch 
            {
                throw;
            }
        }
        public void SalvarMedia(Media medias)
        {
            try
            {
                if (VerificarSeAtingiuLimiteDeMedias(medias))
                {
                    throw new Exception();
                }
                mediaDAO.SalvarMedia(medias);
            }
            catch  
            {
                throw;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
