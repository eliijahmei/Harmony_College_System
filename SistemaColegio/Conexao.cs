using MySql.Data.MySqlClient;
using System;

namespace SistemaColegio
{
    internal class Conexao
    {
        string conexao = "SERVER=localhost; DATABASE=sistemaescolar; USER=root; PASSWORD=;";
        public MySqlConnection con = null;

        public void abrirConexao()
        {
            try
            {
                con = new MySqlConnection(conexao);
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void fecharConexao()
        {
            try
            {
                con = new MySqlConnection(conexao);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
