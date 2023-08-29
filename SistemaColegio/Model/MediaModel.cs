using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
using System;

namespace SistemaColegio.Model
{
    public class MediaModel
    {
        MediaDAO mediaDAO = new MediaDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool VerificarLimiteMedias(Medias medias)
        {
            try
            {
                int numeroProvas = mediaDAO.ContarMedias(medias);
                return numeroProvas >= 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarMedias(int ra)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = mediaDAO.ListarMedias(ra);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SalvarMedia(Medias medias)
        {
            try
            {
                if (VerificarLimiteMedias(medias))
                {
                    throw new Exception();
                }
                mediaDAO.SalvarMedia(medias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
