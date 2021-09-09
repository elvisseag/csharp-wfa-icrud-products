using ICRUD_Productos.Controller;
using ICRUD_Productos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICRUD_Productos.View
{
    public partial class ProductosView : Form
    {
        public ProductosView()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            procesar(1);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            procesar(2);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            procesar(3);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void ProductosView_Load(object sender, EventArgs e)
        {
            cargaListas();
            verProductos();
        }

        //variables de instancia
        ProductoBll obj = new ProductoBll();
        Producto pro;

        private void verProductos()
        {
            try
            {
                dgvProducto.DataSource = null;
                dgvProducto.DataSource = obj.ProductoListar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cargaListas()
        {
            cboProveedor.DataSource = obj.ProveedorListar();
            cboProveedor.DisplayMember = "NombreProveedor";
            cboProveedor.ValueMember = "IdProveedor";

            cboCategoria.DataSource = obj.CategoriaListar();
            cboCategoria.DisplayMember = "NombreCategoria";
            cboCategoria.ValueMember = "IdCategoria";
        }

        private void procesar(int op)
        {
            try
            {
                MessageBox.Show(obj.ProductoProcesar(op, datosProducto()), "exito");
                verProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Producto datosProducto()
        {
            pro = new Producto()
            {
                IdProducto = Int32.Parse(txtCodigo.Text),
                NombreProducto = txtNombre.Text,
                IdProveedor = (int)cboProveedor.SelectedValue,
                IdCategoria = (int)cboCategoria.SelectedValue,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = (int)numCantidad.Value
            };
            return pro;
        }

        private void consultar()
        {
            pro = obj.ProductoConsultar(Int32.Parse(txtCodigo.Text));
            if (pro != null)
            {
                txtNombre.Text = pro.NombreProducto;
                txtPrecio.Text = pro.Precio.ToString();
                cboProveedor.SelectedValue = pro.IdProveedor;
                cboCategoria.SelectedValue = pro.IdCategoria;
                numCantidad.Value = pro.Stock;
            }
            else
            {
                MessageBox.Show("producto no existe", "Aviso");
                txtCodigo.SelectAll();
                txtCodigo.Focus();
            }
        }

    }

}
