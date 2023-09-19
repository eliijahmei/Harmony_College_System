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
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.RA FROM aluno a WHERE RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", ra);
                var raExiste = ras.Contains(ra);
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
                    raExiste = ras.Contains(ra);
                } while (raExiste);
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
        public List<Aluno> ListaAlunos()
        {
            try
            {
                var alunos = new List<Aluno>();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.RA, a.Nome, a.Sexo, a.DataNascimento, c.Classe, sa.Status, c.ID AS classeID, sa.ID AS statusID FROM aluno a INNER JOIN classe c ON a.Classe = c.ID INNER JOIN statusAluno sa ON a.Status = sa.ID ORDER BY c.ID ASC, a.Nome", conexao.conexao);
               
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var classes = new Classe
                        {
                            Id = Convert.ToInt32(reader["classeID"]),
                            Classee = reader["Classe"].ToString()
                        }; 
                        var status = new StatusAluno
                        {
                            Id = Convert.ToInt32(reader["statusID"]),
                            Status = reader["Status"].ToString()
                        };
                        var aluno = new Aluno
                        {
                            Ra = Convert.ToInt32(reader["RA"].ToString()),
                            Nome = reader["Nome"].ToString(),
                            Sexo = reader["Sexo"].ToString(),
                            DataNasc = Convert.ToDateTime(reader["DataNascimento"]),
                            Classe = classes,
                            Status = status
                        };
                        alunos.Add(aluno);
                    }
                }
                return alunos;
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
        public DataTable ListarAlunosPorClasseEstudando(int classe)
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT a.RA FROM aluno a WHERE a.Classe = @ID AND a.Situacao = @situacao", conexao.conexao);
                cmd.Parameters.AddWithValue("@ID", classe);
                cmd.Parameters.AddWithValue("@situacao", "Estudando");
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
                cmd = new MySqlCommand("SELECT a.Nome, a.RA FROM aluno a WHERE RA = @RA ORDER BY RA ASC, Nome", conexao.conexao);
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

        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                int ra = GerarRA();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("INSERT INTO aluno(RA, Nome, Sexo, DataNascimento, Classe, Status) VALUES(@RA, @Nome, @Sexo, @DataNascimento, @Classe, @Status)", conexao.conexao);
                {
                    cmd.Parameters.AddWithValue("@RA", ra);
                    cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", aluno.Sexo);
                    cmd.Parameters.AddWithValue("@DataNascimento", aluno.DataNasc);
                    cmd.Parameters.AddWithValue("@Classe", aluno.Classe.Id);
                    cmd.Parameters.AddWithValue("@Status", 1);
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
                cmd = new MySqlCommand("UPDATE aluno SET Nome = @Nome, Sexo = @Sexo, DataNascimento = @DataNascimento, Classe = @Classe, Status = @Status WHERE RA = @RA", conexao.conexao);
                {
                    cmd.Parameters.AddWithValue("@RA", aluno.Ra);
                    cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", aluno.Sexo);
                    cmd.Parameters.AddWithValue("@DataNascimento", aluno.DataNasc);
                    cmd.Parameters.AddWithValue("@Classe", aluno.Classe.Id);
                    cmd.Parameters.AddWithValue("@Status", aluno.Status.Id);
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
