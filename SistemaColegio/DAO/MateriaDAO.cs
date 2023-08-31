using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaColegio.DAO
{
    public class MateriaDAO
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
