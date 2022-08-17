using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Platform;
using SuperNode.ViewModel;

namespace SuperNode.StarGraph
{
    public class TreeNodeView<T> : Border where T : INodeValue
    {
        public NodeBounds bounds
        {
            get;
            private set;
        }

        public TreeNode<T> node
        {
            get;
            set;
        }

        public ConnectionLine line
        {
            get;
            set;
        }

        public virtual void SetText()
        {

        }

        public TreeNodeView()
        {
            this.bounds = new NodeBounds(new PointF(200, 200), new SizeF(100, 35));
            this.line = new ConnectionLine();
        }

        public override string ToString()
        {
            return this.bounds.ToString();
        }
    }
}
