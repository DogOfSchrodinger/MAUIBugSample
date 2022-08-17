using Microsoft.Maui.Controls;
using SuperNode.ViewModel;
using SuperNode.Views.MyAssets;

namespace SuperNode;

public partial class MyAssetPage : ContentPage
{
    private DBMyAssetSet set;
    public MyAssetPage()
    {
        InitializeComponent();
        BindingContext = this.set = DBMyAssetSet.ins;
    }

    private void ToolBarItem_Add(object sender, EventArgs e)
    {
        var db = new DBMyAsset { guid_t = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() };
        var args = new Dictionary<string, object>
        {
            { nameof(DBMyAsset),db },
        };
        DBMyAssetSet.ins.Items.Add(db);
        DBMyAssetSet.ins.Insert(db);
        Shell.Current.GoToAsync(nameof(MyAssetItemPage), args);
    }

    private void Border_ClickGestureRecognizer_Clicked(object sender, EventArgs e)
    {
        var db = sender.GetBindConetxt<DBMyAsset>();
        if (db != null)
        {
            var args = new Dictionary<string, object>
        {
            { nameof(DBMyAsset),db },
        };
            Shell.Current.GoToAsync(nameof(MyAssetItemPage), args);
        }
    }
}

