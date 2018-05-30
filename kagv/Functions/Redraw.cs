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
using System.Windows.Forms;

namespace kagv {

    public partial class MainForm {

        //Basic path planner function
        private void Redraw() {

            bool startFound = false;
            bool endFound = false;

            GridPos endPos = new GridPos();

            _posIndex = 0;
            _startPos = new List<GridPos>(); //list that will be filled with the starting points of every AGV
            _AGVs = new List<Vehicle>();  //list that will be filled with objects of the class Vehicle

            Color for1 = Color.BlueViolet;
            Color for2 = Color.DarkOrange;

            for (int i = 0; i < _AGVs.Count; i++)
            {
                _AGVs[i] = new Vehicle(this)
                {
                    ID = i
                };
                if (i == 0) _AGVs[i].LineColor = for1;
                else _AGVs[i].LineColor = for2;
            }

            //Double FOR-loops to scan the whole Grid and perform the needed actions
            for (var i = 0; i < Globals.WidthBlocks; i++)
                for (var j = 0; j < Globals.HeightBlocks; j++) {

                    if (_rectangles[i][j].BoxType == BoxType.Wall)
                        _searchGrid.SetWalkableAt(new GridPos(i, j), false);//Walls are marked as non-walkable
                    else
                        _searchGrid.SetWalkableAt(new GridPos(i, j), true);//every other block is marked as walkable (for now)

                   
                    if (_rectangles[i][j].BoxType == BoxType.Normal)
                        _rectangles[i][j].OnHover(_boxDefaultColor);

                    if (_rectangles[i][j].BoxType == BoxType.Start) {

                        if (_beforeStart) {
                            _searchGrid.SetWalkableAt(new GridPos(i, j), false); //initial starting points of AGV are non walkable until 1st run is completed
                        } else
                            _searchGrid.SetWalkableAt(new GridPos(i, j), true);

                        startFound = true;

                        _AGVs.Add(new Vehicle(this));
                        _AGVs[_posIndex].ID = _posIndex;
                        if (_posIndex == 0) _AGVs[_posIndex].LineColor = for1;
                        else _AGVs[_posIndex].LineColor = for2;

                        _startPos.Add(new GridPos(i, j)); //adds the starting coordinates of an AGV to the StartPos list

                        //a & b are used by DrawPoints() as the starting x,y for calculation purposes
                        _a = _startPos[_posIndex].X;
                        _b = _startPos[_posIndex].Y;

                        if (_posIndex < _startPos.Count) {
                            _startPos[_posIndex] = new GridPos(_startPos[_posIndex].X, _startPos[_posIndex].Y);
                            _posIndex++;
                        }
                    }

                    if (_rectangles[i][j].BoxType == BoxType.End) {
                        endFound = true;
                        endPos.X = i;
                        endPos.Y = j;
                        _endPointCoords = new Point(i * Globals.BlockSide, j * Globals.BlockSide + Globals.TopBarOffset);
                    }
                }



            if (!startFound || !endFound)
                return; //will return if there are no starting or end points in the Grid


            _posIndex = 0;

            if (_AGVs != null)
                for (short i = 0; i < _AGVs.Count(); i++)
                    if (_AGVs[i] != null) {
                        _AGVs[i].UpdateAGV();
                        _AGVs[i].Status.Busy = false; //initialize the status of _AGVs, as 'available'
                    }

            //Choose how to run the FindPath function (one or more threads)


           
            //For-loop to repeat the path-finding process for ALL the _AGVs that participate in the simulation
            for (short i = 0; i < _startPos.Count; i++)
            {
                List<GridPos> jumpPointsList;
                _jumpParam.Reset(_startPos[_posIndex], endPos);
              
                jumpPointsList = AStarFinder.FindPath(_jumpParam, Globals.AStarWeight, Globals.isMultiThread);
               
                _AGVs[i].JumpPoints = jumpPointsList;
                _posIndex++;
            }
          
            int c = 0;
            for (short i = 0; i < _startPos.Count; i++)
                c += _AGVs[i].JumpPoints.Count;


            for (short i = 0; i < _startPos.Count; i++)
                for (int j = 0; j < _AGVs[i].JumpPoints.Count - 1; j++) {
                    GridLine line = new GridLine
                        (
                        _rectangles[_AGVs[i].JumpPoints[j].X][_AGVs[i].JumpPoints[j].Y],
                        _rectangles[_AGVs[i].JumpPoints[j + 1].X][_AGVs[i].JumpPoints[j + 1].Y]
                        );

                    _AGVs[i].Paths[j] = line;
                }

            for (int i = 0; i < _startPos.Count; i++)
                if ((c - 1) > 0)
                    Array.Resize(ref _AGVs[i].Paths, c - 1); //resize of the _AGVs steps Table
         
            Invalidate();

          
           //
        }
    }
}
