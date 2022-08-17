using Microsoft.Maui.Layouts;
using SuperNode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.StarGraph
{
    public class Tree<T> : TreeNode<T> where T : INodeValue
    {
        public int maxDepth
        {
            get;
            set;
        }
        public NodeCanvas<T> canvas
        {
            get;
            private set;
        }

        public ITreeNodeInterface<T> nodeInterface
        {
            get;
            set;
        }

        private Dictionary<string, TreeNode<T>> map;

        public Tree(ITreeNodeInterface<T> nodeInterface)
            : base(nodeInterface)
        {
            this.map = new Dictionary<string, TreeNode<T>>();
            this.tree = this;
            this.nodeInterface = nodeInterface;
            this.canvas = new NodeCanvas<T>(this);
            nodeInterface?.OnAddNode(this);
        }

        internal void AddChildToMap(TreeNode<T> node)
        {
            if (node.value != null)
            {
                this.map.Add(node.value.GetKey(), node);
            }
        }

        internal void RemoveChildFromMap(TreeNode<T> node)
        {
            if (node.value != null)
            {
                this.map.Remove(node.value.GetKey());
            }
        }

        public TreeNode<T> GetNode(string id)
        {
            return map.GetValueOrDefault(id);
        }

        public bool HasNode(string id)
        {
            return GetNode(id) != null;
        }

        public TreeNode<T> AddRoot(T value)
        {
            return AddChild(value);
        }

        public TreeNode<T> RequireNode(T value)
        {
            if (!map.ContainsKey(value.GetKey()))
            {
                var ret = new TreeNode<T>(this.nodeInterface, this);
                ret.SetValue(value);
                return ret;
            }
            return null;
        }
    }
}
