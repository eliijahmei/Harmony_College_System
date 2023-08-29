using SistemaColegio.DAO;
using System.Data;
using System;

namespace SistemaColegio.Model
{
    public class ClassesModel
    {
        ClassesDAO classesDAO = new ClassesDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarClasses()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = classesDAO.ListarClasses();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}

