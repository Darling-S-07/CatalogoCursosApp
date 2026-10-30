using CatalogoCursosApp.Models;

namespace CatalogoCursosApp.Services;

// Servicio simple en memoria que simula una "base de datos" de cursos.
// Se registra como Singleton para que los cambios (editar) se mantengan
// mientras la app esté abierta.
public class CursoService
{
    private readonly List<Curso> _cursos;

    public CursoService()
    {
        _cursos = new List<Curso>
        {
            new Curso
            {
                Id = 1,
                Titulo = "Introducción a C#",
                Descripcion = "Aprende los fundamentos del lenguaje C# desde cero.",
                Instructor = "Carlos Martínez",
                DuracionHoras = 20,
                Categoria = "Programación"
            },
            new Curso
            {
                Id = 2,
                Titulo = "Desarrollo con .NET MAUI",
                Descripcion = "Crea aplicaciones multiplataforma con .NET MAUI.",
                Instructor = "Ana Gómez",
                DuracionHoras = 35,
                Categoria = "Desarrollo Móvil"
            },
            new Curso
            {
                Id = 3,
                Titulo = "Bases de Datos SQL",
                Descripcion = "Diseño y consultas en bases de datos relacionales.",
                Instructor = "Luis Fernández",
                DuracionHoras = 25,
                Categoria = "Bases de Datos"
            },
            new Curso
            {
                Id = 4,
                Titulo = "Patrones de Diseño en C#",
                Descripcion = "Aplica patrones de diseño comunes en tus proyectos.",
                Instructor = "María Rodríguez",
                DuracionHoras = 15,
                Categoria = "Programación"
            },
            new Curso
            {
                Id = 5,
                Titulo = "APIs REST con ASP.NET Core",
                Descripcion = "Construye servicios web con ASP.NET Core.",
                Instructor = "Jorge Pérez",
                DuracionHoras = 30,
                Categoria = "Backend"
            },
        };
    }

    public List<Curso> ObtenerTodos() => _cursos;

    public Curso? ObtenerPorId(int id) => _cursos.FirstOrDefault(c => c.Id == id);

    public void Actualizar(Curso cursoActualizado)
    {
        var curso = ObtenerPorId(cursoActualizado.Id);
        if (curso is null) return;

        curso.Titulo = cursoActualizado.Titulo;
        curso.Descripcion = cursoActualizado.Descripcion;
        curso.Instructor = cursoActualizado.Instructor;
        curso.DuracionHoras = cursoActualizado.DuracionHoras;
        curso.Categoria = cursoActualizado.Categoria;
    }
}
