using SuperNode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.StarGraph
{
    public interface IEntryListener
    {
        void OnTab(MyNodeView view);
        void OnDelete(MyNodeView view);
        void OnEnter(MyNodeView view);
        void OnEditorUnfocus(MyNodeView view);
        void OnComplete(MyNodeView view);
        void OnDrop(MyNodeView from, MyNodeView to);
    }

    public class MyNodeView : TreeNodeView<DBNode>
    {
        public string Text
        {
            get
            {
                return this.entry.Text;
            }
        }

        private MyEntry entry;
        public MyNodeView()
        {
            this.MakeBase();
            this.MakeEntry();
            this.BuildGuestures();
            this.Content = this.entry;
            this.SetEditable(false);
        }

        public void SetListener(IEntryListener listener)
        {
            this.entry.listener = listener;
        }

        public void SetEditable(bool editable)
        {
            if (editable)
            {
                this.entry.IsEnabled = true;
                this.entry.Focus();
            }
            else
            {
                this.entry.IsEnabled = false;
            }
        }

        private void BuildGuestures()
        {
            {
                var guesture = new DragGestureRecognizer();
                guesture.DragStarting += Guesture_DragStarting;
                //guesture.DropCompleted += Guesture_DropCompleted;
                this.GestureRecognizers.Add(guesture);
            }
            {
                var guesture = new DropGestureRecognizer();
                guesture.Drop += DropGesture_Drop;
                this.GestureRecognizers.Add(guesture);
            }
            {
                var guesture = new TapGestureRecognizer();
                guesture.Tapped += Guesture_Tapped;
                this.GestureRecognizers.Add(guesture);
            }
        }


        private void MakeBase()
        {
            Background = AppColors.Dark_FrameBorder;
            HorizontalOptions = LayoutOptions.Fill;
            Shadow = new Shadow()
            {
                Brush = Brush.Black,
                Offset = new Point(5, 5),
                Radius = 5,
                Opacity = 0.8f
            };
        }

        private void MakeEntry()
        {
            var entry = new MyEntry
            {
                Text = node?.value?.content,
                FontSize = 14,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Colors.Black,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                //AutoSize= EditorAutoSizeOption.TextChanges,
            };
            entry.Unfocused += Editor_UnFocused;
            this.entry = entry;
            this.entry.view = this;
        }

        private void Editor_UnFocused(object sender, FocusEventArgs e)
        {
            this.entry.IsEnabled = false;
            this.entry.listener?.OnEditorUnfocus(this);
        }

        private void Guesture_Tapped(object sender, EventArgs e)
        {
            this.entry.IsEnabled = true;
            this.entry.Focus();
        }

        //private void Guesture_DropCompleted(object sender, DropCompletedEventArgs e)
        //{
        //    var view = ((GestureRecognizer)sender).Parent as MyNodeView;
        //    if (view != null)
        //    {

        //    }
        //}

        private void Guesture_DragStarting(object sender, DragStartingEventArgs e)
        {
            e.Data.Properties.Add("node", this);
        }

        private void DropGesture_Drop(object sender, DropEventArgs e)
        {
            e.Data.Properties.TryGetValue("node", out var senderNode);
            if (senderNode != null)
            {
                this.entry.listener.OnDrop(senderNode as MyNodeView, this);
            }
        }
        public override void SetText()
        {
            this.entry.Text = this.node.value.content;
        }
    }
}
