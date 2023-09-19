using SistemaColegio.DAO;
using SistemaColegio.Entidades;
using System.Collections.Generic;
using System.Data;

namespace SistemaColegio.Model
{
    public class StatusModel
    {
        StatusDAO statusDAO = new StatusDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarStatusAluno()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = statusDAO.ListaStatusAluno();
                return dt;
            }
            catch
            {
                throw;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
