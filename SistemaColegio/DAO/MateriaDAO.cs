using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaColegio.DAO
{
    public class MateriaDAO
    {
        MySqlCommand cmd;
        Conexao conexao = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListarMaterias()
        {
            try
            {
                DataTable dt = new DataTable();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT * FROM materia ORDER BY ID ASC", conexao.conexao);
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
