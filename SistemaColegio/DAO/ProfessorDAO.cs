using SistemaColegio.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace SistemaColegio.DAO
{
    public class ProfessorDAO
    {
        MySqlCommand cmd;
        Conexao conexao = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int GerarID()
        {
            try
            {
                List<int> ids = new List<int>();
                int id = 0;
                var idExiste = false;
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT p.ID FROM professor p WHERE ID = @ID", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(Convert.ToInt32(reader["ID"]));
                    }
                }
                do
                {
                    id = new Random().Next(1000, 9999);
                    idExiste = ids.Contains(id);
                } while (idExiste);
                return id;
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
        }
        public DataTable ListarProfessores()
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT p.ID, p.Nome, p.Sexo, p.DataNascimento, m.Materia, p.Situacao FROM professor p INNER JOIN materia m ON p.MateriaProf = m.ID ORDER BY m.ID ASC, Nome", conexao.conexao);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
        }
        public DataTable ListarProfessoresPorMateria(int professor)
        {
            DataTable dt = new DataTable();
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT ID, Nome FROM professor  WHERE MateriaProf = @MateriaID", conexao.conexao);
                cmd.Parameters.AddWithValue("@MateriaID", professor);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return dt;
        }
        public void SalvarProfessor(Professor professor)
        {
            int idProfessor = GerarID();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("INSERT INTO professor(ID, Nome, Sexo, DataNascimento, MateriaProf, Situacao) VALUES(@ID, @Nome, @Sexo, @DataNascimento, @MateriaProf, @Situacao)", con.con);
                cmd.Parameters.AddWithValue("@ID", idProfessor);
                cmd.Parameters.AddWithValue("@Nome", professor.Nome);
                cmd.Parameters.AddWithValue("@Sexo", professor.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", professor.DataNasc);
                cmd.Parameters.AddWithValue("@MateriaProf", professor.Materia.Id);
                cmd.Parameters.AddWithValue("@Situacao", "Lecionando");
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
        }
        public void EditarProfessor(Professor professor)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE professor SET Nome = @Nome, Sexo = @Sexo, DataNascimento = @DataNascimento, MateriaProf = @MateriaProf WHERE ID = @ID", con.con);
                {
                    cmd.Parameters.AddWithValue("@ID", professor.Id);
                    cmd.Parameters.AddWithValue("@Nome", professor.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", professor.Sexo);
                    cmd.Parameters.AddWithValue("@DataNascimento", professor.DataNasc);
                    cmd.Parameters.AddWithValue("@MateriaProf", professor.Materia.Id);
                    cmd.Parameters.AddWithValue("@Situacao", "Lecionando");
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
        }
        public void AtualizarNaoLecionando(Professor professor)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE professor SET Situacao = 'Não Lecionando' WHERE ID = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", professor.Id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
        }
        public void AtualizarLecionando(Professor professor)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE professor SET Situacao = 'Lecionando' WHERE ID = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", professor.Id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
