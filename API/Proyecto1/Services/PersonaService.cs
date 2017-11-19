using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using Npgsql;
using System.Data;

namespace Proyecto1.Services
{
    public class PersonaService
    {        
        public Boolean ValidCajero(int id,string contrasena,int money)
        {
            Boolean ans = false;
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select * from validcajerologin(:pId, :pContrasena, :pMoney)", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);
                command.Parameters.AddWithValue("pContrasena", contrasena);
                command.Parameters.AddWithValue("pMoney", money);

                read = command.ExecuteReader();

                while (read.Read())
                {
                    ans = Convert.ToBoolean(read["validcajerologin"]);
                }
                read.Close();
                conn.Close();
                return ans;
            }
            catch {
                return ans;
            }
            
        }

        public Boolean CrearCliente([FromBody] Persona persona)
        {
            Console.WriteLine(persona);
            Boolean ans = false;
           /*try
            {*/
                NpgsqlConnection conn;
                NpgsqlCommand command;
                //NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

            

                command = new NpgsqlCommand("select * from createclient(:pId ,:pFname ,:pLname1 ,:pLname2 ,:pBdate ,:pTelefono ,:pDistrito ,:pDireccion ,:pContrasena)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new NpgsqlParameter("pFname", persona.Nombre));
                command.Parameters.Add(new NpgsqlParameter("pContrasena", persona.Contrasena));
                command.Parameters.Add(new NpgsqlParameter("pId", persona.IdCedula));
                command.Parameters.Add(new NpgsqlParameter("pLname1", persona.Apellido1));
                command.Parameters.Add(new NpgsqlParameter("pLname2", persona.Apellido2));
                command.Parameters.Add(new NpgsqlParameter("pTelefono", persona.Telefono));
                command.Parameters.Add(new NpgsqlParameter("pDistrito", persona.Distrito));
                command.Parameters.Add(new NpgsqlParameter("pBdate", persona.FechaNacimiento));
                command.Parameters.Add(new NpgsqlParameter("pAddress", persona.Direccion));

                /*command.Parameters.AddWithValue("pId", persona.IdCedula);
                command.Parameters.AddWithValue("pContrasena", persona.Contrasena);
                command.Parameters.AddWithValue("pFname", persona.Nombre);
                command.Parameters.AddWithValue("pLname1", persona.Apellido1);
                command.Parameters.AddWithValue("pLname2", persona.Apellido2);
                command.Parameters.AddWithValue("pTelefono", persona.Telefono);
                command.Parameters.AddWithValue("pDistrito", persona.Distrito);
                command.Parameters.AddWithValue("pBdate", persona.FechaNacimiento);
                command.Parameters.AddWithValue("pAddress", persona.Direccion);*/

                var a = command.ExecuteScalar();
                ans = Convert.ToBoolean(a);
                
                conn.Close();
                return ans;

            /*}
            catch
            {
                ans = false;
                return ans;
            }*/

            
        }

    }
}
