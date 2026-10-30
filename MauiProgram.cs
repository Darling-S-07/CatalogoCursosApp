using CatalogoCursosApp.Services;
using CatalogoCursosApp.Views;
using Microsoft.Extensions.Logging;

namespace CatalogoCursosApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Servicio en memoria que simula los datos de cursos.
        // Singleton para que los cambios persistan mientras la app está abierta.
        builder.Services.AddSingleton<CursoService>();

        // Páginas registradas para inyección de dependencias (reciben CursoService).
        builder.Services.AddTransient<InicioPage>();
        builder.Services.AddTransient<CursosPage>();
        builder.Services.AddTransient<PerfilPage>();
        builder.Services.AddTransient<AcercaDePage>();
        builder.Services.AddTransient<DetalleCursoPage>();
        builder.Services.AddTransient<EditarCursoPage>();

        return builder.Build();
    }
}
