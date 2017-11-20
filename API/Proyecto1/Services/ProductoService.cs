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
    public class ProductoService
    {
        public Boolean AgregarProducto(int idfactura, int ean, int cantidad)
        {
            Boolean ans = false;
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;


                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter IdFactura = new NpgsqlParameter("pIdFactura", NpgsqlTypes.NpgsqlDbType.Integer);
                IdFactura.Value = idfactura;

                NpgsqlParameter EAN = new NpgsqlParameter("pEAN", NpgsqlTypes.NpgsqlDbType.Integer);
                EAN.Value = ean;

                NpgsqlParameter Cantidad = new NpgsqlParameter("pCantidad", NpgsqlTypes.NpgsqlDbType.Integer);
                Cantidad.Value = cantidad;




                command = new NpgsqlCommand("select * from insertproduct(:pIdFactura ,:pEAN , :pCantidad)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(IdFactura);
                command.Parameters.Add(EAN);
                command.Parameters.Add(Cantidad);


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


        public Boolean BorrarProducto(int idfactura, int ean, int cantidad)
        {
            Boolean ans = false;
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;


                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter IdFactura = new NpgsqlParameter("pIdFactura", NpgsqlTypes.NpgsqlDbType.Integer);
                IdFactura.Value = idfactura;

                NpgsqlParameter EAN = new NpgsqlParameter("pEAN", NpgsqlTypes.NpgsqlDbType.Integer);
                EAN.Value = ean;

                NpgsqlParameter Cantidad = new NpgsqlParameter("pCantidad", NpgsqlTypes.NpgsqlDbType.Integer);
                Cantidad.Value = cantidad;




                command = new NpgsqlCommand("select * from deleteproduct(:pIdFactura ,:pEAN , :pCantidad)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(IdFactura);
                command.Parameters.Add(EAN);
                command.Parameters.Add(Cantidad);


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

        public Boolean CrearProducto ([FromBody] Producto producto)
        {
            Boolean ans = false;
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;


                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter Nombre = new NpgsqlParameter("pNombre", NpgsqlTypes.NpgsqlDbType.Integer);
                Nombre.Value = producto.Nombre;

                NpgsqlParameter EAN = new NpgsqlParameter("pEAN", NpgsqlTypes.NpgsqlDbType.Integer);
                EAN.Value = producto.EAN;

                NpgsqlParameter Descripcion = new NpgsqlParameter("pDescripcion", NpgsqlTypes.NpgsqlDbType.Varchar);
                Descripcion.Value = producto.Descripcion;




                command = new NpgsqlCommand("select * from createproduct(:pNombre ,:pDescripcion , :pEAN)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(Nombre);
                command.Parameters.Add(EAN);
                command.Parameters.Add(Descripcion);


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

        public List<Cajero> MasVendidosCajero(string compania)
        {
            List<Cajero> ans = new List<Cajero>();
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter Compania = new NpgsqlParameter("pCompania", NpgsqlTypes.NpgsqlDbType.Varchar);
                Compania.Value = compania;




                command = new NpgsqlCommand("select * from masvendidoscajero(:pCompania)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(Compania);

                read = command.ExecuteReader();

                while (read.Read())
                {
                    Cajero c = new Cajero();
                    c.Nombre = Convert.ToString(read["pnombre"]);
                    c.Cantidad = Convert.ToInt32(read["pcantidad"]);

                    ans.Add(c);
                }

                

                conn.Close();
                return ans;

            }
            catch
            {
                return ans;
            }
        }

        public List<Producto> MasVendidosSucursal(string sucursal)
        {
            List<Producto> ans = new List<Producto>();
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;


                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter Sucursal = new NpgsqlParameter("pSucursal", NpgsqlTypes.NpgsqlDbType.Varchar);
                Sucursal.Value = sucursal;



                command = new NpgsqlCommand("select * from masvendidossucursal(:pSucursal )", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(Sucursal);


                read = command.ExecuteReader();

                while (read.Read())
                {
                    Producto p = new Producto();
                    p.Nombre = Convert.ToString(read["pnombre"]);
                    p.Cantidad = Convert.ToInt32(read["pcantidad"]);

                    ans.Add(p);
                }


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