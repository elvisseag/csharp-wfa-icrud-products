using ICRUD_Productos.DataBase;
using ICRUD_Productos.Entity;
using ICRUD_Productos.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICRUD_Productos.Model
{
    public class ProductoDao : ICrudDao<Producto>
    {
        //variables       
        SqlDataAdapter da = null;
        SqlDataReader dr = null;

        //metodos de persistencia de datos
        public void create(Producto t)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            using (cn = AccesoDB.getConnection())
            {
                cmd = new SqlCommand("usp_Producto_Adicionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", t.NombreProducto);
                cmd.Parameters.AddWithValue("@IdProveedor", t.IdProveedor);
                cmd.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", t.Precio);
                cmd.Parameters.AddWithValue("@Stock", t.Stock);
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                cmd.ExecuteNonQuery();
                t.IdProducto = (int)cmd.Parameters["@IdProducto"].Value;
            }
        }

        public void delete(Producto t)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            using (cn = AccesoDB.getConnection())
            {
                cmd = new SqlCommand("usp_Producto_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", t.IdProducto);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Producto findForId(int t)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            Producto pro = null;

            using (cn = AccesoDB.getConnection())
            {
                cmd = new SqlCommand("usp_Producto_Buscar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", t);
                try
                {
                    cn.Open();
                    dr = cmd.ExecuteReader(CommandBehavior.Default);
                    if (dr.Read())
                    {
                        pro = new Producto()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Precio = Convert.ToDecimal(dr["PrecioUnidad"]),
                            Stock = Convert.ToInt32(dr["Stock"])
                        };
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return pro;
        }

        public List<Producto> readAll()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            List<Producto> lstProducto = new List<Producto>();
            using (cn = AccesoDB.getConnection())
            {
                cmd = new SqlCommand("usp_Producto_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    dr = cmd.ExecuteReader(CommandBehavior.Default);
                    Producto pro;
                    while (dr.Read())
                    {
                        pro = new Producto()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Precio = Convert.ToDecimal(dr["PrecioUnidad"]),
                            Stock = Convert.ToInt32(dr["Stock"])
                        };
                        lstProducto.Add(pro);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lstProducto;
        }

        public void update(Producto t)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            using (cn = AccesoDB.getConnection())
            {
                cmd = new SqlCommand("usp_Producto_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", t.NombreProducto);
                cmd.Parameters.AddWithValue("@IdProveedor", t.IdProveedor);
                cmd.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", t.Precio);
                cmd.Parameters.AddWithValue("@Stock", t.Stock);
                cmd.Parameters.AddWithValue("@IdProducto", t.IdProducto);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable readAllProveedor()
        {
            DataTable dt;
            using (SqlConnection cn = AccesoDB.getConnection())
            {
                SqlCommand cmd = new SqlCommand("usp_Proveedor_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable readAllCategorias()
        {
            DataTable dt;
            using (SqlConnection cn = AccesoDB.getConnection())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

    }
}
