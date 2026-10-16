using AccesoDatos.Models;
using AccesoDatos.Repositories;

// 1. Instanciamos el repositorio.
IGenericRepository<Artista> ArtistaRepository = new GenericRepository<Artista>();
IGenericRepository<Cancion> CancionRepository = new GenericRepository<Cancion>();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("Plataforma de musica");
    Console.WriteLine();
    Console.WriteLine("1. Agregar Artista");
    Console.WriteLine("2. Agregar cancion");
    Console.WriteLine("3. Ver canciones");
    Console.WriteLine("4. Ver canciones mas largas");
    Console.WriteLine("5. Ver Cantidad de Canciones");
    Console.WriteLine("6. Ver Canciones ordenadas Alfabeticamente");
    Console.WriteLine("7. Registrar si hay canciones");
    Console.WriteLine("0. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();
    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaArtista();
            break;
        case "2":
            Altacancion();
            break;
        case "3":
            VerCanciones();
            break;
        case "4":
            CancionesMasLargas();
            break;
        case "5":
            CantidadCanciones();
            break;
        case "6":
            CancionesOrdenadas();
            break;
        case "7":
            ExisteCancion();
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

void AltaArtista()
{
    Console.WriteLine("Ingrese el nombre del Artista: ");
    string name = Console.ReadLine();

    Console.WriteLine("Ingrese el apellido del Artista: ");
    string lastName = Console.ReadLine();

    var nuevoArtista = new Artista
    {
        Name = name,
        LastName = lastName,
    };

    ArtistaRepository.Agregar(nuevoArtista);
    Console.WriteLine("Artista agregado exitosamente.");
    PresioneParaContinuar();
}

void Altacancion()
{
    void Altacancion()
    {

        GenericRepository<Artista> repoArtistas = new GenericRepository<Artista>();
        List<Artista> listaArtistas = repoArtistas.ObtenerTodos();

        if (listaArtistas.Count == 0)
        {
            Console.WriteLine("No hay artistas registrados");
            Console.WriteLine("Presione una tecla para continuar");
            PresioneParaContinuar();
        }

        Console.WriteLine("Artistas registrados:");
        foreach (Artista a in listaArtistas)
        {
            Console.WriteLine($"ID: {a.Id} | Nombre: {a.Name}");
        }

        Console.WriteLine("Ingrese el ID del artista para la canción: ");
        int artistaId = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nombre de la canción: ");
        string nombrecancion = Console.ReadLine();

        Console.WriteLine("Ingrese la duración en segundos de la canción: ");
        int duracion = Convert.ToInt32(Console.ReadLine());

        Cancion nuevaCancion = new Cancion
        {
            titulo = nombrecancion,
            duracionsegundos= duracion,
            ArtistaId = artistaId
        };

        GenericRepository<Cancion> repoCanciones = new GenericRepository<Cancion>();
        repoCanciones.Agregar(nuevaCancion);

        Console.WriteLine("Canción registrada");
        Console.WriteLine("Presione una tecla para continuar");
        PresioneParaContinuar();
    }
}

void VerCanciones()
{
    Console.WriteLine("TODAS LAS CANCIONES");
    GenericRepository<Cancion> repoCanciones = new GenericRepository<Cancion>();
    List<Cancion> listaCanciones = repoCanciones.ObtenerTodos();
    if (listaCanciones.Count == 0) 
    {
        Console.WriteLine("No hay canciones registradas");
    }
    else 
    {
        foreach (Cancion c in listaCanciones) 
        {
            Console.WriteLine(c.id);
            Console.WriteLine(c.titulo);
            Console.WriteLine(c.duracionsegundos);
            Console.WriteLine(c.ArtistaId);
        }
    }
    Console.WriteLine("Presione una tecla para continuar");
    PresioneParaContinuar();
}

void CancionesMasLargas() 
{
    Console.WriteLine("CANCIONES MAS LARGAS");
    GenericRepository<Cancion> repoCanciones = new GenericRepository<Cancion>();
    List<Cancion> listaCanciones = repoCanciones.ObtenerTodos();
    if (listaCanciones.Count == 0)
    {
        Console.WriteLine("No hay canciones registradas");
    }
    else 
    {
        var CancionesOrdenadas= listaCanciones.OrderByDescending(c => c.duracionsegundos).ToList();
        foreach (Cancion c in CancionesOrdenadas) 
        {
            Console.WriteLine(c.id);
            Console.WriteLine(c.titulo);
            Console.WriteLine(c.duracionsegundos);
            Console.WriteLine(c.ArtistaId);
        }
    }
    Console.WriteLine("Presione una tecla para continuar");
    PresioneParaContinuar();
}

void CantidadCanciones() 
{
    Console.WriteLine("TODAS LAS CANCIONES");
    GenericRepository<Cancion> repoCanciones = new GenericRepository<Cancion>();
    List<Cancion> listaCanciones = repoCanciones.ObtenerTodos();
    int totalcanciones= listaCanciones.Count;
    Console.WriteLine("La cantidad de canciones registradas es:  {totalcanciones}");
    Console.WriteLine("Presione una tecla para continuar");
    PresioneParaContinuar();
}

void CancionesOrdenadas() 
{
    Console.WriteLine("CANCIONES ORDENADAS ALFABETICAMENTE");
    GenericRepository<Cancion> repoCanciones = new GenericRepository<Cancion>();
    List<Cancion> listaCanciones = repoCanciones.ObtenerTodos();
    var CancionesOrdenadasAlfabeticamente = listaCanciones.OrderByDescending(c => c.titulo).ToList();
    foreach (Cancion c in listaCanciones) 
    {
        Console.WriteLine(c.id);
        Console.WriteLine(c.titulo);
        Console.WriteLine(c.duracionsegundos);
        Console.WriteLine(c.ArtistaId);
    }
    Console.WriteLine("Presione una tecla para continuar");
    PresioneParaContinuar();
}


void ExisteCancion() 
{
    Console.WriteLine("¿HAY CANCIONES REGISTRADAS?");
    GenericRepository<Cancion> repoCanciones = new GenericRepository<Cancion>();
    List<Cancion> listaCanciones = repoCanciones.ObtenerTodos();
    if (listaCanciones.Count == 0)
    {
        Console.WriteLine("No hay canciones registradas");
    }
    Console.WriteLine("Presione una tecla para continuar");
    PresioneParaContinuar();
} 


void PresioneParaContinuar()
{
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
    Console.Clear();

}

