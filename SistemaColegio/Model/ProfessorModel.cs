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
            try
            {
                DataTable dt = new DataTable();
                dt = professorDAO.ListarProfessores();
                return dt;
            }
            catch  
            {
                throw;
            }
        }
        public DataTable ListarProfessoresPorMateria(int materia)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = professorDAO.ListarProfessoresPorMateria(materia);
                return dt;
            }
            catch  
            {
                throw;
            }
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
