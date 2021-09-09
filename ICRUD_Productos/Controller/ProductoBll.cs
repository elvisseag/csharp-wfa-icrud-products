using ICRUD_Productos.Entity;
using ICRUD_Productos.Model;
using ICRUD_Productos.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICRUD_Productos.Controller
{
    public class ProductoBll
    {
        //variable de la clase ProductoDao
        ProductoDao dao;
        //constructor
        public ProductoBll()
        {
            dao = new ProductoDao();
        }

        //metodos de negocio
        public string ProductoProcesar(int opcion, Producto pro)
        {
            string msj = "";
            try
            {
                switch (opcion)
                {
                    case Constante.INSERT:
                        dao.create(pro);
                        msj = "Producto registrado con exito";
                        break;
                    case Constante.UPDATE:
                        dao.update(pro);
                        msj = "Producto actualizado con exito";
                        break;
                    case Constante.DELETE:
                        dao.delete(pro);
                        msj = "Producto eliminado con exito";
                        break;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return msj;
        }

        public Producto ProductoConsultar(int id)
        {
            try
            {
                return dao.findForId(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Producto> ProductoListar()
        {
            try
            {
                return dao.readAll();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable ProveedorListar()
        {
            try
            {
                return dao.readAllProveedor();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable CategoriaListar()
        {
            try
            {
                return dao.readAllCategorias();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
