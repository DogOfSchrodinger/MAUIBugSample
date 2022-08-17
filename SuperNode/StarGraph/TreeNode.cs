using Microsoft.Maui.Layouts;
//using Org.W3c.Dom;
using SuperNode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.StarGraph
{
    public class TreeNode<T> where T : INodeValue
    {
        public T value
        {
            get;
            private set;
        }

        public Tree<T> tree
        {
            get;
            set;
        }

        public TreeNode<T> parent
        {
            get;
            private set;
        }

        public bool isLeaf
        {
            get { return this.children == null ? true : this.children.Count == 0; }
        }

        public bool isRoot
        {
            get
            {
                return this.parent == null;
            }
        }

        public int depth
        {
            get;
            private set;
        }

        public bool expend
        {
            get;
            set;
        } = true;


        public override string ToString()
        {
            return this.value.ToString();
        }

        public TreeNodeView<T> view
        {
            get;
            set;
        }

        public List<TreeNode<T>> children
        {
            get;
            private set;
        }


        public TreeNode(ITreeNodeInterface<T> provider, Tree<T> tree = null)
        {
            this.children = new List<TreeNode<T>>();
            this.view = provider.Provide(this);
            this.tree = tree;
        }

        public bool HasChild(TreeNode<T> node)
        {
            if (this == node)
                return true;
            foreach (var it in this.children)
            {
                if (it.HasChild(node))
                    return true;
            }
            return false;
        }

        public Tree<T> SetValue(T value)
        {
            this.tree.RemoveChildFromMap(this);
            this.value = value;
            this.view.SetText();
            this.tree.AddChildToMap(this);
            return this.tree;
        }

        public void ApplyValue()
        {
        }

        public Rect GetRect()
        {
            var rc = this.view.bounds.ToRect();
            var controller = this.tree.canvas.controller;
            rc.X += controller.offsetX;
            rc.Y += controller.offsetY + controller.startY;
            return rc;
        }

        public Rect GetConnectionRect()
        {
            var line = this.view.line;
            var firstRc = this.children.First().GetRect();
            var rc = new Rect();
            rc.X = this.GetRect().Right;
            rc.Y = firstRc.Center.Y;
            rc.Width = line.bounds.Width;
            rc.Height = line.bounds.Height;
            return rc;
        }

        public void DeleteChildren(TreeNode<T> child)
        {
            foreach (var it in child.children)
                this.DeleteChildren(it);
            this.tree.nodeInterface?.OnDeleteNode(child);
            this.children.Remove(child);
        }

        private void RemoveChild(TreeNode<T> child)
        {
            if (child.parent == this)
            {
                this.children.Remove(child);
                child.parent = null;
            }
        }

        public void AddChildren(TreeNode<T> node)
        {
            node.parent?.RemoveChild(node);
            node.parent = this;
            node.value.SetParent(this.value.GetKey());
            this.children.Add(node);
            this.tree.CollectDepth();
        }

        public TreeNode<T> AddChild(T value)
        {
            var ret = tree.RequireNode(value);
            if (ret != null)
            {
                if (this.value != null)
                {
                    value.SetParent(this.value.GetKey());
                }
                ret.parent = this;
                this.children.Add(ret);
                this.tree.CollectDepth();
                this.tree.nodeInterface?.OnAddNode(ret);
            }

            return ret;
        }

        public void CollectLeafs(List<TreeNode<T>> leafs)
        {
            if (this.isLeaf)
            {
                leafs.Add(this);
            }
            if (this.children != null)
            {
                foreach (var child in this.children)
                {
                    child.CollectLeafs(leafs);
                }
            }
        }

        public List<TreeNode<T>> CollectLeafs()
        {
            var leafs = new List<TreeNode<T>>();
            this.CollectLeafs(leafs);
            return leafs;
        }

        public void CollectDepth()
        {
            this.depth = this.parent == null ? 0 : this.parent.depth + 1;
            if (this.depth > this.tree.maxDepth)
            {
                this.tree.maxDepth = this.depth;
            }
            if (this.children != null)
            {
                foreach (var child in this.children)
                {
                    child.CollectDepth();
                }
            }
        }
    }
}
