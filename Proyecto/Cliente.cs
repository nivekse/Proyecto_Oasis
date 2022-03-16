using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Documento { get; set; }
        public Boolean ActivoDesactivo { get; set; } = true;

        public Cliente(string nombre, string direccion, int telefono, int documento) {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Documento = documento;
        }
    }
}
