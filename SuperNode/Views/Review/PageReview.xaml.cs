using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SuperNode.ViewModel;

namespace SuperNode;

public partial class PageReview : ContentPage
{
    private ReviewRecordSet set;
    public PageReview()
    {
        InitializeComponent();
        this.set = new ReviewRecordSet();
        BindingContext = this.set;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        this.DisplayAlert("fdsaf", "fdsaf", "ok");
    }

    private void OnClickToDoItemViewDeleteBtn(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            this.set.Items.Remove(btn.BindingContext as ReviewRecord);
        }
    }

    private void OnClickToDoItemViewSaveBtn(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            this.set.SaveDB();
            var item = btn.BindingContext as ReviewRecord;
            if (item != null)
            {
                item.canOperation = !item.canOperation;
                item.OnPropertyChanged(nameof(item.canOperation));
            }
        }
    }

    private void Editor_Completed(object sender, EventArgs e)
    {
        this.set.SaveDB();
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        {
            var item = e.PreviousSelection?.FirstOrDefault() as ReviewRecord;
            if (item != null)
            {
                item.canOperation = false;
                item.OnPropertyChanged(nameof(item.canOperation));
            }
        }
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            this.set.Items.Add(new ReviewRecord()
            {
                content = this.set.Items.Count.ToString()
            });
            this.set.SaveDB();
            return Task.CompletedTask;
        });
    }
}

