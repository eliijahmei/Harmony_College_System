using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;

namespace SistemaColegio.Model
{
    public class ProfessorModel : PessoaModel
    {
        ProfessorDAO professorDAO = new ProfessorDAO();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable Listar()
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
        public void Create(Pessoa pessoa)
        {
            try
            {
                professorDAO.SalvarProfessor(pessoa as Professor);
            }
            catch  
            {
                throw;
            }
        }
        public void Update(Pessoa pessoa)
        {
            try
            {
                professorDAO.EditarProfessor(pessoa as Professor);
            }
            catch
            {
                throw;
            }
        }
        public void Offline(Pessoa pessoa)
        {
            try
            {
                professorDAO.AtualizarNaoLecionando(pessoa as Professor);
            }
            catch 
            {
                throw;
            }
        }
        public void Online(Pessoa pessoa)
        {
            try
            {
                professorDAO.AtualizarLecionando(pessoa as Professor);
            }
            catch 
            {
                throw;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
