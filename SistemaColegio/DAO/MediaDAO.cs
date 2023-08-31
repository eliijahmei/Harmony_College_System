using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace SistemaColegio.DAO
{
    public class MediaDAO
    {
        MySqlCommand cmd;
        Conexao con = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int ContarMedias(Media medias)
        {
            try
            {
                int count = 0;
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT COUNT(*) FROM alunoMedia WHERE Materia = @Materia AND RA = @RA", con.con);
                cmd.Parameters.AddWithValue("@Materia", medias.Materia.Id);
                cmd.Parameters.AddWithValue("@RA", medias.Aluno.Ra);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
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
        public List<double> ObterNotasPorRaMateria(int materia, int ra)
        {
            try
            {
                var notas = new List<double>();
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT Nota FROM alunoprova WHERE Materia = @Materia AND RA = @RA", con.con);
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
                con.fecharConexao();
            }
        }
        public DataTable ListarMedias(int ra)
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT am.RA, m.Materia AS Materia, am.Media FROM alunoMedia am INNER JOIN Materia m ON am.Materia = m.ID WHERE am.RA = @RA ORDER BY m.Materia ASC", con.con);
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
        public void SalvarMedia(Media medias)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("INSERT INTO alunoMedia (RA, Materia, Media) VALUES (@RA, @Materia, @Media)", con.con);
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
                con.fecharConexao();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
