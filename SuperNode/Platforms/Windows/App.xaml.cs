﻿using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using SuperNode.StarGraph;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SuperNode.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();

        this.AcceptTabOnWindowPlatform();
    }

    public void AcceptTabOnWindowPlatform()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(MyEntry), (handler, view) =>
        {
            var entry = view as MyEntry;
            if (entry != null)
            {
                handler.PlatformView.KeyDown += (sender, e) => {
                    e.Handled = entry.OnKeyDown((SuperNode.KeyCode)e.Key);
                };
            }
        });
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

