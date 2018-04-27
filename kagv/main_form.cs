/*!
The MIT License (MIT)

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
using System.Collections.Generic;
using System.IO;
using kagv.DLL_source;

namespace kagv {

    public partial class MainForm : Form {


        //custom constructor of this form.
        public MainForm() {
            DoubleBuffered = true;
            InitializeComponent();//Create the form layout
            MeasureScreen();
            Initialization();//initialize our stuff

         
        }

    
        private void main_form_Paint(object sender, PaintEventArgs e) {
            _paper = e.Graphics;
            _paper.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            _paper.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            _paper.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            _paper.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            _paper.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            SetStyle(
            ControlStyles.DoubleBuffer, true);

            try {
                if (_importedLayout != null) {

                    Rectangle r = new Rectangle(new Point(_rectangles[0][0].X, _rectangles[0][0].Y)
                        , new Size((_rectangles[Globals.WidthBlocks - 1][Globals.HeightBlocks - 1].X) - Globals.LeftBarOffset + Globals.BlockSide
                            , (_rectangles[Globals.WidthBlocks - 1][Globals.HeightBlocks - 1].Y) - Globals.TopBarOffset + Globals.BlockSide));
                    _paper.DrawImage(_importedLayout, r);

                }
                //draws the grid
                for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++) {
                    for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++) {
                        //show the relative box color regarding the box type we have chose
                        _rectangles[widthTrav][heightTrav].DrawBox(_paper, BoxType.Normal);
                        _rectangles[widthTrav][heightTrav].DrawBox(_paper, BoxType.Start);
                        _rectangles[widthTrav][heightTrav].DrawBox(_paper, BoxType.End);
                        _rectangles[widthTrav][heightTrav].DrawBox(_paper, BoxType.Wall);
                        _rectangles[widthTrav][heightTrav].DrawBox(_paper, BoxType.Load);
                    }
                }

                for (short i = 0; i < _startPos.Count; i++) {
                    _AGVs[i].StepsCounter = 0;
                    
                    for (var resultTrav = 0; resultTrav < _AGVs[i].JumpPoints.Count; resultTrav++)
                        try {
                            if (linesToolStripMenuItem.Checked)
                            {
                                
                                _AGVs[i].Paths[resultTrav].DrawLine(_paper, _AGVs[i].LineColor);//draw the lines 
                            }
                            if (!_isMouseDown)
                                DrawPoints(_AGVs[i].Paths[resultTrav], i);//show points
                        } catch { }
                }

                //handle the red message above every agv
                var AGVsListIndex = 0;
                if (aGVIndexToolStripMenuItem.Checked)
                    for (short i = 0; i < nUD_AGVs.Value; i++)
                        if (!_trappedStatus[i]) {
                            _paper.DrawString("Object:" + _AGVs[AGVsListIndex].ID,
                                             new Font("Tahoma", 8, FontStyle.Bold),
                                             new SolidBrush(Color.Red),
                                             new Point((_startPos[AGVsListIndex].X * Globals.BlockSide) - 10 + Globals.LeftBarOffset, ((_startPos[AGVsListIndex].Y * Globals.BlockSide) + Globals.TopBarOffset) - Globals.BlockSide));
                            AGVsListIndex++;
                        }

            } catch { }
        }
     
        private void main_form_Load(object sender, EventArgs e) {
            //Automatically enable the CPUs for this app.
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            int coreFlag;
            if (Environment.ProcessorCount == 1) coreFlag = 0x0001;
            else if (Environment.ProcessorCount == 2) coreFlag = 0x0003;
            else if (Environment.ProcessorCount == 3) coreFlag = 0x0007;
            else coreFlag = 0x000F; //use only 4 cores.We dont care for pcs with more than 4 cores.

            proc.ProcessorAffinity = new IntPtr(coreFlag);
            //More infos here:https://msdn.microsoft.com/en-us/library/system.diagnostics.processthread.processoraffinity(v=vs.110).aspx
        }

        private void main_form_MouseDown(object sender, MouseEventArgs e) {
           
            //Supposing that timers are not enabled(that means that the simulation is not running)
            //we have a clicked point.Check if that point is valid.if not explicitly leave
            if (!Isvalid(new Point(e.X, e.Y)))
                return;
            //if the clicked point is inside a rectangle...
            _isMouseDown = true;
            if ((e.Button == MouseButtons.Left) && (rb_wall.Checked))
                for (int widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                    for (int heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++)
                        if (_rectangles[widthTrav][heightTrav].BoxRec.IntersectsWith(new Rectangle(e.Location, new Size(1, 1)))) {
                            _lastBoxType = _rectangles[widthTrav][heightTrav].BoxType;
                            _lastBoxSelect = _rectangles[widthTrav][heightTrav];
                            switch (_lastBoxType) { //...measure the reaction
                                case BoxType.Normal: //if its wall or normal ,switch it to the opposite.
                                case BoxType.Wall:
                                    _rectangles[widthTrav][heightTrav].SwitchBox();
                                    Invalidate();
                                    break;
                                case BoxType.Start: //if its start or end,do nothing.
                                case BoxType.End:
                                    break;
                            }
                        }
           
        }

        private void main_form_MouseMove(object sender, MouseEventArgs e) {
            //this event is triggered when the mouse is moving above the form

            //if we hold the left click and the Walls setting is selected....
            if (_isMouseDown && rb_wall.Checked) {
                if (e.Button == MouseButtons.Left) {
                    if (_lastBoxSelect.BoxType == BoxType.Start ||
                        _lastBoxSelect.BoxType == BoxType.End)
                        return;

                    //that IF() means: if my click is over an already drawn box...
                    if (_lastBoxSelect == null) {
                        for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++) {
                            for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++) {
                                if (_rectangles[widthTrav][heightTrav].BoxRec.IntersectsWith(new Rectangle(e.Location, new Size(1, 1)))) {
                                    _lastBoxType = _rectangles[widthTrav][heightTrav].BoxType;
                                    _lastBoxSelect = _rectangles[widthTrav][heightTrav];
                                    switch (_lastBoxType) {
                                        case BoxType.Normal:
                                        case BoxType.Wall:
                                            _rectangles[widthTrav][heightTrav].SwitchBox(); //switch it if needed...
                                            Invalidate();
                                            break;
                                        case BoxType.Start:
                                        case BoxType.End:
                                            break;
                                    }
                                }

                            }
                        }

                        return;
                        //else...its a new/fresh box
                    }
                    for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++) {
                        for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++) {
                            if (_rectangles[widthTrav][heightTrav].BoxRec.IntersectsWith(new Rectangle(e.Location, new Size(1, 1)))) {
                                if (_rectangles[widthTrav][heightTrav] == _lastBoxSelect) {
                                    return;
                                }
                                switch (_lastBoxType) {
                                    case BoxType.Normal:
                                    case BoxType.Wall:
                                        if (_rectangles[widthTrav][heightTrav].BoxType == _lastBoxType) {
                                            _rectangles[widthTrav][heightTrav].SwitchBox();
                                            _lastBoxSelect = _rectangles[widthTrav][heightTrav];
                                            Redraw();
                                            Invalidate();
                                        }
                                        break;
                                    case BoxType.Start:
                                        _lastBoxSelect.SetNormalBox();
                                        _lastBoxSelect = _rectangles[widthTrav][heightTrav];
                                        Invalidate();
                                        break;
                                    case BoxType.End:
                                        _lastBoxSelect.SetNormalBox();
                                        _lastBoxSelect = _rectangles[widthTrav][heightTrav];
                                        _lastBoxSelect.SetEndBox();
                                        Invalidate();
                                        break;
                                }
                                return;
                            }
                        }
                    }
                }
            }

          

          
        }

        //The most important event.When we let our mouse click up,all our changes are
        //shown in the screen
        private void main_form_MouseUp(object sender, MouseEventArgs e) {

            Point clickCoords = new Point(e.X, e.Y);
            if (!Isvalid(clickCoords) || nUD_AGVs.Value == 0)
                return;

            _isMouseDown = false;

            if (rb_start.Checked) {

                if (nUD_AGVs.Value == 1)//Saves only the last Click position to place the Start (1 start exists)
                {
                    for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                        for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++)
                            if (_rectangles[widthTrav][heightTrav].BoxType == BoxType.Start)
                                _rectangles[widthTrav][heightTrav].SwitchEnd_StartToNormal();
                } else if (nUD_AGVs.Value > 1) {//Deletes the start with the smallest iX - iY coords and keeps the rest

                    int startsCounter = 0;
                    int[,] startsPosition = new int[2, Convert.ToInt32(nUD_AGVs.Value)];


                    for (int widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                        for (int heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++) {
                            if (_rectangles[widthTrav][heightTrav].BoxType == BoxType.Start) {
                                startsPosition[0, startsCounter] = widthTrav;
                                startsPosition[1, startsCounter] = heightTrav;
                                startsCounter++;
                            }
                            if (startsCounter == nUD_AGVs.Value) {
                                _rectangles[startsPosition[0, 0]][startsPosition[1, 0]].SwitchEnd_StartToNormal();
                            }
                        }
                }

              
                //Converts the clicked box to Start point
                for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                    for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++)
                        if (_rectangles[widthTrav][heightTrav].BoxRec.Contains(clickCoords)
                         && _rectangles[widthTrav][heightTrav].BoxType == BoxType.Normal)
                            _rectangles[widthTrav][heightTrav] = new GridBox((widthTrav * Globals.BlockSide) + Globals.LeftBarOffset, heightTrav * Globals.BlockSide + Globals.TopBarOffset, BoxType.Start);



            }
            //same for Stop
          
            if (rb_stop.Checked) {
                for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                    for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++)
                        if (_rectangles[widthTrav][heightTrav].BoxType == BoxType.End)
                            _rectangles[widthTrav][heightTrav].SwitchEnd_StartToNormal();//allow only one end point


                for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                    for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++)
                        if (_rectangles[widthTrav][heightTrav].BoxRec.Contains(clickCoords)
                             &&
                            _rectangles[widthTrav][heightTrav].BoxType == BoxType.Normal) {
                            _rectangles[widthTrav][heightTrav] = new GridBox(widthTrav * Globals.BlockSide + Globals.LeftBarOffset, heightTrav * Globals.BlockSide + Globals.TopBarOffset, BoxType.End);
                        }
            }

            Redraw();//The main function of this executable.Contains almost every drawing and calculating stuff
            Invalidate();
        }

        
        private void nUD_AGVs_ValueChanged(object sender, EventArgs e) {

            //if we change the AGVs value from numeric updown,do the following
            bool removed = false;
            List<GridPos> startPosition = new List<GridPos>();

            Color for1 = Color.BlueViolet;
            Color for2 = Color.Orange;

            for (int i = 0; i < _startPos.Count; i++)
            {
                _AGVs[i] = new Vehicle(this)
                {
                    ID = i
                };
                if (i == 0) _AGVs[i].LineColor = for1;
                else _AGVs[i].LineColor = for2;
            }

            for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                for (var heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++) {
                    if (_rectangles[widthTrav][heightTrav].BoxType == BoxType.Start)
                        startPosition.Add(new GridPos(widthTrav, heightTrav));
                    //if we reduce the numeric value and become less than the already-drawn agvs,remove the rest agvs
                    if (startPosition.Count > nUD_AGVs.Value) {
                        _rectangles[startPosition[0].X][startPosition[0].Y].SwitchEnd_StartToNormal(); //removes the very last
                        removed = true;
                        
                        Invalidate();
                    }
                }
            if (removed)
                Redraw();
           
        }
        //parametres
        private void useRecursiveToolStripMenuItem_Click(object sender, EventArgs e) {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            neverCrossMenu.Checked = false;
            atLeastOneMenu.Checked = false;
            noObstaclesMenu.Checked = false;
            _jumpParam.DiagonalMovement = DiagonalMovement.Always;

            //do not allow to have an unselected item
            if (neverCrossMenu.Checked == false &&
            atLeastOneMenu.Checked == false &&
            noObstaclesMenu.Checked == false &&
            alwaysCrossMenu.Checked == false) {
                (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
                _jumpParam.DiagonalMovement = DiagonalMovement.Always;
            }
            Redraw();


        }

        private void crossAdjacentPointToolStripMenuItem_Click(object sender, EventArgs e) {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            alwaysCrossMenu.Checked = false;
            atLeastOneMenu.Checked = false;
            noObstaclesMenu.Checked = false;
            _jumpParam.DiagonalMovement = DiagonalMovement.Never;

            //do not allow to have an unselected item
            if (neverCrossMenu.Checked == false &&
            atLeastOneMenu.Checked == false &&
            noObstaclesMenu.Checked == false &&
            alwaysCrossMenu.Checked == false) {
                (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
                _jumpParam.DiagonalMovement = DiagonalMovement.Never;
            }
            Redraw();
        }

        private void crossCornerToolStripMenuItem_Click(object sender, EventArgs e) {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            alwaysCrossMenu.Checked = false;
            neverCrossMenu.Checked = false;
            noObstaclesMenu.Checked = false;
            _jumpParam.DiagonalMovement = DiagonalMovement.IfAtLeastOneWalkable;

            //do not allow to have an unselected item
            if (neverCrossMenu.Checked == false &&
            atLeastOneMenu.Checked == false &&
            noObstaclesMenu.Checked == false &&
            alwaysCrossMenu.Checked == false) {
                (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
                _jumpParam.DiagonalMovement = DiagonalMovement.IfAtLeastOneWalkable;
            }
            Redraw();
        }
        private void crossCornerOnlyWhenNoObstaclesToolStripMenuItem_Click(object sender, EventArgs e) {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            alwaysCrossMenu.Checked = false;
            atLeastOneMenu.Checked = false;
            neverCrossMenu.Checked = false;
            _jumpParam.DiagonalMovement = DiagonalMovement.OnlyWhenNoObstacles;

            //do not allow to have an unselected item
            if (neverCrossMenu.Checked == false &&
            atLeastOneMenu.Checked == false &&
            noObstaclesMenu.Checked == false &&
            alwaysCrossMenu.Checked == false) {
                (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
                _jumpParam.DiagonalMovement = DiagonalMovement.OnlyWhenNoObstacles;
            }
            Redraw();
        }

        //heurestic mode
        private void manhattanToolStripMenuItem_Click(object sender, EventArgs e) {
            if ((sender as ToolStripMenuItem).Checked)
                return;
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;

            _jumpParam.SetHeuristic(HeuristicMode.Manhattan);
            euclideanToolStripMenuItem.Checked = false;
            chebyshevToolStripMenuItem.Checked = false;
            Redraw();

        }

        private void euclideanToolStripMenuItem_Click(object sender, EventArgs e) {
            if ((sender as ToolStripMenuItem).Checked)
                return;
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            _jumpParam.SetHeuristic(HeuristicMode.Euclidean);
            manhattanToolStripMenuItem.Checked = false;
            chebyshevToolStripMenuItem.Checked = false;
            Redraw();
        }

        private void chebyshevToolStripMenuItem_Click(object sender, EventArgs e) {
            if ((sender as ToolStripMenuItem).Checked)
                return;
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            _jumpParam.SetHeuristic(HeuristicMode.Chebyshev);
            manhattanToolStripMenuItem.Checked = false;
            euclideanToolStripMenuItem.Checked = false;
            Redraw();
        }

        private void stepsToolStripMenuItem_Click(object sender, EventArgs e) {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;

            if (sender as ToolStripMenuItem == bordersToolStripMenuItem)
                UpdateBorderVisibility(!bordersToolStripMenuItem.Checked);
            else if (sender as ToolStripMenuItem == highlightOverCurrentBoxToolStripMenuItem)
                _allowHighlight = highlightOverCurrentBoxToolStripMenuItem.Checked;

            Redraw();
            Invalidate();

        }

        private void borderColorToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cd_grid.ShowDialog() == DialogResult.OK) {
                BackColor = cd_grid.Color;
                _selectedColor = cd_grid.Color;
                borderColorToolStripMenuItem.Checked = true;
            }
        }

        private void wallsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (nUD_AGVs.Value != 0)
                for (int agv = 0; agv < nUD_AGVs.Value; agv++)
                    _AGVs[agv].JumpPoints.Clear();

            for (int widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                for (int heightTrav = 0; heightTrav < Globals.HeightBlocks; heightTrav++)
                    switch (_rectangles[widthTrav][heightTrav].BoxType) {
                        case BoxType.Normal:
                        case BoxType.Start:
                        case BoxType.End:
                            break;
                        case BoxType.Wall:
                            _rectangles[widthTrav][heightTrav].SetNormalBox();
                            break;
                    }
            Invalidate();
            Redraw();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e) {
            FullyRestore();
        }

        private void borderColorToolStripMenuItem1_Click(object sender, EventArgs e) {
            BackColor = Color.DarkGray;
            borderColorToolStripMenuItem.Checked = false;
        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {

            int c = 0;
            for (short i = 0; i < _startPos.Count; i++)
                c += _AGVs[i].JumpPoints.Count;
            
        }

        private void nud_weight_ValueChanged(object sender, EventArgs e) {
            Redraw();
        }

        private void showGridBlockLocationsToolStripMenuItem_MouseLeave(object sender, EventArgs e) {
            Redraw();
            Refresh();
        }
        

        private void defaultGridSizeToolStripMenuItem_Click(object sender, EventArgs e) {
            Globals.BlockSide = 15;
            MeasureScreen();
            Initialization();
        }
    }
    
}
