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
    public enum StorageType
    {
        None,
        ToDoItems,
    }

    public interface IKey
    {
        public string GetKey();
        public void SetKey(string key);
    }

    public interface INodeValue : IKey
    {
        public void SetParent(string key);
    }

    [Serializable]
    public class JsonArr<T>
    {
        public List<T> arr = new List<T>();
    }

    internal class Storage
    {
        public static readonly Storage ins = new Storage();
        private static string DataDir
        {
            get
            {
                var dir = string.Empty;
#if WINDOWS
dir= FileSystem.Current.AppDataDirectory;
#elif ANDROID
                dir = FileSystem.Current.AppDataDirectory;
#elif IOS
dir= FileSystem.Current.AppDataDirectory;
#elif MACCATALYST
dir= FileSystem.Current.AppDataDirectory;
#endif
                return dir;
            }
        }

        private LiteDB.LiteDatabase db;

        public Storage()
        {
            var connectionStr = DataDir + "/jzzw.db";
            //var connectionStr = Environment.CurrentDirectory + "/jzzw.db";
            this.db = new LiteDB.LiteDatabase(connectionStr);
            var tables = new List<string>(this.db.GetCollectionNames());
        }

        public List<T> LoadArray<T>()
        {
            var query = this.db.GetCollection<T>();
            var arr = query.Query().ToList();
            return arr;
        }

        public void SaveArray<T>(IEnumerable<T> arr)
        {
            var query = this.db.GetCollection<T>();
            query.Upsert(arr);
        }

        public void UpdateDB<T>(T entity)
        {
            var query = this.db.GetCollection<T>();
            query.Update(entity);
        }

        public bool InsertDB<T>(T entity)
        {
            var query = this.db.GetCollection<T>();
            var ret = query.Insert(entity);
            return ret != null;
        }

        public bool DeleteDB<T>(T entity) where T : IKey
        {
            var query = this.db.GetCollection<T>();
            return query.Delete(entity.GetKey());
        }

        public void DeleteTable<T>()
        {
            this.db.DropCollection(typeof(T).Name);
        }
    }
}
