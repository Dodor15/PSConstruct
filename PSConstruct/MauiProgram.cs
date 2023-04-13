﻿using Microsoft.Extensions.Logging;
using PSConstruct.DBClasses;

namespace PSConstruct;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddTransient<ConfigContext>((services) => { return new ConfigContext(Path.Combine(FileSystem.AppDataDirectory, "config.db3")); });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
