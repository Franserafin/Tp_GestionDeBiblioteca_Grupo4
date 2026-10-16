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

void PresioneParaContinuar()
{
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
    Console.Clear();

}

