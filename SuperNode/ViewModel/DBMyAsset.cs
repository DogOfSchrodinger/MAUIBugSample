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
public partial class DBMyAsset : NodeNotify, IKey
{
    public string platform
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
    public string user
    {
        get;
        set;
    }
    public string code
    {
        get;
        set;
    }
    public string email
    {
        get;
        set;
    }
    public string phone
    {
        get;
        set;
    }

    public string note
    {
        get;
        set;
    }

    public string link
    {
        get;
        set;
    }
    /// <summary>
    /// 创建时间
    /// </summary>
    public string t_create
    {
        get;
        set;
    }

    public string GetKey()
    {
        return this.t_create;
    }

    public void SetKey(string key)
    {
        this.guid_t = key;
    }
}

public partial class DBMyAssetSet : DB<DBMyAsset>
{
    public static readonly DBMyAssetSet ins = new DBMyAssetSet();
    private DBMyAssetSet()
    {
        this.LoadDB();
    }
}
