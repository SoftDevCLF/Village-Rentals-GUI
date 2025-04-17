using Microsoft.Extensions.Logging;
using VillageRentalsGUI.Data;

namespace VillageRentalsGUI;

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
		builder.Logging.AddDebug();
#endif

        
		// JSON Serializer
        builder.Services.AddSingleton<JsonStorageService>();

        return builder.Build();
	}


}
