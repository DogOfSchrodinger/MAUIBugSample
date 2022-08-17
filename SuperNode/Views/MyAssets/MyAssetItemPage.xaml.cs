using SuperNode.ViewModel;

namespace SuperNode.Views.MyAssets;

[QueryProperty(nameof(DBMyAsset), "DBMyAsset")]
public partial class MyAssetItemPage : ContentPage
{
    public DBMyAsset db;
    public DBMyAsset DBMyAsset
    {
        get
        { return this.db; }
        set
        {
            this.db = value;
            BindingContext = value;
            OnPropertyChanged();
        }
    }
    public MyAssetItemPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        db.OnPropertyChanged();
        DBMyAssetSet.ins.UpdateDB(this.db);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        DBMyAssetSet.ins.Items.Remove(this.db);
        DBMyAssetSet.ins.Delete(this.db);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}