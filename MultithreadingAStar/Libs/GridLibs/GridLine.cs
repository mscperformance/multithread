using System.Drawing;

namespace MultiThreadingAStar
{
    class GridLine
    {
        public int fromX, fromY, toX, toY;
        public Pen pen;
        
        public GridLine(GridBox iFrom, GridBox iTo)
        {
            this.fromX = iFrom.boxRec.X + 4;
            this.fromY = iFrom.boxRec.Y + 4;
            this.toX = iTo.boxRec.X + 4;
            this.toY = iTo.boxRec.Y + 4;
            pen = new Pen(Color.Yellow);
            pen.Width = 2;
            
            
        }

        public void drawLine(Graphics iPaper)
        {
            iPaper.DrawLine(pen, fromX, fromY, toX, toY);
            
        }


        public void Dispose()
        {
            if (this.pen != null)
                this.pen.Dispose();

        }
    }
}
