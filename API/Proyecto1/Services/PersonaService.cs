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
            
            Boolean ans = false;
           try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                //NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter IdCedula = new NpgsqlParameter("pId", NpgsqlTypes.NpgsqlDbType.Integer);
                IdCedula.Value = persona.IdCedula;

                NpgsqlParameter Nombre = new NpgsqlParameter("pFname", NpgsqlTypes.NpgsqlDbType.Varchar);
            Nombre.Value = persona.Nombre;

            NpgsqlParameter Apellido1 = new NpgsqlParameter("pLname1", NpgsqlTypes.NpgsqlDbType.Varchar);
            Apellido1.Value = persona.Apellido1;

            NpgsqlParameter Apellido2 = new NpgsqlParameter("pLname2", NpgsqlTypes.NpgsqlDbType.Varchar);
            Apellido2.Value = persona.Apellido2;

            NpgsqlParameter FechaNacimiento = new NpgsqlParameter("pBdate", NpgsqlTypes.NpgsqlDbType.Date);
            FechaNacimiento.Value = Convert.ToDateTime(persona.FechaNacimiento);

            NpgsqlParameter Telefono = new NpgsqlParameter("pTelefono", NpgsqlTypes.NpgsqlDbType.Integer);
            Telefono.Value = persona.Telefono;

            NpgsqlParameter Distrito = new NpgsqlParameter("pDistrito", NpgsqlTypes.NpgsqlDbType.Varchar);
            Distrito.Value = persona.Distrito;

            NpgsqlParameter Direccion = new NpgsqlParameter("pDireccion", NpgsqlTypes.NpgsqlDbType.Varchar);
            Direccion.Value = persona.Direccion;

            NpgsqlParameter Contrasena = new NpgsqlParameter("pContrasena", NpgsqlTypes.NpgsqlDbType.Varchar);
            Contrasena.Value = persona.Contrasena;







            command = new NpgsqlCommand("select * from createclient(:pId ,:pFname ,:pLname1 ,:pLname2 ,:pBdate ,:pTelefono ,:pDistrito ,:pDireccion ,:pContrasena)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(IdCedula);
            command.Parameters.Add(Nombre);
            command.Parameters.Add(Apellido1);
            command.Parameters.Add(Apellido2);
            command.Parameters.Add(FechaNacimiento);
            command.Parameters.Add(Telefono);
            command.Parameters.Add(Distrito);
            command.Parameters.Add(Direccion);
            command.Parameters.Add(Contrasena);



            var a = command.ExecuteScalar();
                ans = Convert.ToBoolean(a);
                
                conn.Close();
                return ans;

            }
            catch
            {
              
                return ans;
            }

            
        }

    }
}
