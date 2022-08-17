//using Kotlin.Contracts;
using LiteDB;
using SuperNode.StarGraph;
using SuperNode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode
{
    public static class Extensions
    {
        public static T GetBindConetxt<T>(this object obj)
        {
            var bindobj = obj as BindableObject;
            if (bindobj != null)
            {
                return (T)bindobj.BindingContext;
            }
            return default(T);
        }
    }
}
