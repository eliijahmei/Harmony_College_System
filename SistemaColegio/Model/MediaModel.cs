using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
using System;
using System.Collections.Generic;

namespace SistemaColegio.Model
{
    public class MediaModel
    {
        MediaDAO mediaDAO = new MediaDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<double> NotasMedia(int materia, int ra)
        {
            try
            {
                return mediaDAO.ObterNotasPorRaMateria(materia, ra);
            }
            catch
            {
                throw;
            }
        }
        public List<double> SituacaoAluno(int ra)
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
        public bool VerificarLimiteMedias(Media medias)
        {
            int numeroProvas;
            try
            {
                numeroProvas = mediaDAO.ContarMedias(medias);
            }
            catch 
            {
                throw;
            }
            return numeroProvas >= 1;
        }
        public DataTable ListarMedias(int ra)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = mediaDAO.ListarMedias(ra);
            }
            catch 
            {
                throw;
            }
            return dt;
        }
        public void SalvarMedia(Media medias)
        {
            try
            {
                if (VerificarLimiteMedias(medias))
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
