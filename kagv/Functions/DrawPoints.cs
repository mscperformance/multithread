/*!
The Apache License 2.0 License

Copyright (c) 2017 Dimitris Katikaridis <dkatikaridis@gmail.com>,Giannis Menekses <johnmenex@hotmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using kagv.DLL_source;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace kagv {

    public partial class MainForm {
        
        private void DrawPoints(GridLine x, int agvIndex) {
          
            var x1 = x.FromX;
            var y1 = x.FromY;
            var x2 = x.ToX;
            var y2 = x.ToY;
            double distance = _f.GetLength(x1, y1, x2, y2); //function that returns the Euclidean distance between 2 points

            double side = _f.getSide(_rectangles[0][0].Height
                            , _rectangles[0][0].Height); //function that returns the hypotenuse of a GridBox

            int distanceBlocks = -1; //the quantity of blocks,matching the current line's length

            //Calculates the number of GridBoxes that the Line consists of. Calculation depends on 2 scenarios:
            //Scenario 1: Line is Diagonal
            //Scenario 2: Line is Straight
            if ((x1 < x2) && (y1 < y2)) //diagonal-right bottom direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((x1 < x2) && (y1 > y2)) //diagonal-right top direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((x1 > x2) && (y1 < y2)) //diagonal-left bottom direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((x1 > x2) && (y1 > y2)) //diagonal-left top direction
                distanceBlocks = Convert.ToInt32(distance / side);
            else if ((y1 == y2) || (x1 == x2)) //horizontal or vertical
                distanceBlocks = Convert.ToInt32(distance / _rectangles[0][0].Width);
            else
                MessageBox.Show(this, "Unexpected error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //1d array of points.used to track all the points of current line
            Point[] currentLinePoints = new Point[distanceBlocks];

            //here we calculate the X,Y coordinates of all the intermediate points
            for (var i = 0; i < distanceBlocks; i++) {
                _calibrated = false;
                double t;
                if (distance != 0) //obviously, distance cannot be zero
                    t = ((side) / distance);
                else
                    return;

                //these are the x,y coord that are calculated in every for-loop
                _a = Convert.ToInt32(((1 - t) * x1) + (t * x2));
                _b = Convert.ToInt32(((1 - t) * y1) + (t * y2));
                Point p = new Point(_a, _b); //merges the calculated x,y into 1 Point variable

                for (var k = 0; k < Globals.WidthBlocks; k++)
                    for (var l = 0; l < Globals.HeightBlocks; l++)
                        if (_rectangles[k][l].BoxRec.Contains(p)) { //this is how we assign the previously calculated pair of X,Y to a GridBox

                            //a smart way to handle GridBoxes from their center
                            int sideX = _rectangles[k][l].BoxRec.X + ((Globals.BlockSide / 2) - 1);
                            int sideY = _rectangles[k][l].BoxRec.Y + ((Globals.BlockSide / 2) - 1);
                            currentLinePoints[i].X = sideX;
                            currentLinePoints[i].Y = sideY;

                            if (dotsToolStripMenuItem.Checked) {
                                if (agvIndex == 0)
                                {
                                    using (SolidBrush br = new SolidBrush(Color.BlueViolet))
                                        _paper.FillEllipse(br, currentLinePoints[i].X - 3,
                                            currentLinePoints[i].Y - 3,
                                            5, 5);
                                } else
                                {
                                    using (SolidBrush br = new SolidBrush(Color.DarkOrange))
                                        _paper.FillEllipse(br, currentLinePoints[i].X - 3,
                                            currentLinePoints[i].Y - 3,
                                            5, 5);
                                }
                            }

                            using (Font stepFont = new Font("Tahoma", 8, FontStyle.Bold))//Font used for numbering the steps/current block)
                            {
                                using (SolidBrush fontBr = new SolidBrush(Color.FromArgb(53, 153, 153)))
                                    if (stepsToolStripMenuItem.Checked)
                                        _paper.DrawString(_AGVs[agvIndex].StepsCounter + ""
                                        , stepFont
                                        , fontBr
                                        , currentLinePoints[i]);

                            }
                            _calibrated = true;

                        }

                if (_calibrated) { //for each one of the above calculations, we check if the calibration has been done correctly and, if so, each pair is inserted to the corresponding AGV's steps List 
                    _AGVs[agvIndex].Steps[_AGVs[agvIndex].StepsCounter].X = currentLinePoints[i].X;
                    _AGVs[agvIndex].Steps[_AGVs[agvIndex].StepsCounter].Y = currentLinePoints[i].Y;
                    _AGVs[agvIndex].StepsCounter++;
                }
                //initialize next steps.
                x1 = currentLinePoints[i].X;
                y1 = currentLinePoints[i].Y;
                distance = _f.GetLength(x1, y1, x2, y2);

            }


        }
    }
}
