//using Android.Hardware.Lights;
using SuperNode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.StarGraph
{
    public interface ITreeNodeInterface<T> where T : INodeValue
    {
        TreeNodeView<T> Provide(TreeNode<T> node);
        void OnAddNode(TreeNode<T> node);
        void OnDeleteNode(TreeNode<T> node);
    }

    public class NodeCanvas<T> where T : INodeValue
    {
        public float x = 100;
        public float columnWidth = 160;
        public float lineHeight = 40;
        public float lineGap = 5;
        private List<float> columnWidths;
        private Tree<T> tree;
        public TranslateController controller
        {
            get;
            private set;
        }


        public float clientHeight
        {
            get; set;
        }
        public NodeCanvas(Tree<T> tree)
        {
            this.tree = tree;
            this.columnWidths = new List<float>();
            this.controller = new TranslateController();
        }

        public void RefreshLayout()
        {
            float height = 0;
            this.AdjustLayout(this.tree, ref height);
            this.BuildConnections(this.tree);
            height -= this.lineGap;
            this.controller.startY = (this.clientHeight - height) * 0.5f;
        }

        private void BuildConnections(TreeNode<T> node)
        {
            var line = node.view.line;
            if (node.isLeaf)
            {
                if (line.HasChildren())
                {
                    line.Clear();
                }
                return;
            }
            //if(line.connections==node.children.Count)
            //{
            //    return;
            //}
            var v = 31;
            var first = node.children.First().view.bounds;
            var end = node.children.Last().view.bounds;
            line.SetV(v);
            line.SetH(first.center.Y, end.center.Y);
            line.ClearChildConnections();
            foreach (var it in node.children)
            {
                line.AddChildConnection(it.view.bounds.centerY);
            }
            line.BuildPaths();
            foreach (var it in node.children)
            {
                this.BuildConnections(it);
            }
        }

        public void AdjustLayout(TreeNode<T> node, ref float y)
        {
            var px = this.x + node.depth * this.columnWidth;
            node.view.bounds.centerX = px;
            foreach (var it in node.children)
            {
                this.AdjustLayout(it, ref y);
            }
            if (node.isLeaf)
            {
                node.view.bounds.centerY = y;
                y += this.lineHeight + this.lineGap;
            }
            else
            {
                var first = node.children.First();
                var end = node.children.Last();
                node.view.bounds.centerY = (first.view.bounds.center.Y + end.view.bounds.center.Y) * 0.5f;
            }
        }
    }
}
