using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Collections.ObjectModel;

namespace MusicStore
{
    class Artista
    {
        public string Descripcion;
        public string Imagen;
        public int ID;

       

        public Artista(DataRow row) 
        {
            this.ID = Convert.ToInt32(row["ID"]);
            this.Descripcion = Convert.ToString(row["Descripcion"]);
            this.Imagen = Convert.ToString(row["Imagen"]);
        }

        public static ObservableCollection<Artista> ObtenerTodos() 
        {
            ObservableCollection<Artista> lista = new ObservableCollection<Artista>();
            DataTable tabla = BD.Consulta("SELECT * FROM Artistas");
            foreach (DataRow row in tabla.Rows)
                lista.Add(new Artista(row));

            return lista;
        }
    }
}
