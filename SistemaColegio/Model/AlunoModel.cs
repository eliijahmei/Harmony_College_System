using System.Collections.Generic;
using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
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

        #region Listagem por filtro.

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
                return alunos.Where(aluno => aluno.Classe.Id.ToString() == classe).ToList();
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
                return alunos.Where(aluno => aluno.Status.Id.ToString() == status).ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<Aluno> ListarAlunosPorRaNomeClasseStatus(string ra, string nome, string classe, string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra) && aluno.Nome.Contains(nome) && aluno.Classe.Id.ToString() == classe && aluno.Status.Id.ToString() == status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorRaNome(string ra, string nome)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra) && aluno.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorRaClasse(string ra, string classe)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra) && aluno.Classe.Id.ToString() == classe).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorRaStatus(string ra, string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra) && aluno.Status.Id.ToString() == status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorRaNomeStatus(string ra, string nome, string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra) && aluno.Nome.ToString().Contains(nome) && aluno.Status.Id.ToString() == status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorRaNomeClasse(string ra, string nome, string classe)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra) && aluno.Nome.ToString().Contains(nome) && aluno.Classe.Id.ToString() == classe).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorRaClasseStatus(string ra, string classe, string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Ra.ToString().Contains(ra) && aluno.Classe.Id.ToString() == classe && aluno.Status.Id.ToString() == status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorNomeClasse(string nome, string classe)
        {
            try
            {
                return alunos.Where(aluno => aluno.Nome.ToString().Contains(nome) && aluno.Classe.Id.ToString() == classe).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorNomeStatus(string nome, string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Nome.ToString().Contains(nome) && aluno.Status.Id.ToString() == status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorNomeClasseStatus(string nome, string classe, string status)
        {
            try
            {
                return alunos.Where(aluno => aluno.Nome.ToString().Contains(nome) && aluno.Classe.Id.ToString() == classe && aluno.Status.Id.ToString() == status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Aluno> ListarAlunosPorClasseStatus(string classe, string status)
        {
            try
            {
                var ClasseStatus = alunos.Where(aluno => aluno.Classe.Id.ToString() == classe && aluno.Status.Id.ToString() == status).ToList();
                return ClasseStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<Aluno> ListarAlunos(string ra, string nome, string classe, string status)
        {
            try
            {
                alunos = new List<Aluno>(alunoDAO.ListaAlunos());

                //Busca apenas por RA:
                if (!string.IsNullOrEmpty(ra) && string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) == 0 && Convert.ToInt32(status) == 0)
                {
                    return ListarAlunosPorRa(ra);
                }
                //Busca apenas por Nome:
                if (string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) == 0 && Convert.ToInt32(status) == 0)
                {
                    return ListarAlunosPorNome(nome);
                }
                //Busca apenas por Classe:
                if (string.IsNullOrEmpty(ra) && string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) == 0)
                {
                    return ListarAlunosPorClasse(classe);
                }
                //Busca apenas por Status:
                if (string.IsNullOrEmpty(ra) && string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) == 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorStatus(status);
                }
                //Busca por RA, Nome, Classe e Status:
                if (!string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorRaNomeClasseStatus(ra, nome, classe, status);
                }
                //Busca por RA e Nome:
                if (!string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) == 0 && Convert.ToInt32(status) == 0)
                {
                    return ListarAlunosPorRaNome(ra, nome);
                }
                //Busca por RA e Classe:
                if (!string.IsNullOrEmpty(ra) && string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) == 0)
                {
                    return ListarAlunosPorRaClasse(ra, classe);
                }
                //Busca por RA e Status:
                if (!string.IsNullOrEmpty(ra) && string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) == 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorRaStatus(ra, status);
                }
                //Busca por RA, Nome e Classe:
                if (!string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) == 0)
                {
                    return ListarAlunosPorRaNomeClasse(ra, nome, classe);
                }
                //Busca por RA, Nome e Status:
                if (!string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) == 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorRaNomeStatus(ra, nome, status);
                }
                //Busca por RA, Classe e Status:
                if (!string.IsNullOrEmpty(ra) && string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorRaClasseStatus(ra, classe, status);
                }
                //Busca por Nome e Classe:
                if (string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) == 0)
                {
                    return ListarAlunosPorNomeClasse(nome, classe);
                }
                //Busca por Nome e Status:
                if (string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) == 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorNomeStatus(nome, status);
                }
                //Busca por Nome, Classe e Status:
                 if (string.IsNullOrEmpty(ra) && !string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorNomeClasseStatus(nome, classe, status);
                }
                //Busca por Classe e Status:
                if (string.IsNullOrEmpty(ra) && string.IsNullOrEmpty(nome) && Convert.ToInt32(classe) != 0 && Convert.ToInt32(status) != 0)
                {
                    return ListarAlunosPorClasseStatus(classe, status);
                }

                return ListarAlunos(ra, nome, classe, status);
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