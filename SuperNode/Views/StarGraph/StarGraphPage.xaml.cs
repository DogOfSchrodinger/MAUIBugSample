using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.Shapes;
using SuperNode.StarGraph;
using SuperNode.ViewModel;
#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
#endif
namespace SuperNode;

public partial class StarGraphPage : ContentPage
{
    private NodeContainerView containerView;
    public StarGraphPage()
    {
        InitializeComponent();
        BindingContext = DBNodeSet.ins;
        this.containerView = new NodeContainerView(this.node_container);
        this.node_container.SizeChanged += Node_container_SizeChanged;
    }

    protected override void OnAppearing()
    {
        if (this.node_container.Bounds.Height > 0)
        {
            SetSelectNode();
        }
    }

    private void Node_container_SizeChanged(object sender, EventArgs e)
    {
        if (this.containerView.tree == null)
        {
            SetSelectNode();
        }
    }

    private void BuildSelectTree(Tree<DBNode> tree)
    {
        foreach (var it in DBNodeSet.ins.Items)
        {
            if (!string.IsNullOrEmpty(it.parent))
            {
                var parent = tree.GetNode(it.parent);
                if (parent != null)
                    parent.AddChild(it);
            }
        }
        tree.canvas.clientHeight = (float)this.node_container.Bounds.Height;
        this.containerView.SetTree(tree);
    }

    private void SetSelectNode()
    {
        if (DBNodeSet.ins.RootItems.Count > 0)
        {
            this.containerView.Clear();
            var tree = new Tree<DBNode>(this.containerView);
            tree.SetValue(DBNodeSet.ins.RootItems.First());
            this.BuildSelectTree(tree);
        }
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        this.containerView.Clear();
        var rd = e.SelectedItem as DBNode;
        var tree = new Tree<DBNode>(this.containerView);
        tree.SetValue(rd);
        this.BuildSelectTree(tree);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var title = await this.DisplayPromptAsync("添加主题", "");
        if (!string.IsNullOrEmpty(title))
        {
            DBNodeSet.ins.AddRoot(title);
        }
    }

    private void ToolbarItem_Clicked_SameLv(object sender, EventArgs e)
    {
    }

    private void ToolbarItem_Clicked_NextLv(object sender, EventArgs e)
    {

    }


    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {

    }

    private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                this.containerView.tree?.canvas?.controller?.BeginTranslate();
                break;
            case GestureStatus.Running:
                this.containerView.tree?.canvas?.controller?.OnTranslate(e.TotalX, e.TotalY);
                this.containerView.Reposition();
                break;

            case GestureStatus.Completed:
                this.containerView.tree?.canvas?.controller?.EndTranslate();
                break;
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {

    }

}



