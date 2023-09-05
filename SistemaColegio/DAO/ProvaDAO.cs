using SistemaColegio.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class ProvaDAO
    {
        MySqlCommand cmd;
        Conexao con = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int ContarProvas(Prova provas)
        {
            int count = 0;
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT COUNT(*) FROM prova p WHERE p.Materia = @Materia AND p.Classe = @Classe AND p.Bimestre = @Bimestre", con.con);
                cmd.Parameters.AddWithValue("@Materia", provas.Materia.Id);
                cmd.Parameters.AddWithValue("@Classe", provas.Classe.Id);
                cmd.Parameters.AddWithValue("@Bimestre", provas.Bimestre.Id);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
            return count;
        }
        public int ContarNotasPorProva(Nota notas)
        {
            int numeroNota = 0;
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT COUNT(*) FROM alunoProva ap WHERE ap.ID = @ID AND ap.RA = @RA", con.con);
                cmd.Parameters.AddWithValue("@ID", notas.Provas.Id);
                cmd.Parameters.AddWithValue("@RA", notas.Aluno.Ra);
                numeroNota = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
            return numeroNota;
        }
        public int ProvaGerarID()
        {
            int id;
            int count;
            try
            {
                do
                {
                    id = new Random().Next(001, 999);
                    con.abrirConexao();
                    cmd = new MySqlCommand("SELECT COUNT(*) FROM prova p WHERE p.ID = @ID", con.con);
                    cmd.Parameters.AddWithValue("@ID", id);
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        break;
                    }
                } while (true);
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
            return id;
        }
        public DataTable ListarBimestres()
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT * FROM bimestre", con.con);

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
                con.fecharConexao();
            }
            return dt;
        }
        public string ListarBimestre(int provaId)
        {
            string bimestre;
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT b.Bimestre FROM prova p INNER JOIN bimestre b ON p.Bimestre = b.ID WHERE p.ID = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", provaId);
                bimestre = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.fecharConexao();
            }
            return bimestre;
        }
        public DataTable ListarProvas()
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT p.ID, p.DataProva, m.Materia AS Materia, c.Classe AS Classe, b.Bimestre AS Bimestre FROM prova p INNER JOIN materia m ON p.Materia = m.ID INNER JOIN classe c ON p.Classe = c.ID INNER JOIN bimestre b ON p.Bimestre = b.ID ORDER BY p.ID, m.Materia, c.Classe, b.Bimestre ASC", con.con);
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
                con.fecharConexao();
            }
            return dt;
        }
        public DataTable ListarProvasPorMateriaTurma(int materia, int turma)
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT p.ID FROM prova p WHERE p.Materia = @Materia AND p.Classe = @Classe", con.con);
                cmd.Parameters.AddWithValue("@Materia", materia);
                cmd.Parameters.AddWithValue("@Classe", turma);
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
                con.fecharConexao();
            }
            return dt;
        }
        public DataTable ListarNotas(int ra, int materia)
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT ap.RA, ap.ID, ap.Nota, ap.Professor, ap.Materia FROM alunoProva ap INNER JOIN prova p ON ap.ID = p.ID WHERE ap.Materia = @Materia AND ap.RA = @RA", con.con);
                cmd.Parameters.AddWithValue("@Materia", materia);
                cmd.Parameters.AddWithValue("@RA", ra);
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
                con.fecharConexao();
            }
            return dt;
        }
        public void SalvarProva(Prova provas)
        {
            int id = ProvaGerarID();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("INSERT INTO prova(ID, DataProva, Materia, Classe, Bimestre) VALUES(@ID, @DataProva, @Materia, @Classe, @Bimestre)", con.con);
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
                con.fecharConexao();
            }
        }
        public void EditarProva(Prova provas)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE prova SET DataProva = @DataProva, Materia = @Materia, Classe = @Classe, Bimestre = @Bimestre WHERE ID = @ID", con.con);
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
                con.fecharConexao();
            }
        }
        public void ExcluirProva(Prova provas)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("DELETE FROM alunoProva WHERE ID = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", provas.Id);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("DELETE FROM prova WHERE ID = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", provas.Id);
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
        public void SalvarNota(Nota notas)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("INSERT INTO alunoProva(RA, ID, Nota, Professor, Materia) VALUES(@RA, @ID, @Nota, @Professor, @Materia)", con.con);
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
                con.fecharConexao();
            }
        }
        public void EditarNota(Nota notas)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE alunoProva SET Professor = @Professor, Nota = @Nota WHERE ID = @ID", con.con);
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
                con.fecharConexao();
            }
        }
        public void ExcluirNota(Nota notas)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("DELETE FROM alunoProva WHERE ID = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", notas.Provas.Id);
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
        public string ReceberNotaProva(Aluno aluno, int idMateria, int idBimestre)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT ap.Nota FROM alunoprova ap JOIN prova p ON p.ID = ap.ID WHERE ap.RA = @aluno AND p.Materia = @materia AND p.Bimestre = @bimestre;", con.con);
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
                con.fecharConexao(); 
            }
            return null;
        }
        public string ReceberNotaMedia(Aluno aluno, int idMateria)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT am.Media FROM alunomedia am WHERE am.RA = @aluno AND am.Materia = @materia;", con.con);
                cmd.Parameters.AddWithValue("@aluno", aluno.Ra);
                cmd.Parameters.AddWithValue("@materia", idMateria);
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
                con.fecharConexao();
            }
            return null;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
