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
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace kagv {

    public partial class MainForm  {

        private void ConfigUi() {

            if (Globals.SemiTransparency)
                Globals.SemiTransparent = Color.FromArgb(Globals.Opacity, Color.WhiteSmoke);

            for (int i = 0; i < _startPos.Count; i++) {
                _AGVs[i] = new Vehicle(this) {
                    ID = i
                };
            }

            Width = (Globals.WidthBlocks + 1) * Globals.BlockSide + Globals.LeftBarOffset - 100;
            Height = (Globals.HeightBlocks + 1) * Globals.BlockSide + Globals.BottomBarOffset + 7 ; //+7 for borders
            Size = new Size(Width, Height + Globals.BottomBarOffset);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            StackTrace trace = new StackTrace();
            if (trace.GetFrame(2).GetMethod().Name.Contains("MenuItem_Click") || Globals.FirstFormLoad)
            {
                stepsToolStripMenuItem.Checked = false;
                linesToolStripMenuItem.Checked =
                dotsToolStripMenuItem.Checked =
                bordersToolStripMenuItem.Checked =
                aGVIndexToolStripMenuItem.Checked =
                highlightOverCurrentBoxToolStripMenuItem.Checked = true;

                Globals.AStarWeight = 0.5;
            }

            rb_start.Checked = true;
            BackColor = Color.DarkGray;

            CenterToScreen();

            alwaysCrossMenu.Checked = _alwaysCross;
            atLeastOneMenu.Checked = _atLeastOneObstacle;
            neverCrossMenu.Checked = _never;
            noObstaclesMenu.Checked = _ifNoObstacles;

            manhattanToolStripMenuItem.Checked = true;
     
            menuPanel.Width = Width;
            settings_menu.Location = new Point(0, 0);
            nud_weight.Value = Convert.ToDecimal(Globals.AStarWeight);

        }
    }
}
