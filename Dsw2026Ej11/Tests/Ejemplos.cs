using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;

internal class Ejemplos
{
    public static void EjemploList()
    {
        var caso = new CasoList();

        // Agregar 3 alumnos
        caso.AgregarAlumno(new Alumno(1, "Juan Perez", 8.5));
        caso.AgregarAlumno(new Alumno(2, "Maria Garcia", 9.2));
        caso.AgregarAlumno(new Alumno(3, "Pedro Rodriguez", 7.0));

        // Listar por consola
        Console.WriteLine("--- Lista inicial ---");
        caso.ObtenerAlumnos().ForEach(Console.WriteLine);

        // Buscar por nombre que exista
        Console.WriteLine("\nBuscando a Maria Garcia:");
        var a1 = caso.BuscarPorNombre("Maria Garcia");
        Console.WriteLine(a1?.ToString() ?? "No existe");

        // Buscar por nombre que NO exista
        Console.WriteLine("\nBuscando a Carlos:");
        var a2 = caso.BuscarPorNombre("Carlos");
        Console.WriteLine(a2?.ToString() ?? "No existe");

        // Eliminar un alumno y listar
        Console.WriteLine("\nEliminando a Juan Perez...");
        var juan = caso.BuscarPorNombre("Juan Perez");
        if (juan != null) caso.EliminarAlumno(juan);
        caso.ObtenerAlumnos().ForEach(Console.WriteLine);

        // Eliminar el primer elemento y listar
        Console.WriteLine("\nEliminando el primer elemento de la lista...");
        caso.EliminarEnPosicion(0);
        caso.ObtenerAlumnos().ForEach(Console.WriteLine);
    }

    public static void EjemploDictionary()
    {
        var caso = new CasoDictionary();

        // Agregar 3 alumnos
        caso.AgregarAlumno(new Alumno(101, "Ana Lopez", 9.0));
        caso.AgregarAlumno(new Alumno(102, "Luis Sosa", 6.5));
        caso.AgregarAlumno(new Alumno(103, "Sofia Paz", 8.0));

        // Listar por consola
        Console.WriteLine("--- Diccionario inicial ---");
        foreach (var item in caso.ObtenerDiccionario())
            Console.WriteLine($"Legajo: {item.Key} | Datos: {item.Value}");

        // Buscar por clave que exista
        Console.WriteLine("\nBuscando legajo 102:");
        var alu = caso.BuscarPorLegajo(102);
        Console.WriteLine(alu?.ToString() ?? "No existe");

        // Buscar por clave que NO exista
        Console.WriteLine("\nBuscando legajo 999:");
        var alu2 = caso.BuscarPorLegajo(999);
        Console.WriteLine(alu2?.ToString() ?? "No existe");

        // Eliminar por clave y listar
        Console.WriteLine("\nEliminando legajo 101...");
        caso.EliminarPorLegajo(101);
        foreach (var item in caso.ObtenerDiccionario())
            Console.WriteLine(item.Value);
    }

    public static void EjemploLinq()
    {
        var caso = new CasoLinq();
        // Usamos el método estático de tu clase Libro
        var libros = Libro.CrearLista();

        Console.WriteLine($"1. Primero: {caso.GetPrimero(libros)?.Titulo}");
        Console.WriteLine($"2. Último: {caso.GetUltimo(libros)?.Titulo}");
        Console.WriteLine($"3. Suma de precios: {caso.GetTotalPrecios(libros):C}");
        Console.WriteLine($"4. Promedio de precios: {caso.GetPromedioPrecios(libros):C}");

        Console.WriteLine("\n5. Libros con ID > 15:");
        caso.GetListById(libros).ForEach(l => Console.WriteLine($"ID: {l.Id} - {l.Titulo}"));

        Console.WriteLine("\n6. Lista de Títulos y Precios:");
        caso.GetLibros(libros).ForEach(Console.WriteLine);

        var mayor = caso.GetMayorPrecio(libros);
        Console.WriteLine($"\n7. Libro más caro: {mayor?.Titulo} ({mayor?.Precio:C})");

        var menor = caso.GetMenorPrecio(libros);
        Console.WriteLine($"8. Libro más barato: {menor?.Titulo} ({menor?.Precio:C})");

        Console.WriteLine("\n9. Libros con precio mayor al promedio:");
        caso.GetMayorPromedio(libros).ForEach(l => Console.WriteLine($"{l.Titulo} ({l.Precio:C})"));

        Console.WriteLine("\n10. Orden Descendente por Título (Top 5):");
        caso.GetOrderByTituloDesc(libros).Take(5).ToList().ForEach(l => Console.WriteLine(l.Titulo));
    }
}
