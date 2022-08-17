using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.Drawables
{
    internal class NodeDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            SolidPaint solidPaint = new SolidPaint(Colors.Silver);
            //RectF solidRectangle = new RectF(100, 100, 200, 100);
            canvas.SetFillPaint(solidPaint, dirtyRect);
            canvas.SetShadow(new SizeF(20, 20), 20, Colors.Grey);
            //canvas.FillRoundedRectangle(solidRectangle, 12);
            canvas.FillRoundedRectangle(dirtyRect, 6);
        }
    }
}
