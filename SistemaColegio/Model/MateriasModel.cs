using SistemaColegio.DAO;
using System.Data;
using System;

namespace SistemaColegio.Model
{
    public class MateriasModel
    {
        MateriasDAO materiasDAO = new MateriasDAO();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarMateria()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = materiasDAO.ListarMaterias();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
