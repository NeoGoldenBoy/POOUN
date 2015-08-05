using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Collections.ObjectModel;
using System.Text;

namespace MusicStore
{
    class BD
    {
        static SqlCeConnection Conexion()
        {
            return new SqlCeConnection(@"|DataDirectory|\TiendaMusica.sdf");
            
        }

        public static int EjecutarSQL(string comando) 
        {
            try
            {
                SqlCeCommand cmd = new SqlCeCommand(comando);
                cmd.Connection = Conexion();
                cmd.Connection.Open();
                int rows = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return rows;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static int EjecutarSQL(string comando, out int id)
        {
            try
            {
                SqlCeCommand cmd = new SqlCeCommand(comando);
                cmd.Connection = Conexion();
                cmd.Connection.Open();
                int rows = cmd.ExecuteNonQuery();
                id = -1;
                if (rows > 0) 
                {
                    cmd.CommandText = "SELECT @@Identity;";
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                return rows;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable Consulta(string qry) 
        {
            try
            {
                SqlCeCommand cmd = new SqlCeCommand(qry);
                cmd.Connection = Conexion();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter();
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
