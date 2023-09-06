using MySql.Data.MySqlClient;
using System;

namespace SistemaColegio
{
    internal class Conexao
    {
        string connection = "SERVER=localhost; DATABASE=sistemaescolar; USER=root; PASSWORD=1234;";
        public MySqlConnection conexao = null;

        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(connection);
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(connection);
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
