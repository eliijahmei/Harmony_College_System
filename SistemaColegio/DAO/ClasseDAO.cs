using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaColegio.DAO
{
    public class ClasseDAO
    {
        MySqlCommand cmd;
        Conexao con = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarClasses()
        {
            DataTable dt = new DataTable();
            try
            {
                con.abrirConexao();
                cmd = new MySqlCommand("SELECT * FROM classe ORDER BY ID ASC, classe", con.con);
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
