using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.StarGraph
{
    public class NodeBounds
    {
        public PointF center
        {
            get { return new Point(this.centerX, this.centerY); }
        }

        public PointF size
        {
            get { return new Point(this.width, this.height); }
        }

        public float centerX;
        public float centerY;
        public float width;
        public float height;

        public NodeBounds()
        {

        }

        public NodeBounds(PointF center, SizeF size)
        {
            this.centerX = center.X;
            this.centerY = center.Y;
            this.width = size.Width;
            this.height = size.Height;
        }

        public float xMin
        {
            get { return center.X - size.X * 0.5f; }
        }

        public float xMax
        {
            get { return center.X + size.X * 0.5f; }
        }

        public float yMin
        {
            get { return center.Y - size.Y * 0.5f; }
        }

        public float yMax
        {
            get { return center.Y + size.Y * 0.5f; }
        }

        public RectF ToRect()
        {
            return new RectF(xMin, yMax, size.X, size.Y);
        }

        public RectF Translate(float offsetx, float offsety)
        {
            centerX += offsetx;
            centerY += offsety;
            return ToRect();
        }
    }
}
