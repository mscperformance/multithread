﻿namespace MultiThreadingAStar
{
    public delegate float HeuristicDelegate(int iDx, int iDy);

    public abstract class ParamBase
    {
        public ParamBase(BaseGrid iGrid, GridPos iStartPos, GridPos iEndPos, HeuristicMode iMode) : this(iGrid, iMode)
        {
            m_startNode = m_searchGrid.GetNodeAt(iStartPos.x, iStartPos.y);
            m_endNode = m_searchGrid.GetNodeAt(iEndPos.x, iEndPos.y);
            if (m_startNode == null)
                m_startNode = new Node(iStartPos.x, iStartPos.y, true);
            if (m_endNode == null)
                m_endNode = new Node(iEndPos.x, iEndPos.y, true);
        }

        public ParamBase(BaseGrid iGrid, HeuristicMode iMode)
        {
            SetHeuristic(iMode);
            m_searchGrid = iGrid;
            m_startNode = null;
            m_endNode = null;
        }

        public ParamBase(ParamBase param)
        {
            m_searchGrid = param.m_searchGrid;
            m_startNode = param.m_startNode;
            m_endNode = param.m_endNode;
            
        }

        internal abstract void _reset(GridPos iStartPos, GridPos iEndPos, BaseGrid iSearchGrid = null);

        public void Reset(GridPos iStartPos, GridPos iEndPos, BaseGrid iSearchGrid = null)
        {
            _reset(iStartPos, iEndPos, iSearchGrid);
            m_startNode = null;
            m_endNode = null;

            if (iSearchGrid != null)
                m_searchGrid = iSearchGrid;
            m_searchGrid.Reset();
            m_startNode = m_searchGrid.GetNodeAt(iStartPos.x, iStartPos.y);
            m_endNode = m_searchGrid.GetNodeAt(iEndPos.x, iEndPos.y);
            if (m_startNode == null)
                m_startNode = new Node(iStartPos.x, iStartPos.y, true);
            if (m_endNode == null)
                m_endNode = new Node(iEndPos.x, iEndPos.y, true);
        }
        
        public HeuristicDelegate HeuristicFunc
        {
            get
            {
                return m_heuristic;
            }
        }

        public BaseGrid SearchGrid
        {
            get
            {
                return m_searchGrid;
            }
        }

        public Node StartNode
        {
            get
            {
                return m_startNode;
            }
        }
        public Node EndNode
        {
            get
            {
                return m_endNode;
            }
        }

        public void SetHeuristic(HeuristicMode iMode)
        {
            m_heuristic = null;
            m_heuristic = new HeuristicDelegate(Heuristic.Euclidean);
        }

        protected BaseGrid m_searchGrid;
        protected Node m_startNode;
        protected Node m_endNode;
        protected HeuristicDelegate m_heuristic;
    }
}
