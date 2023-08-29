using SistemaColegio.Entidades;
using SistemaColegio.DAO;
using System.Data;
using System;

namespace SistemaColegio.Model
{
    public class ProfessorModel
    {
        ProfessorDAO professorDAO = new ProfessorDAO();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarProfessores()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = professorDAO.ListarProfessores();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarProfessoresPorMateria(int professor)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = professorDAO.ListarProfessoresPorMateria(professor);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SalvarProfessor(Professor professor)
        {
            try
            {
                professorDAO.SalvarProfessor(professor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EditarProfessor(Professor professor)
        {
            try
            {
                professorDAO.EditarProfessor(professor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualizarNaoLecionando(Professor professor)
        {
            try
            {
                professorDAO.AtualizarNaoLecionando(professor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualizarLecionando(Professor professor)
        {
            try
            {
                professorDAO.AtualizarLecionando(professor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
