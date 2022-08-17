using SuperNode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.StarGraph
{
    public class MyEntry : Entry
    {
        //public TreeNode<DBNode> node;

        public MyNodeView view;

        public IEntryListener listener
        {
            get;
            set;
        }

        public MyEntry()
        {
            this.Completed += MyEntry_Completed;
        }

        private void MyEntry_Completed(object sender, EventArgs e)
        {
            this.listener?.OnComplete(this.view);
        }


        public bool OnKeyDown(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.Tab:
                    {
                        this.listener?.OnTab(view);
                    }
                    return true;
                case KeyCode.Delete:
                case KeyCode.Decimal:
                    {
                        this.listener?.OnDelete(view);
                    }
                    return true;
                case KeyCode.Enter:
                    {
                        this.listener?.OnEnter(view);
                    }
                    return true;
                default:
                    return false;
            }
        }
    }
}
