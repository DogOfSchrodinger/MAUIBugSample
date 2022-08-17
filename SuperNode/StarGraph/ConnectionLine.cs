using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.StarGraph
{
    public class ConnectionLine
    {
        public Microsoft.Maui.Controls.Shapes.Path path
        {
            get;
            private set;
        }
        public Rect bounds
        {
            get;
            private set;
        }
        private LineSegment seg1;
        private LineSegment seg2;
        private PathFigure figure1;
        private PathFigure figure2;
        private PathFigureCollection figures;
        private List<PathFigure> children;
        private float v;
        private double ymin;

        public int connections
        {
            get
            {
                return this.children.Count;
            }
        }

        public ConnectionLine()
        {
            this.children = new List<PathFigure>();
            this.path = new Microsoft.Maui.Controls.Shapes.Path();

            this.seg1 = new LineSegment();
            this.figure1 = new PathFigure();
            this.figure1.IsClosed = false;
            this.figure1.Segments.Add(this.seg1);

            this.seg2 = new LineSegment();
            this.figure2 = new PathFigure();
            this.figure2.IsClosed = false;
            this.figure2.Segments.Add(this.seg2);

            this.figures = new PathFigureCollection();
            this.path.IsEnabled = false;
            this.path.Stroke = new SolidColorBrush(new Color(8, 111, 133));
            this.path.StrokeThickness = 2;
            this.path.Data = new PathGeometry(this.figures);
        }



        public void ClearChildConnections()
        {
            this.children.Clear();
        }

        public void SetV(float v)
        {
            this.v = v;
        }

        public void SetH(double ymin, double ymax)
        {
            var h = ymax - ymin;
            var centerY = h * 0.5f;
            this.bounds = new Rect(0, 0, v * 2, h + 1);
            this.ymin = ymin;
            this.figure1.StartPoint = new Point(0, centerY);
            this.seg1.Point = new Point(v, centerY);
            this.figure2.StartPoint = new Point(v, 0);
            this.seg2.Point = new Point(v, h);
        }

        public void Clear()
        {
            this.children.Clear();
            this.figures.Clear();
            this.path.Data = new PathGeometry(this.figures);
        }

        public bool HasChildren()
        {
            return this.children.Count > 0;
        }

        public void AddChildConnection(double y)
        {
            this.children.Add(new PathFigure()
            {
                StartPoint = new Point(this.v, y - this.ymin),
                IsClosed = false,
                Segments = new PathSegmentCollection()
            {
                new LineSegment(new Point(this.v*2,y-this.ymin))
            }
            }); ;
        }


        public void BuildPaths()
        {
            this.figures.Clear();
            this.figures.Add(this.figure1);
            this.figures.Add(this.figure2);
            foreach (var it in this.children)
                this.figures.Add(it);
            this.path.Data = new PathGeometry(this.figures);
        }
    }
}
