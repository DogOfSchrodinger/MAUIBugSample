using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using SuperNode.ViewModel;
using System.Collections.ObjectModel;

namespace SuperNode.StarGraph
{
    public class NodeContainerView : ITreeNodeInterface<DBNode>, IEntryListener
    {
        public Tree<DBNode> tree
        {
            get;
            private set;
        }
        private AbsoluteLayout canvas;
        private List<View> controls;

        public NodeContainerView(AbsoluteLayout canvas)
        {
            this.canvas = canvas;
            this.controls = new List<View>();
        }

        public void Clear()
        {
            foreach (var it in this.controls)
            {
                this.canvas.Remove(it);
            }
            this.controls.Clear();
        }

        public void SetTree(Tree<DBNode> tree)
        {
            this.tree = tree;
            GC.Collect();
            if (this.tree != null)
            {
                RefreshLayout();
            }
        }

        private void RecreateNodes()
        {
            foreach (var it in controls)
            {
                canvas.Remove(it);
            }
            controls.Clear();
        }

        private void SetPosition(TreeNode<DBNode> node)
        {
            this.canvas.SetLayoutBounds(node.view, node.GetRect());
            if (node.isLeaf == false)
            {
                this.canvas.SetLayoutBounds(node.view.line.path, node.GetConnectionRect());
                foreach (var it in node.children)
                {
                    SetPosition(it);
                }
            }
        }

        public void AddControlsToGraph(TreeNode<DBNode> node)
        {
            this.canvas.Add(node.view);
            this.canvas.Add(node.view.line.path);
            this.controls.Add(node.view);
            this.controls.Add(node.view.line.path);
        }

        public void RemoveControlFromGraph(TreeNode<DBNode> node)
        {
            this.canvas.Remove(node.view);
            this.canvas.Remove(node.view.line.path);
            this.controls.Remove(node.view);
            this.controls.Remove(node.view.line.path);
        }

        public void RefreshLayout()
        {
            if (this.tree != null)
            {
                this.tree.canvas.RefreshLayout();
                this.SetPosition(tree);
            }
        }

        public void Reposition()
        {
            this.SetPosition(tree);
        }

        public TreeNodeView<DBNode> Provide(TreeNode<DBNode> node)
        {
            var ret = new MyNodeView();
            ret.node = node;
            ret.SetListener(this);
            return ret;
        }




        public void OnAddNode(TreeNode<DBNode> node)
        {
            this.AddControlsToGraph(node);
            if (node.value != null && !DBNodeSet.ins.map.ContainsKey(node.value.GetKey()))
            {
                DBNodeSet.ins.Items.Add(node.value);
                DBNodeSet.ins.Insert(node.value);
            }
        }

        public void OnDeleteNode(TreeNode<DBNode> node)
        {
            this.RemoveControlFromGraph(node);
            DBNodeSet.ins.Items.Remove(node.value);
            DBNodeSet.ins.Delete(node.value);
        }

        void IEntryListener.OnTab(MyNodeView view)
        {
            var child = view.node.AddChild(DBNode.FromContent(""));
            var childView = child.view as MyNodeView;
            childView.SetEditable(true);
            this.RefreshLayout();
        }

        void IEntryListener.OnDelete(MyNodeView view)
        {
            view.node.parent?.DeleteChildren(view.node);
            this.RefreshLayout();
        }

        void IEntryListener.OnEnter(MyNodeView view)
        {
            var child = view.node.parent?.AddChild(DBNode.FromContent(""));
            if (child != null)
            {
                var childView = child.view as MyNodeView;
                childView.SetEditable(true);
                this.RefreshLayout();
            }
        }

        void IEntryListener.OnEditorUnfocus(MyNodeView view)
        {
            view.node.value.content = view.Text;
            view.node.value.OnPropertyChanged(nameof(view.node.value.content));
            DBNodeSet.ins.UpdateDB(view.node.value);
        }

        void IEntryListener.OnComplete(MyNodeView view)
        {
            view.node.value.content = view.Text;
            view.node.value.OnPropertyChanged(nameof(view.node.value.content));
            DBNodeSet.ins.UpdateDB(view.node.value);
        }

        void IEntryListener.OnDrop(MyNodeView from, MyNodeView to)
        {
            if (to.node.children.Contains(from.node))
            {
                return;
            }
            if (from.node.HasChild(to.node))
            {
                return;
            }
            to.node.AddChildren(from.node);
            this.RefreshLayout();
        }
    }


}