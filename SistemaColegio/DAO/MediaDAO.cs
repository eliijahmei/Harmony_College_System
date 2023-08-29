using SistemaColegio.Entidades;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class MediaDAO
    {
        MySqlCommand cmd;
        Conexao con = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int ContarMedias(Medias medias)
        {
            int count = 0;
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT COUNT(*) FROM alunoMedia WHERE Materia = @Materia AND RA = @RA", con.con);
                cmd.Parameters.AddWithValue("@Materia", medias.Materia.Id);
                cmd.Parameters.AddWithValue("@RA", medias.Aluno.Ra);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao contar medias! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return count;
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar as médias! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return dt;
        }
        public void SalvarMedia(Medias medias)
        {
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("INSERT INTO alunoMedia (RA, Materia, Media) VALUES (@RA, @Materia, @Media)", con.con);
                cmd.Parameters.AddWithValue("@RA", medias.Aluno.Ra);
                cmd.Parameters.AddWithValue("@Materia", medias.Materia.Id);
                cmd.Parameters.AddWithValue("@Media", medias.Media);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atribuir a média! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
