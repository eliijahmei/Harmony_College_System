using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;

namespace SistemaColegio.Model
{
    public class AlunoModel : PessoaModel
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Aluno PegaBoletimAlunoPorRa(int ra)
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno = alunoDAO.PegaBoletimAlunoPorRa(ra);
                return aluno;
            }
            catch
            {
                throw;
            }
        }
        public DataTable Listar()
        {
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = alunoDAO.ListarAlunos();
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }
        public DataTable ListarAlunosPorRa(int ra)
        {
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = alunoDAO.ListarAlunosPorRa(ra);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }

        public DataTable ListarAlunosPorClasseEstudando(int classe)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = alunoDAO.ListarAlunosPorClasseEstudando(classe);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ListarAlunosPorClasseSituacao(int classe, string situacao)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = alunoDAO.ListarAlunosPorClasseSituacao(classe, situacao);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public DataTable BuscarAlunosPorRA(string ra)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = alunoDAO.BuscarAlunosPorRA(ra);
                return dt;
            }
            catch
            {
                throw;
            }
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