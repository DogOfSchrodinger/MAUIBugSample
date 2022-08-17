using SuperNode.ViewModel;
using SuperNode.Views.MyAssets;

namespace SuperNode;

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
        //builder.ConfigureMauiHandlers();
        //builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<AppTabbedPage>();
        builder.Services.AddSingleton<PageReview>();
        builder.Services.AddSingleton<ToDoPage>();
        builder.Services.AddSingleton<MyAssetPage>();

        builder.Services.AddTransient<ToDoItemDataSet>();
		builder.Services.AddTransient<MyAssetItemPage>();
		builder.Services.AddTransient<Storage>();
        return builder.Build();
    }
}
