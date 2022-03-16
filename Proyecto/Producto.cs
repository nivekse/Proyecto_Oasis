using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int Codigo { get; set; }
        public Boolean ActivoDesactivo { get; set; } = true;

        public  Producto(string nombre, double precio, int cantidad, int codigo) {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Codigo = codigo;
        }
    }
}
