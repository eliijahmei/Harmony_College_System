using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace SistemaColegio.DAO
{
    public class MateriasDAO
    {
        MySqlCommand cmd;
        Conexao con = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarMaterias()
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT * FROM materia ORDER BY ID ASC", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar materias! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.fecharConexao();
            }
            return dt;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
