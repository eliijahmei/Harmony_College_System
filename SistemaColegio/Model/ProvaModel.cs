using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
using System;
using System.Collections.Generic;

namespace SistemaColegio.Model
{
    public class ProvaModel
    {
        ProvaDAO provaDAO = new ProvaDAO();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<double> NotasMedia(int materia, int ra)
        {
            try
            {
                return provaDAO.PegaNotasPelaMateriaRa(materia, ra);
            }
            catch
            {
                throw;
            }
        }
        public bool VerificarLimiteProvas(Prova provas)
        {
            int numeroProvas;
            try
            {
                numeroProvas = provaDAO.ContarProvas(provas);
            }
            catch 
            {
                throw;
            }
            return numeroProvas >= 1;
        }
        public bool VerificarLimiteNotasPorProva(Nota notas)
        {
            int numeroNotas;
            try
            {
                numeroNotas = provaDAO.ContarNotasPorProva(notas);
            }
            catch
            {
                throw;
            }
            return numeroNotas >= 1;
        }
        public DataTable ListarProvasPorMateriaTurma(int materia, int turma)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = provaDAO.ListarProvasPorMateriaTurma(materia, turma);
            }
            catch 
            {
                throw;
            }
            return dt;
        }
        public DataTable ListarProvas()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = provaDAO.ListarProvas();
            }
            catch 
            {
                throw;
            }
            return dt;
        }
        public DataTable ListarBimestres()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = provaDAO.ListarBimestres();
            }
            catch 
            {
                throw;
            }
            return dt;
        }
        public string ListarBimestre(int id)
        {
            try
            {
                return provaDAO.ListarBimestre(id);
            }
            catch 
            {
                throw;
            }
        }
        public DataTable ListarNotas(int ra, int materia)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = provaDAO.ListarNotas(ra, materia);
            }
            catch
            {
                throw;
            }
            return dt;
        }
        public void SalvarProva(Prova provas)
        {
            try
            {
                if (VerificarLimiteProvas(provas))
                {
                    throw new Exception();
                }
                provaDAO.SalvarProva(provas);
            }
            catch 
            {
                throw;
            }
        }
        public void EditarProva(Prova provas)
        {
            try
            {
                provaDAO.EditarProva(provas);
            }
            catch
            {
                throw;
            }
        }
        public void ExcluirProva(Prova provas)
        {
            try
            {
                provaDAO.ExcluirProva(provas);
            }
            catch
            {
                throw;
            }
        }
        public void SalvarNota(Nota notas)
        {
            try
            {
                if (VerificarLimiteNotasPorProva(notas))
                {
                    throw new Exception();
                }
                provaDAO.SalvarNota(notas);
            }
            catch
            {
                throw;
            }
        }
        public void EditarNota(Nota notas)
        {
            try
            {
                provaDAO.EditarNota(notas);
            }
            catch 
            {
                throw;
            }
        }
        public void ExcluirNota(Nota notas)
        {
            try
            {
                provaDAO.ExcluirNota(notas);
            }
            catch 
            {
                throw;
            }
        }
        public string ReceberNotaProva(Aluno aluno, int idMateria, int idBimestre)
        {
            try
            {
                return provaDAO.ReceberNotaProva(aluno, idMateria, idBimestre);
            }
            catch
            {
                throw;
            }
        }
        public string ReceberNotaMedia(Aluno aluno, int idMateria)
        {
            try
            {
                return provaDAO.ReceberNotaMedia(aluno, idMateria);
            }
            catch
            {
                throw;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
