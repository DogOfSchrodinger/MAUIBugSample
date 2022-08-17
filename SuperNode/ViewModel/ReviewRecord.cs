using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

public partial class ReviewRecord : NodeNotify, IKey
{
    public string content
    {
        get;
        set;
    }

    public string id
    {
        get;
        set;
    }

    public bool canOperation
    {
        get;
        set;
    }

    public string seconds
    {
        get;
        set;
    }

    public ReviewRecord()
    {
        canOperation = false;
        seconds = DateTimeOffset.Now.ToString();
    }

    public override string ToString()
    {
        return content;
    }

    public string GetKey()
    {
        return this.id;
    }

    public void SetKey(string key)
    {
        this.id = key;
    }
}

public partial class ReviewRecordSet : DB<ReviewRecord>
{
    public ReviewRecordSet()
    {
        this.LoadDB();
    }
}
