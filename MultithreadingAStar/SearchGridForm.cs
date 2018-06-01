﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MultiThreadingAStar
{
    public partial class SearchGridForm : Form
    {
        bool isMouseDown;
        bool isMultiThreading=true;

        const int width = 64;
        const int height = 32;
        Graphics paper;

        GridBox[][] m_rectangles;
        List<ResultBox> m_resultBox;
        List<GridLine> m_resultLine;

        GridBox m_lastBoxSelect;
        BoxType m_lastBoxType;

        BaseGrid searchGrid;
        AStarParam jumpParam;

        private void init()
        {
            DoubleBuffered = true;

            m_resultBox = new List<ResultBox>();
            Width = (width + 1) * 20;
            Height = (height + 1) * 20 + 100;
            MaximumSize = new Size(Width, Height);
            MaximizeBox = false;

            m_rectangles = new GridBox[width][];
            for (int widthTrav = 0; widthTrav < width; widthTrav++)
            {
                m_rectangles[widthTrav] = new GridBox[height];
                for (int heightTrav = 0; heightTrav < height; heightTrav++)
                {
                    if (widthTrav == (width / 3) && heightTrav == (height / 2))
                        m_rectangles[widthTrav][heightTrav] = new GridBox(widthTrav * 20, heightTrav * 20 + 50, BoxType.Start);
                    else if (widthTrav == 41 && heightTrav == (height / 2))
                        m_rectangles[widthTrav][heightTrav] = new GridBox(widthTrav * 20, heightTrav * 20 + 50, BoxType.End);
                    else
                        m_rectangles[widthTrav][heightTrav] = new GridBox(widthTrav * 20, heightTrav * 20 + 50, BoxType.Normal);


                }
            }


            m_resultLine = new List<GridLine>();

            searchGrid = new StaticGrid (width, height);

            jumpParam = new AStarParam(searchGrid, 50, HeuristicMode.EUCLIDEAN);
        }
        public SearchGridForm()
        {
            InitializeComponent();
            init();
          
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            paper = e.Graphics;
            //Draw
            
            for (int widthTrav = 0; widthTrav < width; widthTrav++)
            {
                for (int heightTrav = 0; heightTrav < height; heightTrav++)
                {
                    m_rectangles[widthTrav][heightTrav].DrawBox(paper,BoxType.Normal);
                }
            }
            

            
            for (int resultTrav = 0; resultTrav < m_resultBox.Count; resultTrav++)
            {
                m_resultBox[resultTrav].drawBox(paper);
            }
            

            
            for (int widthTrav = 0; widthTrav < width; widthTrav++)
            {
                for (int heightTrav = 0; heightTrav < height; heightTrav++)
                {
                    m_rectangles[widthTrav][heightTrav].DrawBox(paper, BoxType.Start);
                    m_rectangles[widthTrav][heightTrav].DrawBox(paper, BoxType.End);
                    m_rectangles[widthTrav][heightTrav].DrawBox(paper, BoxType.Wall);
                }
            }
             
            for (int resultTrav = 0; resultTrav < m_resultLine.Count; resultTrav++)
            {

                m_resultLine[resultTrav].drawLine(paper);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (e.Button == MouseButtons.Left)
            {
                m_lastBoxSelect = null;
            }
         //   Redraw();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (m_lastBoxSelect == null)
                    {
                        for (int widthTrav = 0; widthTrav < width; widthTrav++)
                        {
                            for (int heightTrav = 0; heightTrav < height; heightTrav++)
                            {
                                if (m_rectangles[widthTrav][heightTrav].boxRec.IntersectsWith(new Rectangle(e.Location, new Size(1, 1))))
                                {
                                    m_lastBoxType = m_rectangles[widthTrav][heightTrav].boxType;
                                    m_lastBoxSelect = m_rectangles[widthTrav][heightTrav];
                                    switch (m_lastBoxType)
                                    {
                                        case BoxType.Normal:
                                        case BoxType.Wall:
                                            m_rectangles[widthTrav][heightTrav].SwitchBox();
                                            this.Invalidate();
                                            break;
                                        case BoxType.Start:
                                        case BoxType.End:

                                            break;
                                    }
                                }


                            }
                        }

                        return;
                    }
                    else
                    {
                        for (int widthTrav = 0; widthTrav < width; widthTrav++)
                        {
                            for (int heightTrav = 0; heightTrav < height; heightTrav++)
                            {
                                if (m_rectangles[widthTrav][heightTrav].boxRec.IntersectsWith(new Rectangle(e.Location, new Size(1, 1))))
                                {
                                    if (m_rectangles[widthTrav][heightTrav] == m_lastBoxSelect)
                                    {
                                        return;
                                    }
                                    else
                                    {

                                        switch (m_lastBoxType)
                                        {
                                            case BoxType.Normal:
                                            case BoxType.Wall:
                                                if (m_rectangles[widthTrav][heightTrav].boxType == m_lastBoxType)
                                                {
                                                    m_rectangles[widthTrav][heightTrav].SwitchBox();
                                                    m_lastBoxSelect = m_rectangles[widthTrav][heightTrav];
                                                    this.Invalidate();
                                                }
                                                break;
                                            case BoxType.Start:
                                                m_lastBoxSelect.SetNormalBox();
                                                m_lastBoxSelect = m_rectangles[widthTrav][heightTrav];
                                                m_lastBoxSelect.SetStartBox();
                                                this.Invalidate();
                                                break;
                                            case BoxType.End:
                                                m_lastBoxSelect.SetNormalBox();
                                                m_lastBoxSelect = m_rectangles[widthTrav][heightTrav];
                                                m_lastBoxSelect.SetEndBox();
                                                this.Invalidate();
                                                break;
                                        }


                                    }
                                }


                            }
                        }
                    }

                }

              //  Redraw();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            if (e.Button == MouseButtons.Left)
            {
                for (int widthTrav = 0; widthTrav < width; widthTrav++)
                {
                    for (int heightTrav = 0; heightTrav < height; heightTrav++)
                    {
                        if (m_rectangles[widthTrav][heightTrav].boxRec.IntersectsWith(new Rectangle(e.Location, new Size(1, 1))))
                        {
                           
                            m_lastBoxType =m_rectangles[widthTrav][heightTrav].boxType;
                            m_lastBoxSelect = m_rectangles[widthTrav][heightTrav];
                            switch(m_lastBoxType)
                            {
                                case BoxType.Normal:
                                case BoxType.Wall:
                                m_rectangles[widthTrav][heightTrav].SwitchBox();
                                this.Invalidate();
                               
                                break;
                                case BoxType.Start:
                                case BoxType.End:
                                   
                                break;
                            }
                        }


                    }
                }
                
            }
            
        }

        private void Redraw()
        {
            foreach (GridLine l in m_resultLine) l.Dispose(); 
            m_resultLine = new List<GridLine>();
            List<GridPos> resultList = new List<GridPos>();
            searchGrid = new StaticGrid(width, height);
            jumpParam = new AStarParam(searchGrid, 50, HeuristicMode.EUCLIDEAN);
            Invalidate();

            for (int resultTrav = 0; resultTrav < m_resultLine.Count; resultTrav++)
            {

                m_resultLine[resultTrav].Dispose();
            }
            m_resultLine.Clear();
            for (int resultTrav = 0; resultTrav < m_resultBox.Count; resultTrav++)
            {

                m_resultBox[resultTrav].Dispose();
            }
            m_resultBox.Clear();
            
            GridPos startPos = new GridPos();
            GridPos endPos = new GridPos();
            for (int widthTrav = 0; widthTrav < width; widthTrav++)
            {
                for (int heightTrav = 0; heightTrav < height; heightTrav++)
                {
                    if (m_rectangles[widthTrav][heightTrav].boxType != BoxType.Wall)
                    {
                        searchGrid.SetWalkableAt(new GridPos(widthTrav, heightTrav), true);
                    }
                    else
                    {
                        searchGrid.SetWalkableAt(new GridPos(widthTrav, heightTrav), false);
                    }
                    if (m_rectangles[widthTrav][heightTrav].boxType == BoxType.Start)
                    {
                        startPos.x = widthTrav;
                        startPos.y = heightTrav;
                    }
                    if (m_rectangles[widthTrav][heightTrav].boxType == BoxType.End)
                    {
                        endPos.x = widthTrav;
                        endPos.y = heightTrav;
                    }

                }
            }
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();
            jumpParam.Reset(startPos, endPos);
            resultList = AStarFinder.FindPath(jumpParam,isMultiThreading);
            double time = s.ElapsedMilliseconds;
            s.Reset();
            

            if (isMultiThreading)
                lb_multi.Text = "Time elapsed with multithreading: " + time + " ms.";
            else
                lb_multi.Text = "Time elapsed without multithreading: " + time + " ms.";

            for (int resultTrav = 0; resultTrav < resultList.Count - 1; resultTrav++)
            {
                m_resultLine.Add(new GridLine(m_rectangles[resultList[resultTrav].x][resultList[resultTrav].y], m_rectangles[resultList[resultTrav + 1].x][resultList[resultTrav + 1].y]));
            }
            for (int widthTrav = 0; widthTrav < jumpParam.SearchGrid.width; widthTrav++)
            {
                for (int heightTrav = 0; heightTrav < jumpParam.SearchGrid.height; heightTrav++)
                {
                    if (jumpParam.SearchGrid.GetNodeAt(widthTrav, heightTrav) == null)
                        continue;
                    if (jumpParam.SearchGrid.GetNodeAt(widthTrav, heightTrav).isOpened)
                    {
                        ResultBox resultBox = new ResultBox(widthTrav * 20, heightTrav * 20 + 50, ResultBoxType.Opened);
                        m_resultBox.Add(resultBox);
                    }
                    if (jumpParam.SearchGrid.GetNodeAt(widthTrav, heightTrav).isClosed)
                    {
                        ResultBox resultBox = new ResultBox(widthTrav * 20, heightTrav * 20 + 50, ResultBoxType.Closed);
                        m_resultBox.Add(resultBox);
                    }
                }
            }
            Invalidate();
        }


        private void CleanPath()
        {
            for (int resultTrav = 0; resultTrav < m_resultLine.Count; resultTrav++)
            {

                m_resultLine[resultTrav].Dispose();
            }
            m_resultLine.Clear();

            for (int resultTrav = 0; resultTrav < m_resultBox.Count; resultTrav++)
            {
                m_resultBox[resultTrav].Dispose();
            }

            m_resultBox.Clear();
            m_resultBox = new List<ResultBox>();
            this.Invalidate();
        }
        private void btn_benchmark_Click(object sender, System.EventArgs e)
        {
            CleanPath();
            MessageBox.Show("Press OK to start the benchmarking");
            Redraw();
        }

        private void cb_multi_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cb_multi.Checked)
            {
                lb_multi.Text = "Time elapsed with multithreading:";
                isMultiThreading = true;
            }
            else
            {
                lb_multi.Text = "Time elapsed without multithreading:";
                isMultiThreading = false;
            }
          
        }
    }
}
