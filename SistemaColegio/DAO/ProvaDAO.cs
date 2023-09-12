using System.Collections.Generic;
using SistemaColegio.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class ProvaDAO
    {
        MySqlCommand cmd;
        Conexao conexao = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////      ALUNO PROVA     ///////////////////////////////////////////////////////////////
        public List<double> PegaNotasPelaMateriaRa(int materia, int ra)
        {
            try
            {
                List<double> notas = new List<double>();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT Nota FROM alunoprova WHERE Materia = @Materia AND RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@Materia", materia);
                cmd.Parameters.AddWithValue("@RA", ra);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notas.Add(Convert.ToDouble(reader["Nota"]));
                    }
                }
                return notas;
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
        public int ContarNumeroNotasPorProvaDeCadaAluno(Nota notas)
        {
            try
            {
                int numeroNota = 0;
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT COUNT(*) FROM alunoProva ap WHERE ap.ID = @ID AND ap.RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", notas.Provas.Id);
                cmd.Parameters.AddWithValue("@RA", notas.Aluno.Ra);
                numeroNota = Convert.ToInt32(cmd.ExecuteScalar());
                return numeroNota;
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
        public DataTable ListarNotasPorRaMateria(int ra, int materia)
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT ap.RA, p.ID, ap.Nota, ap.Professor, ap.Materia FROM alunoProva ap INNER JOIN prova p ON ap.ID = p.ID WHERE ap.Materia = @Materia AND ap.RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@Materia", materia);
                cmd.Parameters.AddWithValue("@RA", ra);
                MySqlDataAdapter dta = new MySqlDataAdapter();
                dta.SelectCommand = cmd;
                dta.Fill(dt);
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
        public void SalvarNota(Nota notas)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("INSERT INTO alunoProva(RA, ID, Nota, Professor, Materia) VALUES(@RA, @ID, @Nota, @Professor, @Materia)", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", notas.Aluno.Ra);
                cmd.Parameters.AddWithValue("@ID", notas.Provas.Id);
                cmd.Parameters.AddWithValue("@Nota", notas.Notaa);
                cmd.Parameters.AddWithValue("@Professor", notas.Professor.Id);
                cmd.Parameters.AddWithValue("@Materia", notas.Materia.Id);
                cmd.ExecuteNonQuery();
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
        public void EditarNota(Nota notas)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("UPDATE alunoProva SET Professor = @Professor, Nota = @Nota WHERE ID = @ID", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", notas.Aluno.Ra);
                cmd.Parameters.AddWithValue("@ID", notas.Provas.Id);
                cmd.Parameters.AddWithValue("@Nota", notas.Notaa);
                cmd.Parameters.AddWithValue("@Professor", notas.Professor.Id);
                cmd.ExecuteNonQuery();
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
        public void ExcluirNota(Nota notas)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("DELETE FROM alunoProva WHERE ID = @ID", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", notas.Provas.Id);
                cmd.ExecuteNonQuery();
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
        public string ReceberNotaProvaDoAlunoDaMateriaDoBimestre(Aluno aluno, int idMateria, int idBimestre)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT ap.Nota FROM alunoprova ap JOIN prova p ON p.ID = ap.ID WHERE ap.RA = @aluno AND p.Materia = @materia AND p.Bimestre = @bimestre;", conexao.conexao);
                cmd.Parameters.AddWithValue("@aluno", aluno.Ra);
                cmd.Parameters.AddWithValue("@materia", idMateria);
                cmd.Parameters.AddWithValue("@bimestre", idBimestre);
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return null;
        }
        ////////////////////////////////////////////////////         PROVA          ///////////////////////////////////////////////////////////////
        public int ContarNumeroDeProvasPorBimestreDaMateriaPorSala(Prova prova)
        {
            try
            {
                int quantidadeProvas = 0;
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT COUNT(*) FROM prova p WHERE p.Materia = @Materia AND p.Classe = @Classe AND p.Bimestre = @Bimestre", conexao.conexao);
                cmd.Parameters.AddWithValue("@Materia", prova.Materia.Id);
                cmd.Parameters.AddWithValue("@Classe", prova.Classe.Id);
                cmd.Parameters.AddWithValue("@Bimestre", prova.Bimestre.Id);
                quantidadeProvas = Convert.ToInt32(cmd.ExecuteScalar());
                return quantidadeProvas;
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

        public int GerarID()
        {
            try
            {
                List<int> ids = new List<int>();
                int id = 0;
                var idExiste = ids.Contains(id);
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT * FROM prova p WHERE p.ID = @ID", conexao.conexao);
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
                    id = new Random().Next(100000, 999999);
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
        public string MostrarBimestreDaProva(int provaId)
        {
            try
            {
                string bimestre;
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT b.Bimestre FROM prova p INNER JOIN bimestre b ON p.Bimestre = b.ID WHERE p.ID = @ID", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", provaId);
                bimestre = (string)cmd.ExecuteScalar();
                return bimestre;
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
        public DataTable ListarProvas()
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT p.ID, p.DataProva, m.Materia AS Materia, c.Classe AS Classe, b.Bimestre AS Bimestre FROM prova p INNER JOIN materia m ON p.Materia = m.ID INNER JOIN classe c ON p.Classe = c.ID INNER JOIN bimestre b ON p.Bimestre = b.ID ORDER BY p.ID, m.Materia, c.Classe, b.Bimestre ASC", conexao.conexao);
                MySqlDataAdapter dta = new MySqlDataAdapter();
                dta.SelectCommand = cmd;
                dta.Fill(dt);
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
        public DataTable ListarProvasPorMateriaTurma(int materia, int turma)
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT p.ID FROM prova p WHERE p.Materia = @Materia AND p.Classe = @Classe", conexao.conexao);
                cmd.Parameters.AddWithValue("@Materia", materia);
                cmd.Parameters.AddWithValue("@Classe", turma);
                MySqlDataAdapter dta = new MySqlDataAdapter();
                dta.SelectCommand = cmd;
                dta.Fill(dt);
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
        public void SalvarProva(Prova provas)
        {
            try
            {
                int id = GerarID();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("INSERT INTO prova(ID, DataProva, Materia, Classe, Bimestre) VALUES(@ID, @DataProva, @Materia, @Classe, @Bimestre)", conexao.conexao);
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@DataProva", provas.DataProva);
                    cmd.Parameters.AddWithValue("@Materia", provas.Materia.Id);
                    cmd.Parameters.AddWithValue("@Classe", provas.Classe.Id);
                    cmd.Parameters.AddWithValue("@Bimestre", provas.Bimestre.Id);
                    cmd.ExecuteNonQuery();
                }
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
        public void EditarProva(Prova provas)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("UPDATE prova SET DataProva = @DataProva, Materia = @Materia, Classe = @Classe, Bimestre = @Bimestre WHERE ID = @ID", conexao.conexao);
                {
                    cmd.Parameters.AddWithValue("@ID", provas.Id);
                    cmd.Parameters.AddWithValue("@DataProva", provas.DataProva);
                    cmd.Parameters.AddWithValue("@Materia", provas.Materia.Id);
                    cmd.Parameters.AddWithValue("@Classe", provas.Classe.Id);
                    cmd.Parameters.AddWithValue("@Bimestre", provas.Bimestre.Id);
                    cmd.ExecuteNonQuery();
                }
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
        public void ExcluirProva(Prova provas)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("DELETE FROM alunoProva WHERE ID = @ID", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", provas.Id);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("DELETE FROM prova WHERE ID = @ID", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", provas.Id);
                cmd.ExecuteNonQuery();
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
        ////////////////////////////////////////////////////        BIMETSRE         ///////////////////////////////////////////////////////////////
        public DataTable ListarBimestres()
        {
            DataTable dt = new DataTable();
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT * FROM bimestre", conexao.conexao);

                MySqlDataAdapter dta = new MySqlDataAdapter();
                dta.SelectCommand = cmd;
                dta.Fill(dt);
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
