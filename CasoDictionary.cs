using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

public class CasoDictionary
{
    // Crear un diccionario donde la clave sea el legajo (Id) y el valor el alumno
    private Dictionary<int, Alumno> _diccionarioAlumnos = new Dictionary<int, Alumno>();

    // Incluir un método para agregar un alumno al diccionario
    public void AgregarAlumno(Alumno alumno)
    {
        // Usamos el Id como legajo/clave
        _diccionarioAlumnos[alumno.Id] = alumno;
    }

    // Incluir un método para buscar un alumno utilizando la clave
    public Alumno? BuscarPorLegajo(int legajo)
    {
        _diccionarioAlumnos.TryGetValue(legajo, out var alumno);
        return alumno;
    }

    // Incluir un método para retornar el diccionario
    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return _diccionarioAlumnos;
    }

    // Incluir un método para eliminar un alumno utilizando la clave
    public void EliminarPorLegajo(int legajo)
    {
        _diccionarioAlumnos.Remove(legajo);
    }
}