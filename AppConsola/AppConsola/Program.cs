using AccesoDatos.Models;
using AccesoDatos.Repositories;

// 1. Instanciamos el repositorio.
IGenericRepository<Alquiler> AlquilerRepository = new GenericRepository<Alquiler>();
IGenericRepository<Cliente> ClienteRepository = new GenericRepository<Cliente>();
IGenericRepository<Libro> LibroRepository = new GenericRepository<Libro>();
IGenericRepository<Categoria> CategoriaRepository = new GenericRepository<Categoria>();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("========================================");
    Console.WriteLine("    PLATAFORMA DE GESTIÓN DE BIBLIOTECA  ");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Agregar Cliente");
    Console.WriteLine("2. Ver Clientes");
    Console.WriteLine("3. Ver Libros Disponibles");
    Console.WriteLine("4. Registrar Alquiler / Reserva");
    Console.WriteLine("5. Devolver Libro (con penalización)");
    Console.WriteLine("6. Ver Historial de Alquileres");
    Console.WriteLine("0. Salir");
    Console.WriteLine("========================================");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();
    PresioneParaContinuar();

    switch (opcion)
    {
        case "1":
            AltaCliente();
            break;
        case "2":
            VerClientes();
            break;
        case "3":
            VerLibrosDisponibles();
            break;
        case "4":
            RegistrarAlquiler();
            break; 
        case "5":
            DevolucionLibro();
            break;
        case "6":
            HistorialAlquiler();
            break;
        case "0":
            Console.WriteLine("¡Cerrando el sistema de usuarios!");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            PresioneParaContinuar();
            break;
    }
}

void AltaCliente()
{
    Console.WriteLine("--- Registrar Nuevo Cliente ---");

    Console.Write("Ingrese el nombre del cliente: ");
    string nombre = Console.ReadLine() ?? "";

    Console.Write("Ingrese el DNI del cliente: ");
    string dni = Console.ReadLine() ?? "";

    Console.Write("Ingrese el teléfono del cliente: ");
    string telefono = Console.ReadLine() ?? "";

    Cliente nuevoCliente = new Cliente
    {
        Nombre = nombre,
        Dni = dni,
        Telefono = telefono
    };

    ClienteRepository.Agregar(nuevoCliente);
    Console.WriteLine("\nCliente agregado exitosamente.");
    PresioneParaContinuar();
}

void VerClientes() 
{
    var clientes = ClienteRepository.ObtenerTodos();
    Console.WriteLine("--- Listado de Clientes ---");

    if (!clientes.Any())
    {
        Console.WriteLine("No hay clientes registrados.");
    }
    else
    {
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.IdCliente} | Nombre: {cliente.Nombre} | DNI: {cliente.Dni} | Tel: {cliente.Telefono}");
        }
    }
    PresioneParaContinuar();
}

void VerLibrosDisponibles()
{
    var libros = LibroRepository.ObtenerTodos();
    var categorias = CategoriaRepository.ObtenerTodos();
    bool hayDisponibles = false;

    foreach (var l in libros)
    {
        if (l.Estado == "Disponible")
        {
            hayDisponibles = true;
            string nombreCategoria = "Sin categoría";

            foreach (var c in categorias)
            {
                if (c.IdCategoria == l.IdCategoria)
                {
                    nombreCategoria = c.Nombre;
                }
            }

            Console.WriteLine($"[ID: {l.IdLibro}] '{l.Titulo}' de {l.Autor} | Categoría: {nombreCategoria}");
        }
    }

    if (!hayDisponibles)
    {
        Console.WriteLine("No hay libros disponibles en este momento.");
    }

    PresioneParaContinuar();
}

void RegistrarAlquiler()
{

    Console.Write("ID del cliente: ");
    int idCliente = int.Parse(Console.ReadLine()!);

    Console.Write("ID del libro: ");
    int idLibro = int.Parse(Console.ReadLine()!);

    var cliente = ClienteRepository.ObtenerPorId(idCliente);
    var libro = LibroRepository.ObtenerPorId(idLibro);

    if (cliente == null || libro == null || libro.Estado != "Disponible")
    {
        Console.WriteLine("Cliente o libro no válido / no disponible.");
        PresioneParaContinuar();
        return;
    }

    Console.Write("Monto de reserva ($): ");
    decimal monto = decimal.Parse(Console.ReadLine()!);

    libro.Estado = "Alquilado";
    LibroRepository.Modificar(libro);

    Alquiler nuevoAlquiler = new Alquiler
    {
        IdCliente = idCliente,
        IdLibro = idLibro,
        FechaRetiro = DateTime.Now,
        FechaLimiteDevolucion = DateTime.Now.AddDays(7),
        MontoReserva = monto,
        Penalizacion = 0
    };

    AlquilerRepository.Agregar(nuevoAlquiler);

    Console.WriteLine($"\nAlquiler registrado. Límite de devolución: {nuevoAlquiler.FechaLimiteDevolucion.ToShortDateString()}");
    PresioneParaContinuar();
}

void DevolucionLibro()
{
    Console.WriteLine("--- Devolución de Libro ---");
    var alquileres = AlquilerRepository.ObtenerTodos();

    Console.WriteLine("\nAlquileres pendientes de devolución:");
    foreach (var a in alquileres)
    {
        if (a.FechaDevolucionReal == null)
        {
            Console.WriteLine($"ID Alquiler: {a.Id} | Vence: {a.FechaLimiteDevolucion.ToShortDateString()}");
        }
    }

    Console.Write("\nIngrese el ID del alquiler a devolver: ");
    int id = int.Parse(Console.ReadLine()!);

    var alquiler = AlquilerRepository.ObtenerPorId(id);
    if (alquiler == null || alquiler.FechaDevolucionReal != null)
    {
        Console.WriteLine("Alquiler no encontrado o ya devuelto.");
        PresioneParaContinuar();
        return;
    }

    alquiler.FechaDevolucionReal = DateTime.Now;

   
    if (alquiler.FechaDevolucionReal.Value.Date > alquiler.FechaLimiteDevolucion.Date)
    {
        int dias = (alquiler.FechaDevolucionReal.Value.Date - alquiler.FechaLimiteDevolucion.Date).Days;
        alquiler.Penalizacion = dias * alquiler.TARIFA_PENALIZACION_DIARIA;
        Console.WriteLine($"Devolución con demora ({dias} días). Penalización: ${alquiler.Penalizacion}");
    }
    else
    {
        alquiler.Penalizacion = 0;
        Console.WriteLine("Devolución a término. Sin penalización.");
    }

  
    AlquilerRepository.Modificar(alquiler);

 
    var libro = LibroRepository.ObtenerPorId(alquiler.IdLibro);
    if (libro != null)
    {
        libro.Estado = "Disponible";
        LibroRepository.Modificar(libro);
    }

    Console.WriteLine("Libro disponible nuevamente.");
    PresioneParaContinuar();
}

void HistorialAlquiler()
{
    var alquileres = AlquilerRepository.ObtenerTodos();
    Console.WriteLine("--- Historial de Alquileres ---");
    if (!alquileres.Any())
    {
        Console.WriteLine("No hay registros de alquileres.");
    }
    else
    {
        foreach (var a in alquileres)
        {
            string estado = a.FechaDevolucionReal == null ? "Pendiente" : "Devuelto";
            Console.WriteLine($"ID: {a.Id} | Cliente ID: {a.IdCliente} | Libro ID: {a.IdLibro} | Retiro: {a.FechaRetiro.ToShortDateString()} | Límite: {a.FechaLimiteDevolucion.ToShortDateString()} | Devolución: {(a.FechaDevolucionReal?.ToShortDateString() ?? "N/A")} | Penalización: ${a.Penalizacion} | Estado: {estado}");
        }
    }
    PresioneParaContinuar();
}

void PresioneParaContinuar()
{
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
    Console.Clear();

}

