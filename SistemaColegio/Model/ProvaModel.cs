using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
using System;

namespace SistemaColegio.Model
{
    public class ProvaModel
    {
        ProvaDAO provaDAO = new ProvaDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool VerificarLimiteProvas(Provas provas)
        {
            try
            {
                int numeroProvas = provaDAO.ContarProvas(provas);
                return numeroProvas >= 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificarLimiteNotasPorProva(Notas notas)
        {
            try
            {
                int numeroNotas = provaDAO.ContarNotasPorProva(notas);
                return numeroNotas >= 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarProvasPorMateriaTurma(int materia, int turma)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = provaDAO.ListarProvasPorMateriaTurma(materia, turma);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarProvas()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = provaDAO.ListarProvas();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarBimestres()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = provaDAO.ListarBimestres();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ListarBimestre(int id)
        {
            try
            {
                return provaDAO.ListarBimestre(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarNotas(int ra, int materia)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = provaDAO.ListarNotas(ra, materia);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SalvarProva(Provas provas)
        {
            try
            {
                if (VerificarLimiteProvas(provas))
                {
                    throw new Exception();
                }
                provaDAO.SalvarProva(provas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EditarProva(Provas provas)
        {
            try
            {
                provaDAO.EditarProva(provas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExcluirProva(Provas provas)
        {
            try
            {
                provaDAO.ExcluirProva(provas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SalvarNota(Notas notas)
        {
            try
            {
                if (VerificarLimiteNotasPorProva(notas))
                {
                    throw new Exception();
                }
                provaDAO.SalvarNota(notas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EditarNota(Notas notas)
        {
            try
            {
                provaDAO.EditarNota(notas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExcluirNota(Notas notas)
        {
            try
            {
                provaDAO.ExcluirNota(notas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ReceberNotaProva(Aluno aluno, int idMateria, int idBimestre)
        {
            try
            {
                return provaDAO.ReceberNotaProva(aluno, idMateria, idBimestre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ReceberNotaMedia(Aluno aluno, int idMateria)
        {
            try
            {
                return provaDAO.ReceberNotaMedia(aluno, idMateria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
