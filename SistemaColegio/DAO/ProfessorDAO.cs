using SistemaColegio.Entidades;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class ProfessorDAO
    {
        MySqlCommand cmd;
        Conexao con = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int ProfessorGerarID()
        {
            int idProfessor = 0;
            try
            {
                do
                {
                    idProfessor = new Random().Next(1000, 9999);
                    con.abrirConexao();
                    cmd = new MySqlCommand("SELECT COUNT(*) FROM professor WHERE ID = @ID", con.con);
                    cmd.Parameters.AddWithValue("@ID", idProfessor);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        break;
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar ID! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return idProfessor;
        }
        public DataTable ListarProfessores()
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT professor.ID, professor.Nome, professor.Sexo, professor.DataNascimento, materia.Materia, professor.Situacao FROM professor INNER JOIN materia ON professor.MateriaProf = materia.ID ORDER BY materia.ID ASC, Nome", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os professores! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return dt;
        }
        public DataTable ListarProfessoresPorMateria(int professor)
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT ID, Nome FROM professor  WHERE MateriaProf = @MateriaID", con.con);
                cmd.Parameters.AddWithValue("@MateriaID", professor);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os professores! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return dt;
        }
        public void SalvarProfessor(Professor professor)
        {
            try
            {
                int idProfessor = ProfessorGerarID();
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar professor! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar professor! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar situação do professor!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar situação do professor!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
