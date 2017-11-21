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
        public Boolean UpdateProducto(int id, string nombre, string des)
        {
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("update productos set nombre=:pNombre, descripcion=:pDes where idproducto=:pId", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);
                command.Parameters.AddWithValue("pNombre", nombre);
                command.Parameters.AddWithValue("pDes", des);

                read = command.ExecuteReader();
                read.Close();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Producto> ProductosxFactura(int idfactura, string sucursal)
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


                command = new NpgsqlCommand("select pr.nombre,pr.idproducto,pf.cantidad,ps.precio from productosxfacturas as pf inner join productos as pr on pr.idproducto=pf.idproducto  inner join productosxsucursales as ps on ps.idproducto=pf.idproducto inner join sucursales as s on s.idsucursal=ps.idsucursal where pf.idfactura = :pId and pf.logicdelete=false and s.nombre=:pSucursal", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("pId",idfactura);
                command.Parameters.Add(Sucursal);

                read = command.ExecuteReader();

                while (read.Read())
                {
                    Producto p = new Producto();
                    p.Nombre = Convert.ToString(read["nombre"]);
                    p.IdProducto = Convert.ToInt32(read["idproducto"]);
                    p.Cantidad = Convert.ToInt32(read["cantidad"]);
                    p.Precio = Convert.ToInt32(read["precio"]);
                    ans.Add(p); 
                }
                read.Close();
                conn.Close();
                return ans;

            }
            catch
            {
                return ans;
            }
        }
        public Boolean AgregarProducto(int idfactura, int idproducto, int cantidad)
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

                NpgsqlParameter IdProducto = new NpgsqlParameter("pIdProducto", NpgsqlTypes.NpgsqlDbType.Integer);
                IdProducto.Value = idproducto;

                NpgsqlParameter Cantidad = new NpgsqlParameter("pCantidad", NpgsqlTypes.NpgsqlDbType.Integer);
                Cantidad.Value = cantidad;




                command = new NpgsqlCommand("select * from insertproduct(:pIdFactura ,:pIdProducto , :pCantidad)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(IdFactura);
                command.Parameters.Add(IdProducto);
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


        public Boolean BorrarProducto(int idfactura, int idproducto, int cantidad)
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

                NpgsqlParameter IdProducto = new NpgsqlParameter("pIdProducto", NpgsqlTypes.NpgsqlDbType.Integer);
                IdProducto.Value = idproducto;

                NpgsqlParameter Cantidad = new NpgsqlParameter("pCantidad", NpgsqlTypes.NpgsqlDbType.Integer);
                Cantidad.Value = cantidad;




                command = new NpgsqlCommand("select * from deleteproduct(:pIdFactura ,:pIdProducto , :pCantidad)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(IdFactura);
                command.Parameters.Add(IdProducto);
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

                NpgsqlParameter IdProducto = new NpgsqlParameter("pIdProducto", NpgsqlTypes.NpgsqlDbType.Integer);
                IdProducto.Value = producto.IdProducto;

                NpgsqlParameter Descripcion = new NpgsqlParameter("pDescripcion", NpgsqlTypes.NpgsqlDbType.Varchar);
                Descripcion.Value = producto.Descripcion;




                command = new NpgsqlCommand("select * from createproduct(:pNombre ,:pDescripcion , :pIdProducto)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(Nombre);
                command.Parameters.Add(IdProducto);
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


        public int CrearFactura([FromBody]Factura factura)
        {
            int ans = 0;
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                


                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter PeCedula = new NpgsqlParameter("pPeCedula", NpgsqlTypes.NpgsqlDbType.Integer);
                PeCedula.Value = factura.PeCedula;

                NpgsqlParameter CaCedula = new NpgsqlParameter("pCaCedula", NpgsqlTypes.NpgsqlDbType.Integer);
                CaCedula.Value = factura.CaCedula;

              /*  NpgsqlParameter Sucursal = new NpgsqlParameter("pSucursal", NpgsqlTypes.NpgsqlDbType.Varchar);
                Sucursal.Value = factura.Sucursal;*/



                command = new NpgsqlCommand("select * from savecompra(:pPeCedula,:pCaCedula )", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(PeCedula);
                command.Parameters.Add(CaCedula);
                //command.Parameters.Add(Sucursal);



                var a = command.ExecuteScalar();
                ans = Convert.ToInt32(a);


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