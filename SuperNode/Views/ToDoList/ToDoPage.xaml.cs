using Microsoft.Maui;
using Microsoft.Maui.Controls;
using SuperNode.ViewModel;
using System.Collections.Specialized;
using System.Globalization;

#if ANDROID
using static Android.Content.ClipData;
#endif

namespace SuperNode;

public partial class ToDoPage : ContentPage
{
    private ToDoItemDataSet set;
    public ToDoPage()
    {
        InitializeComponent();
        this.set = new ToDoItemDataSet();
        BindingContext = this.set;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var action = await this.DisplayActionSheet("", "Done", "Save", "Done", "UnDone");
    }

    //private void OnTapToDoItemView(object sender, EventArgs e)
    //{
    //    var frame = sender as ContentView;
    //    if (frame != null)
    //    {
    //        var item = frame.BindingContext as DBToDo;
    //        if (item != null)
    //        {
    //            item.OnPropertyChanged(nameof(item.canDone));
    //            item.OnPropertyChanged(nameof(item.canUnDone));
    //        }
    //    }
    //}

    private void OnClickToDoItemViewDeleteBtn(object sender, EventArgs e)
    {
        var btn = sender as BindableObject;
        if (btn != null)
        {
            var db = btn.BindingContext as DBToDo;
            if (db != null)
            {
                this.OnDeleteItem(db);
            }
        }
    }

    private void OnClickToDoItemViewDoneBtn(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            var item = btn.BindingContext as DBToDo;
            if (item != null)
            {
                this.OnDoneItem(item);
            }
        }
    }
    private void ToolBar_AddItem(object sender, EventArgs e)
    {
        var db = new DBToDo()
        {
            content = this.set.Items.Count.ToString(),
            seconds = DateTime.Now.ToString("MM/dd HH:mm:ss"),
        };
        this.set.Items.Insert(0, db);
        this.set.ToDoItems.Insert(0, db);
        this.set.Insert(db);
    }

    private void OnDeleteItem(DBToDo db)
    {
        this.set.DoneItems.Remove(db);
        this.set.ToDoItems.Remove(db);
        this.set.Items.Remove(db);
        this.set.Delete(db);
    }

    private void OnDoneItem(DBToDo db)
    {
        db.done = true;
        db.OnPropertyChanged(nameof(db.done));
        if (this.set.DoneItems.Contains(db))
        {
            return;
        }
        this.set.ToDoItems.Remove(db);
        this.set.DoneItems.Insert(0, db);
        this.set.UpdateDB(db);
    }

    private void OnUnDoneItem(DBToDo db)
    {
        db.done = false;
        db.OnPropertyChanged(nameof(db.done));
        if (this.set.ToDoItems.Contains(db))
        {
            return;
        }
        this.set.DoneItems.Remove(db);
        this.set.ToDoItems.Insert(0, db);
        this.set.UpdateDB(db);
    }

    private void Editor_Completed(object sender, EventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            db.canOperation = false;
            db.OnPropertyChanged(nameof(db.canOperation));
            this.set.UpdateDB(db);
        }
    }

    private void Editor_Unfocused(object sender, FocusEventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            db.canOperation = false;
            db.OnPropertyChanged(nameof(db.canOperation));
            this.set.UpdateDB(db);
        }
    }

    private void SwipeItem_UnDoneItem(object sender, EventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            this.OnUnDoneItem(db);
        }
    }

    private void SwipeItem_DeleteItem(object sender, EventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            this.OnDeleteItem(db);
        }
    }

    private void CheckBox_CheckedChangedDone(object sender, CheckedChangedEventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            this.OnDoneItem(db);
        }
    }

    private void CheckBox_CheckedChangedUnDone(object sender, CheckedChangedEventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            this.OnUnDoneItem(db);
        }
    }


    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            if (e.Value)
            {
                this.OnDoneItem(db);
            }
            else
            {
                this.OnUnDoneItem(db);
            }
        }
    }

    private void ClickGestureRecognizer_Clicked(object sender, EventArgs e)
    {
        //var db = sender.GetBindConetxt<DBToDo>();
        //if (db != null)
        //{
        //    db.canOperation = true;
        //    db.OnPropertyChanged(nameof(db.canOperation));
        //}
    }



    private void Border_Unfocused(object sender, FocusEventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            db.canOperation = false;
            db.OnPropertyChanged(nameof(db.canOperation));
            this.set.UpdateDB(db);
        }
    }

    private void Border_Focused(object sender, FocusEventArgs e)
    {
        //var db = sender.GetBindConetxt<DBToDo>();
        //if (db != null)
        //{
        //    db.canOperation = true;
        //    db.OnPropertyChanged(nameof(db.canOperation));
        //    this.set.UpdateDB(db);
        //}
    }

    private void Editor_Focused(object sender, FocusEventArgs e)
    {
        var db = sender.GetBindConetxt<DBToDo>();
        if (db != null)
        {
            db.canOperation = true;
            db.OnPropertyChanged(nameof(db.canOperation));
        }
    }
}

