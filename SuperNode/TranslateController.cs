using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode
{
    public class TranslateController
    {
        public float offsetX;
        public float offsetY
        {
            get;
            set;
        }
        public float startY
        {
            get;
            set;
        }

        private float wantTranslateX;
        private float wantTranslateY;

        public void BeginTranslate()
        {
            wantTranslateX = 0;
            wantTranslateY = 0;
        }

        public void OnTranslate(double totalX, double totalY)
        {
            offsetX += (float)totalX - wantTranslateX;
            offsetY += (float)totalY - wantTranslateY;
            wantTranslateX = (float)totalX;
            wantTranslateY = (float)totalY;
        }

        public void EndTranslate()
        {
            wantTranslateX = 0;
            wantTranslateY = 0;
        }

        public void Reset()
        {
            this.offsetX = 100;
            this.offsetY = 0;
        }
    }
}
