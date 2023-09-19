using MySql.Data.MySqlClient;
using SistemaColegio.Entidades;
using System.Collections.Generic;
using System;
using System.Data;

namespace SistemaColegio.DAO
{
    public class StatusDAO
    {
        MySqlCommand cmd;
        Conexao conexao = new Conexao();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ListaStatusAluno()
        {
            try
            {
                DataTable dt = new DataTable(); 
                conexao.AbrirConexao();
                cmd = new MySqlCommand("SELECT * FROM statusAluno s ORDER BY s.ID ASC", conexao.conexao);
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
