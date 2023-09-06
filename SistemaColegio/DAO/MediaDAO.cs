using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class MediaDAO
    {
        MySqlCommand cmd;
        Conexao conexao = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int ContarNumeroDeMedias(Media media)
        {
            try
            {
                List<double> medias = new List<double>();
                int quantidadeMedias = medias.Count;
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT * FROM alunoMedia WHERE Materia = @Materia AND RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@Materia", media.Materia.Id);
                cmd.Parameters.AddWithValue("@RA", media.Aluno.Ra);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medias.Add(Convert.ToInt32(reader["Media"]));
                    }
                }
                return medias.Count;
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
        public List<double> ObterMediasPorRa(int ra)
        {
            try
            {
                var medias = new List<double>();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT Media FROM alunoMedia WHERE RA = @RA", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", ra);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medias.Add(Convert.ToDouble(reader["Media"]));
                    }
                }
                return medias;
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
        public DataTable ListarMediasPorRa(int ra)
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT am.RA, m.Materia, am.Media FROM alunoMedia am INNER JOIN Materia m ON am.Materia = m.ID WHERE am.RA = @RA ORDER BY m.Materia ASC", conexao.conexao);
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
        public void SalvarMedia(Media medias)
        {
            try
            {
                conexao.AbrirConexao();
                cmd = new MySqlCommand("INSERT INTO alunoMedia (RA, Materia, Media) VALUES (@RA, @Materia, @Media)", conexao.conexao);
                cmd.Parameters.AddWithValue("@RA", medias.Aluno.Ra);
                cmd.Parameters.AddWithValue("@Materia", medias.Materia.Id);
                cmd.Parameters.AddWithValue("@Media", medias.MediaNotas);
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
