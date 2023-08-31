using SistemaColegio.DAO;
using System.Data;

namespace SistemaColegio.Model
{
    public class MateriasModel
    {
        MateriaDAO materiasDAO = new MateriaDAO();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarMateria()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = materiasDAO.ListarMaterias();
            }
            catch  
            {
                throw;
            }
            return dt;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
