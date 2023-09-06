using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaColegio.DAO
{
    public class ClasseDAO
    {
        MySqlCommand cmd;
        Conexao conexao = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarClasses()
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT * FROM classe ORDER BY ID ASC, classe", conexao.conexao);
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
