using System.Drawing;

namespace MultiThreadingAStar
{
    enum ResultBoxType { Opened,Closed };
    class ResultBox
    {
        public int x, y, width, height;
        public SolidBrush brush;
        public Rectangle boxRec;
        public ResultBoxType boxType;
        public ResultBox(int iX, int iY, ResultBoxType iType)
        {
            this.x = iX;
            this.y = iY;
            this.boxType = iType;
            switch (iType)
            {
                case ResultBoxType.Opened:
                    brush = new SolidBrush(Color.AliceBlue);
                    break;
                case ResultBoxType.Closed:
                    brush = new SolidBrush(Color.LightGreen);
                    break;
              
            
            }
            width = 18;
            height = 18;
            boxRec = new Rectangle(x, y, width, height);
        }

        public void drawBox(Graphics iPaper)
        {
            boxRec.X = x;
            boxRec.Y = y;
            iPaper.FillRectangle(brush, boxRec);
         
        }


        public void Dispose()
        {
            if(this.brush!=null)
                this.brush.Dispose();

        }
    }
}
