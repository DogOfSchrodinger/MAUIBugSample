using Microsoft.Maui.Graphics;
using SuperNode.StarGraph;
using SuperNode.ViewModel;
using System;

namespace SuperNode.Drawables
{
    public class NodeGraphCanvas : IDrawable
    {
        internal TreeNode<DBNode> root
        {
            get;
            set;
        }

        private Paint canvasPaint;

        public TranslateController controller
        {
            get;
            set;
        }

        public NodeGraphCanvas()
        {
            this.controller = new TranslateController();
        }

        private Paint RecreateCanvasPaint()
        {
            using (PictureCanvas picture = new PictureCanvas(0, 0, 10, 10))
            {
                picture.StrokeColor = Colors.Silver;
                picture.DrawLine(0, 0, 10, 0);
                picture.DrawLine(0, 0, 0, 10);
                var pattern = new PicturePattern(picture.Picture, 10, 10);
                canvasPaint = new PatternPaint
                {
                    Pattern = pattern
                };
                return canvasPaint;
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var canvasPaint = this.RecreateCanvasPaint();
            var nodePaint = new SolidPaint(Colors.Silver);
            canvas.ResetState();
            canvas.SetFillPaint(canvasPaint, RectF.Zero);
            canvas.FillRectangle(dirtyRect);
            canvas.FontSize = 14;
            canvas.FontColor = Colors.Blue;

            if (this.root != null)
            {
                this.DrawTreeNode(canvas, nodePaint, this.root);
            }
        }

        private void DrawTreeNode(ICanvas canvas, Paint nodePaint, TreeNode<DBNode> node)
        {
            var rc = node.view.bounds.ToRect();
            rc.X += this.controller.offsetX;
            rc.Y += this.controller.offsetY;
            DrawNode(canvas, nodePaint, node, rc);
        }

        internal void DrawNode(ICanvas canvas, Paint nodePaint, TreeNode<DBNode> node, RectF dirtyRect)
        {
            canvas.SetFillPaint(nodePaint, dirtyRect);
            canvas.SetShadow(new SizeF(4, 4), 4, Colors.Grey);
            canvas.FillRoundedRectangle(dirtyRect, 3);
            canvas.ResetState();
            canvas.DrawString(node.value.content, dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height, HorizontalAlignment.Center, VerticalAlignment.Center);
        }
    }
}