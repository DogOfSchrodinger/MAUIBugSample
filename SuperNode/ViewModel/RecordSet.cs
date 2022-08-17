using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.ViewModel
{
    public enum DBFlags
    {
        None,
        UseMap = 1 << 0,
    }

    public class DB<T> : NodeNotify where T : IKey
    {
        public ObservableCollection<T> Items
        {
            get;
            private set;
        }

        public Dictionary<string, T> map
        {
            get
            {
                if (Flags.HasFlag(DBFlags.UseMap))
                {
                    return this.map_;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        private Dictionary<string, T> map_;

        public DBFlags Flags { get; set; }

        public DB()
        {
            this.map_ = new Dictionary<string, T>();
            this.Items = new ObservableCollection<T>();
        }

        public void SaveDB()
        {
            throw new NotSupportedException();
        }

        public void UpdateDB(T entity)
        {
            Storage.ins.UpdateDB(entity);
        }

        public bool Insert(T entity)
        {
            if (this.Flags.HasFlag(DBFlags.UseMap))
            {
                this.map.Add(entity.GetKey(), entity);
            }
            return Storage.ins.InsertDB(entity);
        }

        public bool Delete(T entity)
        {
            if (this.Flags.HasFlag(DBFlags.UseMap))
            {
                this.map.Remove(entity.GetKey());
            }
            return Storage.ins.DeleteDB(entity);
        }

        public void LoadDB()
        {
            this.Items.Clear();
            var arr = Storage.ins.LoadArray<T>();
            foreach (var item in arr)
            {
                this.Items.Add(item);
            }
            this.ReMakeMap();
        }

        public T GetByKey(string key)
        {
            if (this.Flags.HasFlag(DBFlags.UseMap))
            {
                this.map.TryGetValue(key, out var ret);
                return ret;
            }
            else
            {
                return this.Items.FirstOrDefault(it => it.GetKey() == key);
            }
        }

        public void ReMakeMap()
        {
            if (Flags.HasFlag(DBFlags.UseMap))
            {
                foreach (var item in this.Items)
                {
                    this.map.Add(item.GetKey(), item);
                }
            }
        }
    }
}
