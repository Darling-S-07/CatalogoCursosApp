using CatalogoCursosApp.Services;

namespace CatalogoCursosApp.Views;

public partial class CursosPage : ContentPage
{
    private readonly CursoService _cursoService;

    public CursosPage(CursoService cursoService)
    {
        InitializeComponent();
        _cursoService = cursoService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Se vuelve a cargar la lista cada vez que aparece la página,
        // así se reflejan los cambios hechos en EditarCursoPage.
        ListaCursos.ItemsSource = _cursoService.ObtenerTodos();
    }

    private async void OnVerDetalleClicked(object sender, EventArgs e)
    {
        if (sender is Button boton && boton.CommandParameter is int cursoId)
        {
            // Navegación con Shell enviando el Id por query string.
            await Shell.Current.GoToAsync($"{nameof(DetalleCursoPage)}?CursoId={cursoId}");
        }
    }
}
