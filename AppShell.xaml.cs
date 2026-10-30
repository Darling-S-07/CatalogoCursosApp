using CatalogoCursosApp.Views;

namespace CatalogoCursosApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Rutas registradas para páginas que no están en el árbol visual
        // del Shell (se navega a ellas por código).
        Routing.RegisterRoute(nameof(DetalleCursoPage), typeof(DetalleCursoPage));
        Routing.RegisterRoute(nameof(EditarCursoPage), typeof(EditarCursoPage));
    }

    private async void OnSalirClicked(object sender, EventArgs e)
    {
        bool confirmar = await Current.DisplayAlertAsync(
            "Salir",
            "¿Seguro que deseas salir de la aplicación?",
            "Sí", "No");

        if (confirmar)
        {
            Application.Current?.Quit();
        }
    }
}
