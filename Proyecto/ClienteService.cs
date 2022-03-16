using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class ClienteService
    {
        public  List<Cliente> clientes;
        public ClienteService()
        {
            this.clientes = new List<Cliente>();
        }

        public void RegistrarCliente(Cliente cliente)
        {
            if (ExisteCliente(cliente.Documento))
            {
                throw new Exception("El Cliente con el Documento: " + cliente.Documento + " ya existe.");
            }

            this.clientes.Add(cliente);
        }

       public Cliente? BuscarCliente(int documento)
        {
            return clientes.FirstOrDefault(x => x.Documento == documento);
        }

        public Boolean ExisteCliente(int documento)
        {
            return clientes.FirstOrDefault(x => x.Documento == documento) != null;
        }

        public void ModificarCliente() {
            Console.WriteLine("Ingrese el Documento del Cliente que desea Modificar");
            var documento = int.Parse(Console.ReadLine());
           Cliente cliente = BuscarCliente(documento);
            Console.WriteLine("Ingrese Nombre Nuevo");
            cliente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrse nueva dirección");
            cliente.Direccion = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Telefono");
            cliente.Telefono = int.Parse(Console.ReadLine());
        }

        public void ActivarDesactivar() {
            Console.WriteLine("Ingrese el Documento del Cliente que desea Activar o Desactivar");
            var documento = int.Parse(Console.ReadLine());
            Cliente cliente = BuscarCliente(documento);
            cliente.ActivoDesactivo = Boolean.Parse(Console.ReadLine());
        }

        public void ListarClientes() {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre} Dirección: {cliente.Direccion} Telefono: {cliente.Telefono} Documento: {cliente.Documento} ACTIVO: {cliente.ActivoDesactivo}");
            }
        }
    }
}