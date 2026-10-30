using CatalogoCursosApp.Models;
using CatalogoCursosApp.Services;

namespace CatalogoCursosApp.Views;

public partial class EditarCursoPage : ContentPage, IQueryAttributable
{
    private readonly CursoService _cursoService;
    private Curso? _curso;

    public EditarCursoPage(CursoService cursoService)
    {
        InitializeComponent();
        _cursoService = cursoService;
    }

    // Recibe el objeto Curso completo enviado por diccionario desde DetalleCursoPage.
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Curso", out var valor) && valor is Curso curso)
        {
            _curso = curso;
            CargarFormulario();
        }
    }

    private void CargarFormulario()
    {
        if (_curso is null) return;

        EntryTitulo.Text = _curso.Titulo;
        EntryDescripcion.Text = _curso.Descripcion;
        EntryInstructor.Text = _curso.Instructor;
        EntryDuracion.Text = _curso.DuracionHoras.ToString();
        EntryCategoria.Text = _curso.Categoria;
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (_curso is null) return;

        _curso.Titulo = EntryTitulo.Text ?? string.Empty;
        _curso.Descripcion = EntryDescripcion.Text ?? string.Empty;
        _curso.Instructor = EntryInstructor.Text ?? string.Empty;
        _curso.Categoria = EntryCategoria.Text ?? string.Empty;

        if (int.TryParse(EntryDuracion.Text, out var duracion))
            _curso.DuracionHoras = duracion;

        _cursoService.Actualizar(_curso);

        // Regresa a la página anterior (DetalleCursoPage), que
        // actualizará los datos mostrados en su propio OnAppearing.
        await Shell.Current.GoToAsync("..");
    }
}
