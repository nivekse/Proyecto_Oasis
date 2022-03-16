using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Proyecto
{
    internal class ProductoService
    {
        public List<Producto> productos;
        public ProductoService()
        {
            this.productos = new List<Producto>();
        }

        public void RegistrarProducto(Producto producto)
        {
            if (ExisteProducto(producto.Codigo))
            {
                throw new Exception("El producto con el codigo: " + producto.Codigo + " ya existe.");   
            }

            this.productos.Add(producto);
        }

        public Producto? BuscarProducto(int codigo) {
            return productos.FirstOrDefault(x => x.Codigo == codigo);
        }

        Boolean ExisteProducto(int codigo)
        {
            return productos.FirstOrDefault(x => x.Codigo == codigo) != null;
        }
        public void ModificarProducto()
        {
            Console.WriteLine("Ingrese el codigo del producto que desea modificar");
            var codigo = int.Parse(Console.ReadLine());
            Producto producto = BuscarProducto(codigo);
            Console.WriteLine("Ingrese Nombre Nuevo");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese precio nuevo");
            producto.Precio = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nueva cantidad");
            producto.Cantidad = int.Parse(Console.ReadLine());
        }
        public void ActivarDesactivar()
        {
            Console.WriteLine("Ingrese el codigo del producto desea Activar o Desactivar");
            var codigo = int.Parse(Console.ReadLine());
            Producto producoto = BuscarProducto(codigo);
            producoto.ActivoDesactivo = Boolean.Parse(Console.ReadLine());
        }

        public void ListarProductos()
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre} Precio: {producto.Precio} Cantidad: {producto.Cantidad} Codigo: {producto.Codigo} ACTIVO: {producto.ActivoDesactivo}");
            }
        }

    }
}
