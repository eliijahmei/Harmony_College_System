using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
using System;

namespace SistemaColegio.Model
{
    public class AlunoModel
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarAlunos()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = alunoDAO.ListarAlunos();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Aluno AlunoPorRA(int alunoRA)
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno = alunoDAO.AlunoPorRA(alunoRA);
                return aluno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarRAPorsala(int classe) 
        {
            try
            {
                DataTable dt = new DataTable();
                dt = alunoDAO.ListarRAPorSala(classe);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarAlunosPorsala(int classe)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = alunoDAO.ListarAlunosPorSala(classe);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                alunoDAO.SalvarAluno(aluno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EditarAluno(Aluno aluno)
        {
            try
            {
                alunoDAO.EditarAluno(aluno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualizarNaoEstudando(Aluno aluno)
        {
            try
            {
                alunoDAO.AtualizarNaoEstudando(aluno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualizarEstudando(Aluno aluno)
        {
            try
            {
                alunoDAO.AtualizarEstudando(aluno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
