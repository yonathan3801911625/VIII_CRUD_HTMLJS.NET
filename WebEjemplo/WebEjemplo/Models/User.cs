using Npgsql;
using System.Dynamic;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;



namespace WebEjemplo.Models
{
    public class User
    {
        String ced { set; get; }

        String nom { set; get; }

        int edad { set; get; }


        NpgsqlConnection cone;
        public void conectar()
        {

            this.cone = new NpgsqlConnection("Server=127.0.0.1;User Id=empresariales;Password=12345678;Database=webEjemplo");
            this.cone.Open();
        }

        public String ingresarUser()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "INSERT INTO usuario VALUES('" + this.ced + "', '" + this.nom + "', " + this.edad + ")";
                    new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                    return "Datos Guardados :)";
            }
            catch (Exception E)
            {

                return "Error al guardar";
            }
        }

        public String deleteUser()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "DELETE from usuario where cedula = '" + this.ced + "'";
                new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                return "Dato Eliminado :)";
            }
            catch (Exception E)
            {

                return "Error al eliminar";
            }
        }


        public String updateUser()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "UPDATE usuario set nombre = '" + this.nom + "', edad = " + this.edad + 
                    " where cedula = '" + this.ced + "'";
                cmd = new NpgsqlCommand(Sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Dato Actualizado :)";
            }
            catch (Exception E)
            {

                return "Error al actualizar";
            }
        }



        public String listUser()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "SELECT * from usuario";
                var reader = new NpgsqlCommand(Sql, this.cone).ExecuteReader();
                var todo = new List<dynamic>();
                while (reader.Read())
                {
                    dynamic dynamic = new ExpandoObject();

                    dynamic.cedula = reader.GetString(0);
                    dynamic.nombre = reader.GetString(1);
                    dynamic.edad = reader.GetInt16(2);
                    todo.Add(dynamic);

                }
                String variable = JsonConvert.SerializeObject(todo);
                reader.Close();

                return variable;
            }
            catch (Exception E)
            {

                return "Error al mostrar"+E;
            }
        }



        public User(string ced, string nom, int edad)
        {
            this.ced = ced;
            this.nom = nom;
            this.edad = edad;
        }
    }
}
