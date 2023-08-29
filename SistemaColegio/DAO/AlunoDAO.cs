using SistemaColegio.Entidades;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class AlunoDAO
    {
        MySqlCommand cmd;
        Conexao con = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int AlunoGerarRA()
        {
            int raAluno = 0;
            try
            {
                do
                {
                    raAluno = new Random().Next(10000, 99999);
                    con.abrirConexao();
                    cmd = new MySqlCommand("SELECT COUNT(*) FROM aluno WHERE RA = @RA", con.con);
                    cmd.Parameters.AddWithValue("@RA", raAluno);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        break;
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar RA! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return raAluno;
        }
        public DataTable ListarAlunos()
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT aluno.RA, aluno.Nome, aluno.Sexo, aluno.DataNascimento, classe.Classe, aluno.Situacao FROM aluno INNER JOIN classe ON aluno.Classe = classe.ID ORDER BY ID ASC, Nome", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os alunos! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally 
            { 
                con.fecharConexao(); 
            }
            return dt;
        }
        public Aluno AlunoPorRA(int alunoRA)
        {
            try
            {
                con.abrirConexao();
                Aluno aluno;
                cmd = new MySqlCommand("SELECT * FROM aluno INNER JOIN classe ON aluno.Classe = classe.ID WHERE RA = @RA ORDER BY ID ASC, Nome", con.con);
                cmd.Parameters.AddWithValue("@RA", alunoRA);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nome = reader["Nome"].ToString();

                    aluno = new Aluno(alunoRA, nome);
                    return aluno;
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.fecharConexao(); }
          
        }
        public DataTable ListarRAPorSala(int classe)
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT a.RA FROM aluno a WHERE a.Classe = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", classe);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os alunos! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return dt;
        }
        public DataTable ListarAlunosPorSala(int classe)
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT a.RA, a.Nome, a.Sexo, a.DataNascimento, a.Classe, a.Situacao FROM aluno a WHERE a.Classe = @ID", con.con);
                cmd.Parameters.AddWithValue("@ID", classe);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os alunos! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return dt;
        }
        public DataTable BuscarAlunosPorRA(string ra)
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT aluno.RA, aluno.Nome, aluno.Sexo, aluno.DataNascimento, classe.Classe FROM aluno INNER JOIN classe ON aluno.Classe = classe.ID WHERE RA LIKE @RA ORDER BY ID ASC, Nome", con.con);
                cmd.Parameters.AddWithValue("@RA", "%" + ra + "%");
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os alunos! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return dt;
        }
        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                int ra = AlunoGerarRA();
                con.abrirConexao();
                cmd = new MySqlCommand("INSERT INTO aluno(RA, Nome, Sexo, DataNascimento, Classe, Situacao) VALUES(@RA, @Nome, @Sexo, @DataNascimento, @Classe, @Situacao)", con.con);
                {
                    cmd.Parameters.AddWithValue("@RA", ra);
                    cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", aluno.Sexo);
                    cmd.Parameters.AddWithValue("@DataNascimento", aluno.DataNasc);
                    cmd.Parameters.AddWithValue("@Classe", aluno.Classe.Id);
                    cmd.Parameters.AddWithValue("@Situacao", "Estudando");
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o aluno! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
        }
        public void EditarAluno(Aluno aluno)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE aluno SET Nome = @Nome, Sexo = @Sexo, DataNascimento = @DataNascimento, Classe = @Classe WHERE RA = @RA", con.con);
                {
                    cmd.Parameters.AddWithValue("@RA", aluno.Ra);
                    cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", aluno.Sexo);
                    cmd.Parameters.AddWithValue("@DataNascimento", aluno.DataNasc);
                    cmd.Parameters.AddWithValue("@Classe", aluno.Classe.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar o aluno! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
        }
        public void AtualizarNaoEstudando(Aluno aluno)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE aluno SET Situacao = 'Não Estudando' WHERE RA = @RA", con.con);
                cmd.Parameters.AddWithValue("@RA", aluno.Ra);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar situação do aluno!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
        }
        public void AtualizarEstudando(Aluno aluno)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("UPDATE aluno SET Situacao = 'Estudando' WHERE RA = @RA", con.con);
                cmd.Parameters.AddWithValue("@RA", aluno.Ra);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar situação do aluno!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
