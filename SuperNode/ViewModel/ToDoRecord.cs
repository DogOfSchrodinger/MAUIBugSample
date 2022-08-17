using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperNode.ViewModel;

[Serializable]
public partial class DBToDo : NodeNotify, IKey
{
    public string content
    {
        get;
        set;
    }

    [BsonId]
    public string guid_t
    {
        get;
        set;
    }

    [BsonIgnore]
    public bool canOperation
    {
        get;
        set;
    } = false;

    public bool done
    {
        get;
        set;
    }

    [BsonIgnore]
    public bool isPC
    {
        get
        {
            return !Env.IsMoiblePlatform;
        }
    }

    //[BsonIgnore]
    //public bool canDone
    //{
    //    get
    //    {
    //        return !this.done;
    //    }
    //}

    //[BsonIgnore]
    //public bool canUnDone
    //{
    //    get
    //    {
    //        return this.done;
    //    }
    //}

    public string seconds
    {
        get;
        set;
    }

    public DBToDo()
    {
        this.guid_t = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
    }

    public override string ToString()
    {
        return content;
    }

    public string GetKey()
    {
        return this.guid_t;
    }

    public void SetKey(string key)
    {
        this.guid_t = key;
    }
}

public partial class ToDoItemDataSet : DB<DBToDo>
{
    public ObservableCollection<DBToDo> DoneItems
    {
        get;
        private set;
    }

    public ObservableCollection<DBToDo> ToDoItems
    {
        get;
        private set;
    }

    public ToDoItemDataSet()
    {
        this.DoneItems = new ObservableCollection<DBToDo>();
        this.ToDoItems = new ObservableCollection<DBToDo>();
        this.LoadDB();
        foreach (var it in this.Items)
        {
            if (it.done)
            {
                this.DoneItems.Add(it);
            }
            else
            {
                this.ToDoItems.Add(it);
            }
        }
    }

    //public void AddToDoItem()
    //{
    //    var db = new DBToDo()
    //    {
    //        guid_t = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
    //        content = Items.Count.ToString()
    //    };

    //    this.Items.Add(db);
    //    this.ToDoItems.Add(db);
    //    //this.Items.Insert(0, db);
    //    //this.ToDoItems.Insert(0, db);
    //    this.Insert(db);
    //    this.OnPropertyChanged();
    //}
}
