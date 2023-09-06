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
            try
            {
                DataTable dt = new DataTable();
                dt = classesDAO.ListarClasses();
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

