﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICRUD_Productos.Entity
{
    public class Producto
    {
        //propiedades
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
