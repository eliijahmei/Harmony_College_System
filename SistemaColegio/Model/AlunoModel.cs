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
        public DataTable ListarAlunos()
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
        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                alunoDAO.SalvarAluno(aluno);
            }
            catch  
            {
                throw;
            }
        }
        public void EditarAluno(Aluno aluno)
        {
            try
            {
                alunoDAO.EditarAluno(aluno);
            }
            catch  
            {
                throw;
            }
        }
        public void AtualizarNaoEstudando(Aluno aluno)
        {
            try
            {
                alunoDAO.AtualizarNaoEstudando(aluno);
            }
            catch  
            {
                throw;
            }
        }
        public void AtualizarEstudando(Aluno aluno)
        {
            try
            {
                alunoDAO.AtualizarEstudando(aluno);
            }
            catch 
            {
                throw;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
