using Microsoft.AspNetCore.Components.WebView.Maui;
using Prezenta_4.Data;
using Prezenta_4.Services;

namespace Prezenta_4;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		Console.WriteLine(DateOnly.FromDateTime(DateTime.Now));
		var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Prezente.db3");


		builder.Services.AddSingleton<IMaterieService, MaterieServices>(p => ActivatorUtilities.CreateInstance<MaterieServices>(p, dbPath));
		builder.Services.AddSingleton<IPrezentaMaterie, PrezentaMaterieServices>(p => ActivatorUtilities.CreateInstance<PrezentaMaterieServices>(p, dbPath));

		return builder.Build();
	}
}
