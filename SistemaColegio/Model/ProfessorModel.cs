using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;

namespace SistemaColegio.Model
{
    public class ProfessorModel
    {
        ProfessorDAO professorDAO = new ProfessorDAO();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarProfessores()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = professorDAO.ListarProfessores();
            }
            catch  
            {
                throw;
            }
            return dt;
        }
        public DataTable ListarProfessoresPorMateria(int professor)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = professorDAO.ListarProfessoresPorMateria(professor);
            }
            catch  
            {
                throw;
            }
            return dt;
        }
        public void SalvarProfessor(Professor professor)
        {
            try
            {
                professorDAO.SalvarProfessor(professor);
            }
            catch  
            {
                throw;
            }
        }
        public void EditarProfessor(Professor professor)
        {
            try
            {
                professorDAO.EditarProfessor(professor);
            }
            catch
            {
                throw;
            }
        }
        public void AtualizarNaoLecionando(Professor professor)
        {
            try
            {
                professorDAO.AtualizarNaoLecionando(professor);
            }
            catch 
            {
                throw;
            }
        }
        public void AtualizarLecionando(Professor professor)
        {
            try
            {
                professorDAO.AtualizarLecionando(professor);
            }
            catch 
            {
                throw;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
