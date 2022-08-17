using CommunityToolkit.Mvvm.Input;
using LiteDB;
using SuperNode.StarGraph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.ViewModel;

[Serializable]
public partial class DBNode : NodeNotify, INodeValue
{
    /// <summary>
    /// 创建时间,毫秒
    /// </summary>
    [BsonId]
    public string guid_t
    {
        get;
        set;
    }
    public string parent
    {
        get;
        set;
    }
    public string content
    {
        get;
        set;
    }

    public string GetKey()
    {
        return guid_t;
    }

    public void SetKey(string key)
    {
        guid_t = key;
    }

    public void SetParent(string key)
    {
        parent = key;
    }


    public static DBNode FromContent(string name)
    {
        var rd = new DBNode();
        rd.content = name;
        rd.guid_t = IDGenerator.ins.Require().ToString();
        return rd;
    }
}

public partial class DBNodeSet : DB<DBNode>
{
    public ObservableCollection<DBNode> RootItems
    {
        get;
        set;
    }

    public DBNodeSet()
    {
        Flags = DBFlags.UseMap;
        RootItems = new ObservableCollection<DBNode>();
        //Storage.ins.DeleteTable<DBNode>();
        LoadDB();
        InitRootNodes();
    }

    public static readonly DBNodeSet ins = new DBNodeSet();

    private void InitRootNodes()
    {
        foreach (var it in Items)
        {
            if (string.IsNullOrEmpty(it.parent))
            {
                RootItems.Add(it);
            }
        }
    }

    public void AddRoot(string name)
    {
        if (this.Items.FirstOrDefault(it => it.content == name) != null)
            return;
        var rd = DBNode.FromContent(name);
        this.RootItems.Add(rd);
        this.Items.Add(rd);
        this.Insert(rd);
    }
}
