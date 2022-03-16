using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{ 
    internal class Consola
    {
        ProductoService productoService = new ProductoService();
        ClienteService clienteService = new ClienteService();
        VentaService ventaService = new VentaService();
        

        public void RegistrarCliente() {
            

            Console.WriteLine("Ingrse Documento de indentidad: ");
             var documento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre: ");
            var nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Dirección");
            var direccion = Console.ReadLine();
            Console.WriteLine("Ingrese Telefono: ");
            var telefono = int.Parse(Console.ReadLine());
            var cliente = new Cliente(nombre, direccion, telefono,documento);


            try
            {
                this.clienteService.RegistrarCliente(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void CrearProducto()
        {
            Console.WriteLine("Ingrese codigo del Producto: ");
            var codigo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nombre del Producto: ");
            var nombre = Console.ReadLine();
            Console.WriteLine("Ingrese precio del producto");
            var precio = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cantidad del producto: ");
            var cantidad = int.Parse(Console.ReadLine());
            var producto = new Producto(nombre, precio, cantidad, codigo);

           
            

            try
            {
                this.productoService.RegistrarProducto(producto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MostrarMenu()
        {
            Console.WriteLine("*******************Index**************************");
            Console.WriteLine("1 -> Productos");
            Console.WriteLine("2 -> Clientes");
            Console.WriteLine("3 -> Ventas");
            Console.WriteLine("4 -> Configuracion");
            Console.WriteLine("5 -> Salir");
        }

        public void MostrarMenuClientes()
        {
            Console.WriteLine("**************************Modulo de clientes******************************");
            Console.WriteLine("1 -> Crear Cliente");
            Console.WriteLine("2 -> Modificar Cliente");
            Console.WriteLine("3 -> Activar/Desactivar Cliente");
            Console.WriteLine("4 -> Listar Clientes");
            Console.WriteLine("5 -> Buscar Cliente");
            Console.WriteLine("6 -> Salir");

            Console.WriteLine("Escoja una opcion");
            var opcion = int.Parse(Console.ReadLine());
            do
            {
                switch (opcion)
                {
                    case 1: RegistrarCliente(); MostrarMenuClientes(); break;
                    case 2: clienteService.ModificarCliente(); MostrarMenuClientes();  break;
                    case 3: clienteService.ActivarDesactivar(); MostrarMenuClientes(); break;
                    case 4: clienteService.ListarClientes(); MostrarMenuClientes(); break;
                    case 5: clienteService.ListarClientes();
                        Console.WriteLine("Ingrse documento del cliente que sea buscar");
                        var documento = int.Parse(Console.ReadLine());
                        var cliente = clienteService.BuscarCliente(documento);
                        if (cliente == null)
                        {
                            Console.WriteLine("El cliente no Existe");
                            MostrarMenuClientes();
                        }
                        else
                        {
                            Console.WriteLine($"Nombre: {cliente.Nombre} Dirección: {cliente.Direccion} Telefono: {cliente.Telefono} ACTIVO: {cliente.ActivoDesactivo}");
                            MostrarMenuClientes();
                        }
                        break;

                    case 6: Console.WriteLine("Usted Salio del modulo de clientes"); break;
                    default: Console.WriteLine("Ese numero no existe"); MostrarMenuClientes(); break;
                        
                }break;
            }  while (opcion !=6);
            
        }

        public void MostrarMenuProductos()
        {
            Console.WriteLine("******************Modulo de Producto**********************");
            Console.WriteLine("1 -> Crear Producto");
            Console.WriteLine("2 -> Modificar Producto");
            Console.WriteLine("3 -> Activar/Desactivar Producto");
            Console.WriteLine("4 -> Listar Productos");
            Console.WriteLine("5 -> Buscar Producto");
            Console.WriteLine("6 -> Salir");

            Console.WriteLine("Escoja una opcion");
            var opcion = int.Parse(Console.ReadLine());
            do
            {
                
                switch (opcion)
                {
                    case 1: CrearProducto(); MostrarMenuProductos(); break; 
                    case 2: productoService.ModificarProducto(); MostrarMenuProductos(); break;
                    case 3: productoService.ActivarDesactivar(); MostrarMenuProductos(); break;
                    case 4: productoService.ListarProductos(); MostrarMenuProductos(); break;
                    case 5:
                        productoService.ListarProductos();
                        Console.WriteLine("Ingrse codigo del producto que desea buscar");
                        var codigo = int.Parse(Console.ReadLine());
                        var producto = productoService.BuscarProducto(codigo);
                        if (producto == null)
                        {
                            Console.WriteLine("El Producto no existe");
                            MostrarMenuProductos();
                        }
                        else
                        {
                            Console.WriteLine($"Nombre: {producto.Nombre} Precio: {producto.Precio} Cantidad: {producto.Cantidad} ACTIVO: {producto.ActivoDesactivo}");
                            MostrarMenuProductos();
                        }
                        break;

                    case 6: Console.WriteLine("Usted Salio del modulo de productos"); break;
                    default: Console.WriteLine("Ese numero no existe"); MostrarMenuProductos(); break;

                } break;
            } while (opcion != 6);
            
        }

        public void Swhich() {
            MostrarMenu();
            Console.WriteLine("Escoja una opcion");
            var opcion = int.Parse(Console.ReadLine());
            do
            {
                switch (opcion) {
                    case 1: MostrarMenuProductos(); Swhich(); break;
                    case 2: MostrarMenuClientes(); Swhich(); break;
                    case 3: MostrarMenuVentas(); Swhich(); break;
                    case 4: Configuracion(); break;
                    case 5: Console.WriteLine("Usted salió de la Aplicacion"); break;
                    default : Console.WriteLine("Ese número no existe. Intente de nuevo"); Swhich(); break;
                } break; 
            } while (opcion !=5);
            
        }

        public void CrearVenta()
        {
            string continuar = "si";
            var venta = new Venta();
            clienteService.ListarClientes();
            Console.WriteLine("Ingrese numero de Factura");
            venta.NumeroFactura = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el documento del cliente para hacer una venta");
                var documento = int.Parse(Console.ReadLine());
                Cliente cliente = clienteService.BuscarCliente(documento);
                    if (cliente == null)
                    {
                        Console.WriteLine("Ningun cliente tiene ese documento.");
                MostrarMenuVentas();
                    }

                venta.cliente = cliente;

            Console.WriteLine("Productos Disponibles");
            productoService.ListarProductos();
            int contador = 0;

            do
            {
                Console.WriteLine("Ingrese codigo del producto para añadir a la venta");
                var codigo = int.Parse(Console.ReadLine());
                Producto producto = productoService.BuscarProducto(codigo);
                    if (producto == null )
                    {
                        Console.WriteLine("Ningun producto tiene ese codigo.");
                        Swhich();
                    }
                    else {
                        
                       
                            Console.WriteLine("¿Cuant@s quiere ?");
                            venta.CantidadProducto = int.Parse(Console.ReadLine());
                            if (venta.CantidadProducto > producto.Cantidad)
                            {
                                 while (venta.CantidadProducto > producto.Cantidad)
                                 {
                            Console.WriteLine("Excedió la cantidad maxima de producto intente de nuevo. No pueden ser más de " + producto.Cantidad);
                            Console.WriteLine("¿Cuant@s quiere ?");
                            venta.CantidadProducto = int.Parse(Console.ReadLine());
                                 }
                        if (codigo == producto.Codigo)
                        {

                            contador = venta.CantidadProducto + contador;
                            venta.CantidadProducto = contador;
                        }
                        producto.Cantidad = producto.Cantidad - venta.CantidadProducto;
                        venta.productos.Add(producto);
                    }
                            else {
                            if (codigo == producto.Codigo) {
                           
                            contador = venta.CantidadProducto + contador;
                            venta.CantidadProducto = contador;
                            }
                                producto.Cantidad = producto.Cantidad - venta.CantidadProducto;
                                venta.productos.Add(producto);
                            }
                        
                    }
                Console.WriteLine("Desea agregar otro producto a la venta ¿SI/NO?");
                continuar = Console.ReadLine();
            } while (continuar !="no");
            Console.WriteLine("Ingrese nombre del vendedor");
            venta.Vendedor = Console.ReadLine();


            try
            {
                this.ventaService.RegistrarVenta(venta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MostrarMenuVentas() {
            Console.WriteLine("********************Modulo de ventas************************");
            Console.WriteLine("1 -> Crear venta");
            Console.WriteLine("2 -> Ver detalle de una venta");
            Console.WriteLine("3 -> Ver Factura de un cliente");
            Console.WriteLine("4 -> Salir");
            Console.WriteLine("Escoge una opcion");
            int opcion = int.Parse(Console.ReadLine());
            do
            {
                switch (opcion) {
                    case 1: CrearVenta(); MostrarMenuVentas(); break;
                    case 2: ventaService.ListarVentas();
                        Console.WriteLine("Ingrese el numero de factura para buscar venta");
                        int numeroFactura = int.Parse(Console.ReadLine());
                        Venta venta = ventaService.BuscarVenta(numeroFactura);
                        Console.WriteLine($"Numero de Factura {venta.NumeroFactura} Fecha {venta.Fecha} vendedor {venta.Vendedor} Nombre del cliente: {venta.cliente.Nombre}");
                        MostrarMenuVentas();
                        break;
                    case 3:
                        double total = 0;
                        ventaService.ListarVentas();
                        Console.WriteLine("Ingrese el numero de factura para buscar venta");
                        numeroFactura = int.Parse(Console.ReadLine());
                        venta = ventaService.BuscarVenta(numeroFactura);
                        if (venta == null)
                        {
                            Console.WriteLine("Ese numero de factura no existe.");
                            MostrarMenuVentas();
                        }
                        else
                        {
                            Console.WriteLine("********************Factura**********************");
                            Console.WriteLine("Numero de Factura " +numeroFactura);
                            Console.WriteLine("Nombre del cliente " + venta.cliente.Nombre);
                            Console.WriteLine("Nombre del vendedor " + venta.Vendedor);
                            Console.WriteLine("*************Productos Comprados*****************");
                            foreach (var productos in venta.productos)
                            {
                                Console.WriteLine("Nombre del producto " + productos.Nombre + " cantida " + venta.CantidadProducto);
                                Console.WriteLine("Precio del producto " + productos.Precio);
                                total = total + (productos.Precio*venta.CantidadProducto);
                            }
                            Console.WriteLine("Valor total de la factura " + total);
                            MostrarMenuVentas();
                        }
                        break;
                    case 4: Console.WriteLine("Usted salio del modulo de ventas");  break;
                    default : Console.WriteLine("Ese numero no existe intente de nuevo"); break;
                } break;

            } while (opcion !=4);
        }

        public void Configuracion() {
            var nombreDeEmpresa = "***********************OASIS***********************";
            Console.WriteLine("***************************MODULO DE CONFIGURACION*********************************");
            Console.WriteLine("Llenar informacion automaticamente SI/NO");
            var autorizacion = Console.ReadLine();
            if (autorizacion == "si")
            {
                var cliente = new Cliente("Kevin", "Aquelarre", 123, 123); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Jose", "Pozon", 123, 234); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Jorge", "Barrio Antioquia", 123, 345); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Andrea", "Sabaneta", 123, 456); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Cintya", "Corozal", 123, 567); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Miguel", "Alexandria", 123, 678); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Sandra", "Belem", 123, 789); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Estiven", "San antonio", 123, 890); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Delcy", "Bello", 123, 901); clienteService.clientes.Add(cliente);
                cliente = new Cliente("Pipe", "Andalucia", 123, 012); clienteService.clientes.Add(cliente);

                var producto = new Producto("Papa", 2000, 10, 123); productoService.productos.Add(producto);
                producto = new Producto("Salchichon", 3000, 10, 234); productoService.productos.Add(producto);
                producto = new Producto("Yuka", 1500, 10, 345); productoService.productos.Add(producto);
                producto = new Producto("Risadas", 4000, 10, 456); productoService.productos.Add(producto);
                producto = new Producto("Pan Tajado", 3500, 10, 567); productoService.productos.Add(producto);
                producto = new Producto("Queso", 5000, 10, 678); productoService.productos.Add(producto);
                producto = new Producto("Margaritas", 2000, 10, 789); productoService.productos.Add(producto);
                producto = new Producto("Cruazan", 1500, 10, 890); productoService.productos.Add(producto);
                producto = new Producto("Manguera", 4000, 10, 901); productoService.productos.Add(producto);
                producto = new Producto("Papa Congeladas", 2000, 10, 012); productoService.productos.Add(producto);




                Console.WriteLine(nombreDeEmpresa);
                Swhich();
            }
            else {
                Console.WriteLine("************************OASIS***************************");
                productoService.productos.Clear();
                clienteService.clientes.Clear();
                Swhich();
            }

        }


    }
}
