using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Venta
    {
        public Cliente cliente { get; set; }
        public List<Producto> productos = new List<Producto>();
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int NumeroFactura { get; set; }
        public string Vendedor { get; set; } = "Kevin";
        public int CantidadProducto { get; set; }



    }
}
