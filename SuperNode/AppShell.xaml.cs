using SuperNode.Views.MyAssets;

namespace SuperNode;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MyAssetItemPage), typeof(MyAssetItemPage));
		//Routing.RegisterRoute(nameof(AppTabbedPage), typeof(AppTabbedPage));
		//this.GoToAsync(nameof(AppTabbedPage));
	}
}
