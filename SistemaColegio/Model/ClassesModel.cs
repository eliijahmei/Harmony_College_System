using SistemaColegio.DAO;
using System.Data;

namespace SistemaColegio.Model
{
    public class ClassesModel
    {
        ClasseDAO classesDAO = new ClasseDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarClasses()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = classesDAO.ListarClasses();
            }
            catch 
            {
                throw;
            }
            return dt;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}

