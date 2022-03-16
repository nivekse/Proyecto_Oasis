using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class VentaService
    {
        public List<Venta> ventas;
        public VentaService()
        {
            this.ventas = new List<Venta>();
        }

        public void RegistrarVenta(Venta venta)
        {
            if (ExisteVenta(venta.NumeroFactura))
            {
                throw new Exception("La venta con el numero: " + venta.NumeroFactura + " ya existe.");
            }

            this.ventas.Add(venta);
        }

        public Venta? BuscarVenta(int numeroFactura)
         {
         return ventas.FirstOrDefault(x => x.NumeroFactura == numeroFactura);
        }

        public Boolean ExisteVenta(int numeroFactura)
        {
            return ventas.FirstOrDefault(x => x.NumeroFactura == numeroFactura) != null;
        }


        public void ListarVentas()
        {
            foreach (var venta in ventas)
            {
                Console.WriteLine($"Numero de Factura {venta.NumeroFactura} Fecha {venta.Fecha} vendedor {venta.Vendedor} Nombre del cliente: {venta.cliente.Nombre}");
            }
        }
    }
}
