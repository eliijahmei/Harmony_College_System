using System.Collections.Generic;
using SistemaColegio.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class AlunoDAO
    {
        MySqlCommand cmd;
        Conexao conexao = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int GerarRA()
        {
            try
            {
                List<int> ras = new List<int>();
                int ra = 0;
                int oldRa = 0;
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.RA FROM aluno a WHERE RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", ra);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ras.Add(Convert.ToInt32(reader["RA"]));
                    }
                }
                do
                {
                    ra = new Random().Next(10000, 99999);
                    foreach (int raExistente in ras)
                    {
                        if (raExistente == ra)
                        {
                            oldRa = raExistente;
                        }
                    }
                } while (oldRa == ra);
                return ra;
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
        public DataTable ListarAlunos()
        {
            try
            {
                DataTable dt = new DataTable(); 
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.RA, a.Nome, a.Sexo, a.DataNascimento, c.Classe, a.Situacao FROM aluno a INNER JOIN classe c ON a.Classe = c.ID ORDER BY ID ASC, Nome", conexao.conexao);
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
        public DataTable ListarAlunosPorClasse(int classe)
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.RA FROM aluno a WHERE a.Classe = @ID", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", classe);
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
        public Aluno PegaBoletimAlunoPorRa(int alunoRA)
        {
            try
            {
                Aluno aluno;
                string nome;
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.Nome, a.RA FROM aluno a WHERE RA = @RA ORDER BY ID ASC, Nome", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", alunoRA);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nome = reader["Nome"].ToString();
                    aluno = new Aluno(alunoRA, nome);
                    return aluno;
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
        public DataTable BuscarAlunosPorRA(string ra)
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.RA, a.Nome, a.Sexo, a.DataNascimento, c.Classe FROM aluno a INNER JOIN classe c ON a.Classe = c.ID WHERE RA LIKE @RA ORDER BY ID ASC, Nome", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", "%" + ra + "%");
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
        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                int ra = GerarRA();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("INSERT INTO aluno(RA, Nome, Sexo, DataNascimento, Classe, Situacao) VALUES(@RA, @Nome, @Sexo, @DataNascimento, @Classe, @Situacao)", conexao.conexao);
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
            catch
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
        }
        public void EditarAluno(Aluno aluno)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("UPDATE aluno SET Nome = @Nome, Sexo = @Sexo, DataNascimento = @DataNascimento, Classe = @Classe WHERE RA = @RA", conexao.conexao);
                {
                    cmd.Parameters.AddWithValue("@RA", aluno.Ra);
                    cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", aluno.Sexo);
                    cmd.Parameters.AddWithValue("@DataNascimento", aluno.DataNasc);
                    cmd.Parameters.AddWithValue("@Classe", aluno.Classe.Id);
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
        public void AtualizarNaoEstudando(Aluno aluno)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("UPDATE aluno SET Situacao = 'Não Estudando' WHERE RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", aluno.Ra);
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
        public void AtualizarEstudando(Aluno aluno)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("UPDATE aluno SET Situacao = 'Estudando' WHERE RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", aluno.Ra);
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
