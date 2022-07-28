using Data;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class MatrixPath
    {
        private Matrix _dataMatrix;
        private Cell _currentCell;
        private List<Node> _lastNodePossiblePaths;
        private readonly List<Node> _neighbourList;
        private readonly int _totalCells;
        private int _higherLevel;

        public MatrixPath(Matrix dataMatrix)
        {
            _dataMatrix = new Matrix();
            _dataMatrix = dataMatrix;
            _neighbourList = new List<Node>();
            _lastNodePossiblePaths = new List<Node>();
            _totalCells = (_dataMatrix.Columns * _dataMatrix.Rows) - 1;
        }

        public List<Node> GetLastNodesPossiblePath()
        {
            return _lastNodePossiblePaths;
        }

        public void FindPath() 
        {
            for (int i = 0; i <= _totalCells; i++)
            {
                _currentCell = _dataMatrix.SortedListNode[0];

                Node parent = new Node()
                {
                    X = _currentCell.X,
                    Y = _currentCell.Y,
                    Height = _currentCell.Height
                };

                FindPathNodes(parent, 0);
                _dataMatrix.SortedListNode.Remove(_currentCell);
            }
        }

        private void FindPathNodes(Node parent, int cont)
        {
            Node neighbour = null;
            List<Node> neighbourListParent = new List<Node>();

            if (cont == 0)
            {
                cont++;
                parent.Level = cont;
            }

            if (parent != null)
            {
                neighbourListParent = GetNeighbours(parent);
                _neighbourList.AddRange(neighbourListParent);
            }

            if (neighbourListParent.Count <= 0)
            {
                if (_lastNodePossiblePaths.Count <= 0)
                    _lastNodePossiblePaths.Add(parent);
                else
                {
                    var higer = _lastNodePossiblePaths.Find(x => x.Level > parent.Level);

                    if (higer == null && parent.Level >= _higherLevel)
                    {
                        _higherLevel = parent.Level;
                        _lastNodePossiblePaths.Add(parent);
                    }
                }
            }

            neighbour = _neighbourList.FirstOrDefault();
            _neighbourList.Remove(neighbour);

            if(neighbour == null && _neighbourList.Count <=0)
                return;

            FindPathNodes(neighbour, cont);
        }

        protected List<Node> GetNeighbours(Node parent)
        {
            var neighbours = new List<Node>();
            int coordXMinus = parent.X - 1;
            int coordXAdd = parent.X + 1;
            int coordYMinus = parent.Y - 1;
            int coordYAdd = parent.Y + 1;

            int step = parent.Level + 1;

            //Left
            if (coordXMinus >= 0 && _dataMatrix.Data[coordXMinus, parent.Y] < parent.Height)
            {
                neighbours.Add(new Node() { X = coordXMinus, Y = parent.Y, Parent = parent, Height = _dataMatrix.Data[coordXMinus, parent.Y], Level = step });
            }

            //Right
            if (coordXAdd < _dataMatrix.Columns && _dataMatrix.Data[coordXAdd, parent.Y] < parent.Height)
            {
                neighbours.Add(new Node() { X = coordXAdd, Y = parent.Y, Parent = parent, Height = _dataMatrix.Data[coordXAdd, parent.Y], Level = step });
            }

            //Up
            if (coordYMinus >= 0 && _dataMatrix.Data[parent.X, coordYMinus] < parent.Height)
            {
                neighbours.Add(new Node() { X = parent.X, Y = coordYMinus, Parent = parent, Height = _dataMatrix.Data[parent.X, coordYMinus], Level = step });
            }

            //Down
            if (coordYAdd < _dataMatrix.Rows && _dataMatrix.Data[parent.X, coordYAdd] < parent.Height)
            {
                neighbours.Add(new Node() { X = parent.X, Y = coordYAdd, Parent = parent, Height = _dataMatrix.Data[parent.X, coordYAdd], Level = step });
            }

            return neighbours;
        }


    }
}
