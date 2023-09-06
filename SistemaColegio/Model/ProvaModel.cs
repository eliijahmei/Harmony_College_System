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
        ////////////////////////////////////////////////////      ALUNO PROVA     ///////////////////////////////////////////////////////////////
        public List<double> NotasPorMateriaRa(int materia, int ra)
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
        public bool VerificarNumeroNotasPorProvaDeCadaAluno(Nota notas)
        {
            try
            {
                int numeroNotas;
                numeroNotas = provaDAO.ContarNumeroNotasPorProvaDeCadaAluno(notas);
                return numeroNotas >= 1;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ListarNotasPorRaMateria(int ra, int materia)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = provaDAO.ListarNotasPorRaMateria(ra, materia);
                return dt;
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
                if (VerificarNumeroNotasPorProvaDeCadaAluno(notas))
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
                return provaDAO.ReceberNotaProvaDoAlunoDaMateriaDoBimestre(aluno, idMateria, idBimestre);
            }
            catch
            {
                throw;
            }
        }
        ////////////////////////////////////////////////////         PROVA          ///////////////////////////////////////////////////////////////
        public bool VerificarNumeroDeProvasPorBimestreDaMateriaPorSala(Prova provas)
        {
            try
            {
                int numeroProvas;
                numeroProvas = provaDAO.ContarNumeroDeProvasPorBimestreDaMateriaPorSala(provas);
                return numeroProvas >= 1;
            }
            catch 
            {
                throw;
            }
        }
        public string MostrarBimestreDaProva(int id)
        {
            try
            {
                return provaDAO.MostrarBimestreDaProva(id);
            }
            catch
            {
                throw;
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
            catch
            {
                throw;
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
            catch 
            {
                throw;
            }
        }
        public void SalvarProva(Prova provas)
        {
            try
            {
                if (VerificarNumeroDeProvasPorBimestreDaMateriaPorSala(provas))
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
        ////////////////////////////////////////////////////        BIMETSRE         ///////////////////////////////////////////////////////////////
        public DataTable ListarBimestres()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = provaDAO.ListarBimestres();
                return dt;
            }
            catch 
            {
                throw;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
