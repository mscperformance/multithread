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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Diagnostics;

namespace kagv {

    public partial class MainForm {

        //function that resets all of the used objects so they are ready for reuse, preventing memory leaks
        private void FullyRestore() {


          
            _labeled_loads = 0;

            if (_onWhichStep != null)
                Array.Clear(_onWhichStep, 0, _onWhichStep.GetLength(0));

            if (_trappedStatus != null)
                Array.Clear(_trappedStatus, 0, _trappedStatus.GetLength(0));


            for (short i = 0; i < _AGVs.Count; i++)
                _AGVs[i].KillIcon();
            

            if (BackgroundImage != null)
                BackgroundImage = null;

            StackTrace trace = new StackTrace();
            if (trace.GetFrame(1).GetMethod().Name != "Import")
            {
                Globals.SemiTransparency = false;
                _boxDefaultColor = (Globals.SemiTransparency) ? Color.FromArgb(Globals.Opacity, Color.WhiteSmoke) : Color.WhiteSmoke;
            }
            
            _fromstart = new bool[Globals.MaximumAGVs];


            _startPos = new List<GridPos>();
            _endPointCoords = new Point(-1, -1);
            _selectedColor = Color.DarkGray;

            for (short i = 0; i < _startPos.Count(); i++)
                _AGVs[i].JumpPoints = new List<GridPos>();


            _searchGrid = new StaticGrid(Globals.WidthBlocks, Globals.HeightBlocks);

            _alwaysCross =
            aGVIndexToolStripMenuItem.Checked =
            _beforeStart =
            _allowHighlight = true;

            _atLeastOneObstacle =
            _ifNoObstacles =
            _never =
            _imported =
            _calibrated =
            _isMouseDown =
            _mapHasLoads = false;
            
            priorityRulesbetaToolStripMenuItem.Checked = false;

            _importedLayout = null;
            _jumpParam = null;
            _paper = null;
            _loads = _posIndex = 0;

            _a
            = _b
            = new int();


            _AGVs = new List<Vehicle>();
           
            _allowHighlight = true;
            highlightOverCurrentBoxToolStripMenuItem.Enabled = true;
            highlightOverCurrentBoxToolStripMenuItem.Checked = true;



            _isLoad = new int[Globals.WidthBlocks, Globals.HeightBlocks];
            _rectangles = new GridBox[Globals.WidthBlocks][];
            for (var widthTrav = 0; widthTrav < Globals.WidthBlocks; widthTrav++)
                _rectangles[widthTrav] = new GridBox[Globals.HeightBlocks];

            //jagged array has to be resetted like this
            for (var i = 0; i < Globals.WidthBlocks; i++)
                for (var j = 0; j < Globals.HeightBlocks; j++)
                    _rectangles[i][j] = new GridBox(i * Globals.BlockSide, j * Globals.BlockSide + Globals.TopBarOffset, BoxType.Normal);


            Initialization();

            main_form_Load(new object(), new EventArgs());

            for (short i = 0; i < _AGVs.Count; i++)
                _AGVs[i].Status.Busy = false;
           

            nUD_AGVs.Value = _AGVs.Count;


        }
    }
}
