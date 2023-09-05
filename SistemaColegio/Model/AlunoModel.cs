using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;

namespace SistemaColegio.Model
{
    public class AlunoModel : PessoaModel
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Aluno AlunoPorRA(int alunoRA)
        {
            Aluno aluno = new Aluno();
            try
            {
                aluno = alunoDAO.AlunoPorRA(alunoRA);
            }
            catch
            {
                throw;
            }
            return aluno;
        }
        public DataTable Listar()
        {
            {
                DataTable dt = new DataTable();
                try
                {
                    dt = alunoDAO.ListarAlunos();
                }
                catch
                {
                    throw;
                }
                return dt;
            }
        }
        public DataTable ListarRAPorsala(int classe)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = alunoDAO.ListarRAPorSala(classe);
            }
            catch
            {
                throw;
            }
            return dt;
        }
        public DataTable ListarAlunosPorsala(int classe)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = alunoDAO.ListarAlunosPorSala(classe);
            }
            catch
            {
                throw;
            }
            return dt;
        }
        public DataTable BuscarAlunosPorRA(string ra)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = alunoDAO.BuscarAlunosPorRA(ra);
            }
            catch
            {
                throw;
            }
            return dt;
        }
        public void Create(Pessoa pessoa)
        {
            {
                try
                {
                    alunoDAO.SalvarAluno(pessoa as Aluno);
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Update(Pessoa pessoa)
        { 
            {
                try
                {
                    alunoDAO.EditarAluno(pessoa as Aluno);
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Offline(Pessoa pessoa)
        {
            try
            {
                alunoDAO.AtualizarNaoEstudando(pessoa as Aluno);
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
                alunoDAO.AtualizarEstudando(pessoa as Aluno);
            }
            catch
            {
                throw;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}