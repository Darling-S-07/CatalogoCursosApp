namespace CatalogoCursosApp.Models;

public class Curso
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public int DuracionHoras { get; set; }
    public string Categoria { get; set; } = string.Empty;
}
