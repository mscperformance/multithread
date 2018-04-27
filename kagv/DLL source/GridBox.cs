﻿/*! 
@file GridBox.cs
@author Woong Gyu La a.k.a Chris. <juhgiyo@gmail.com>
		<http://github.com/juhgiyo/eppathfinding.cs>
@date July 16, 2013
@brief GridBox Interface
@version 2.0

@section LICENSE

The MIT License (MIT)

Copyright (c) 2013 Woong Gyu La <juhgiyo@gmail.com>
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

namespace kagv.DLL_source {
    internal enum BoxType { Start, End, Wall, Normal, Load };

    internal class GridBox : IDisposable {
        public int X, Y, Width, Height;

        public Rectangle BoxRec;
        public BoxType BoxType;

        private readonly Color _myBrown = Color.FromArgb(138, 109, 86);
        private SolidBrush _brush;
        public GridBox(int iX, int iY, BoxType iType) {
            X = iX;
            Y = iY;
            BoxType = iType;
            switch (iType) {
                case BoxType.Normal:
                    _brush = Globals.SemiTransparency ? new SolidBrush(Globals.SemiTransparent) : new SolidBrush(Color.WhiteSmoke);
                    break;
                case BoxType.End:
                    _brush = new SolidBrush(Color.Red);
                    break;
                case BoxType.Start:
                    _brush = new SolidBrush(Color.Green);
                    break;
                case BoxType.Wall:
                    _brush = new SolidBrush(Color.Gray);
                    break;
                case BoxType.Load:
                    _brush = new SolidBrush(_myBrown);
                    break;

            }
            Width = Height = Globals.BlockSide - 1;

            BoxRec = new Rectangle(X, Y, Width, Height);
        }

        public void DrawBox(Graphics iPaper, BoxType iType) {
            if (iType == BoxType) {
                BoxRec.X = X;
                BoxRec.Y = Y;
                iPaper.FillRectangle(_brush, BoxRec);
            }
        }

        public void OnHover(Color c) {
            _brush = new SolidBrush(c);
        }

        public void SwitchEnd_StartToNormal(){
            _brush?.Dispose();
            _brush = Globals.SemiTransparency ? new SolidBrush(Globals.SemiTransparent) : new SolidBrush(Color.WhiteSmoke);
            BoxType = BoxType.Normal;

        }


        public void SetAsTargetted(Graphics iPaper) {
            iPaper.FillRectangle(new SolidBrush(Color.Orange), BoxRec);
        }


        public void BeTransparent() {
            switch (BoxType) {
                case BoxType.Normal:
                    _brush = new SolidBrush(Color.Transparent);
                    break;
            }
        }

        public void BeVisible() {
            switch (BoxType) {
                case BoxType.Normal:
                    _brush = Globals.SemiTransparency ? new SolidBrush(Globals.SemiTransparent) : new SolidBrush(Color.WhiteSmoke);
                    break;
                case BoxType.Wall:
                    _brush?.Dispose();
                    BoxType = BoxType.Normal;
                    break;
            }
        }


        public void SwitchLoad() {
            switch (BoxType) {
                case BoxType.Normal:
                    _brush?.Dispose();
                    _brush = new SolidBrush(_myBrown);
                    BoxType = BoxType.Load;
                    break;
                case BoxType.Load:
                    _brush?.Dispose();

                    _brush = Globals.SemiTransparency ? new SolidBrush(Globals.SemiTransparent) : new SolidBrush(Color.WhiteSmoke);
                    BoxType = BoxType.Normal;
                    break;

            }
        }


        public void SwitchBox() {
            switch (BoxType) {
                case BoxType.Normal:
                    _brush?.Dispose();
                    _brush = new SolidBrush(Color.Gray);
                    BoxType = BoxType.Wall;
                    break;
                case BoxType.Wall:
                    _brush?.Dispose();
                    _brush = new SolidBrush(Color.WhiteSmoke);
                    BoxType = BoxType.Normal;
                    break;

            }
        }

        public void SetNormalBox() {
            _brush?.Dispose();
            _brush = new SolidBrush(Color.WhiteSmoke);
            BoxType = BoxType.Normal;
        }

        public void SetStartBox() {
            _brush?.Dispose();
            _brush = new SolidBrush(Color.Green);
            BoxType = BoxType.Start;
        }

        public void SetEndBox() {
            _brush?.Dispose();
            _brush = new SolidBrush(Color.Red);
            BoxType = BoxType.End;
        }


        public void Dispose()
        {
            _brush?.Dispose();
        }
    }
}
