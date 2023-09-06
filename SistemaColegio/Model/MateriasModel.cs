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
            try
            {
                DataTable dt = new DataTable();
                dt = materiasDAO.ListarMaterias();
                return dt;
            }
            catch  
            {
                throw;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
