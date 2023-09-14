using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System;

namespace SistemaColegio.Model
{
    public class AlunoModel : PessoaModel
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        List<Aluno> alunos;
        public AlunoModel()
        {
            alunos = alunoDAO.ListaAlunos();
        }
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
        public List<Aluno> ListarAlunosPorRa(string ra)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra.ToString())).ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<Aluno> ListarAlunosPorNome(string nome)
        {
            try
            {
                return alunos.Where(aluno => aluno.Nome.Contains(nome)).ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<Aluno> ListarAlunosPorClasse(string classe)
        {
            try
            {
                return alunos.Where(aluno => aluno.Classe.ToString().Contains(classe.ToString())).ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<Aluno> ListarAlunosPorStatus(string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Status.Contains(status)).ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<Aluno> ListarAlunosPorRaStatus(string ra, string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Status.Contains(status) && aluno.Ra.ToString().Contains(ra)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
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

        #region CRUD

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

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}