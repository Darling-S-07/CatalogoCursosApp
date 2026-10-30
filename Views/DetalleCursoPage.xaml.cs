using CatalogoCursosApp.Models;
using CatalogoCursosApp.Services;

namespace CatalogoCursosApp.Views;

// Recibe el Id del curso por query string: "DetalleCursoPage?CursoId=3"
// OJO: NO se llama "Id" porque ContentPage/Element ya tiene una propiedad
// "Id" (Guid) heredada; usar el mismo nombre genera un choque de nombres
// que hace fallar la reflexión interna de Shell al navegar (crash).
[QueryProperty(nameof(CursoId), "CursoId")]
public partial class DetalleCursoPage : ContentPage
{
    private readonly CursoService _cursoService;

    public int CursoId { get; set; }

    private Curso? _curso;

    public DetalleCursoPage(CursoService cursoService)
    {
        InitializeComponent();
        _cursoService = cursoService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Se recarga el curso cada vez que la página aparece,
        // por ejemplo al regresar desde EditarCursoPage con "..".
        CargarCurso();
    }

    private void CargarCurso()
    {
        _curso = _cursoService.ObtenerPorId(CursoId);
        if (_curso is null)
            return;

        LblTitulo.Text = _curso.Titulo;
        LblDescripcion.Text = _curso.Descripcion;
        LblInstructor.Text = $"Instructor: {_curso.Instructor}";
        LblDuracion.Text = $"Duración: {_curso.DuracionHoras} horas";
        LblCategoria.Text = $"Categoría: {_curso.Categoria}";
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        if (_curso is null) return;

        // Se envía el objeto Curso completo mediante un diccionario
        // de parámetros de navegación de Shell.
        var parametros = new Dictionary<string, object>
        {
            { "Curso", _curso }
        };

        await Shell.Current.GoToAsync(nameof(EditarCursoPage), parametros);
    }
}
