using Algorithm;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PathFinding
{
    public partial class FindRoute : Form
    {
        private MatrixPath _matrixPath;
        string[] _lineasArchivo;
        string[] _tamanoMatriz;

        public FindRoute()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            this.btnFileUpload.Enabled = true;
            this.btnFind.Enabled = false;
            _matrixPath.FindPath();
            ProcessData();
        }

        private void BtnFileUpload_Click(object sender, EventArgs e)
        {
            this.btnFileUpload.Enabled = false;
            this.btnFind.Enabled = true;

            UploadFileData();
            InitializeData(UploadMatrix());
        }

        private void UploadFileData()
        {
            string fileName;
            OpenFileDialog _openFileDialog = new OpenFileDialog
                                            {
                                                Filter = "Text file (*.txt)|*.txt|All file(*.*)|*.*"
                                            };

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = _openFileDialog.FileName;
                _lineasArchivo = System.IO.File.ReadAllText(fileName).Replace("\r\n", "*").Split('*');
                _tamanoMatriz = _lineasArchivo[0].Split(' ');
            }
        }

        private Matrix UploadMatrix()
        {
            Matrix dataMatrix = new Matrix();
            List<Cell> listNode = new List<Cell>();
            dataMatrix.SortedListNode = new List<Cell>();

            dataMatrix.Rows = int.Parse(_tamanoMatriz[0]);
            dataMatrix.Columns = int.Parse(_tamanoMatriz[1]);

            dataMatrix.Data = new int[dataMatrix.Rows, dataMatrix.Columns];

            for (int contadorY = 0; contadorY <= dataMatrix.Rows - 1; contadorY++)
            {
                string[] linea = _lineasArchivo[contadorY + 1].Split(' ');
                for (int contadorX = 0; contadorX <= dataMatrix.Columns - 1; contadorX++)
                {
                    dataMatrix.Data[contadorX, contadorY] = int.Parse(linea[contadorX]);
                    Cell cell = new Cell
                    {
                        X = contadorX,
                        Y = contadorY,
                        Height = int.Parse(linea[contadorX])
                    };

                    listNode.Add(cell);
                }
            }

            dataMatrix.SortedListNode.AddRange(listNode.OrderByDescending(x => x.Height));

            return dataMatrix;
        }

        private void InitializeData(Matrix dataMatrix)
        {
            _matrixPath = new MatrixPath(dataMatrix);
        }

        private void ProcessData()
        {
            List<BetterRoad> roads = new List<BetterRoad>();
            int maxLengthPath;
            int maxDrop;
            _matrixPath.GetLastNodesPossiblePath().OrderByDescending(x => x.Level);
            _matrixPath.GetLastNodesPossiblePath().Reverse();
            var possiblePath = _matrixPath.GetLastNodesPossiblePath().Take(5);

            foreach (var item in possiblePath)
            {
                roads.Add(BuildPath(item));
            }

            maxLengthPath = roads.Max(p => p.LengthPath);
            maxDrop = roads.Max(p => p.DropPath);
            roads.Find(r => r.DropPath == maxDrop).Better = true;
            ShowPath(roads);
        }

        private BetterRoad BuildPath(Node lastNode)
        {
            List<Node> solutionPath = new List<Node>();
            BetterRoad road = new BetterRoad();
            StringBuilder path = new StringBuilder();
            int greaterHeight;
            int lessHeight;

            Node parent = lastNode.Parent;
            solutionPath.Add(lastNode);
            lessHeight = lastNode.Height;
            road.LengthPath = lastNode.Level;

            while (parent != null)
            {
                var nextNode = parent;
                solutionPath.Add((Node)nextNode);
                parent = (Node)nextNode.Parent;
            }
            solutionPath.Reverse();

            greaterHeight = solutionPath.First().Height;
            road.DropPath = greaterHeight - lessHeight;

            foreach (var node in solutionPath)
            {
                path.Append(" -> ");
                path.Append(node.Height.ToString());
                path.Append("[");
                path.Append(node.X.ToString());
                path.Append(",");
                path.Append(node.Y.ToString());
                path.Append("]");
            }
            path.Append("\r\n");

            road.Path = path.ToString();

            return road;
        }

        private void ShowPath(List<BetterRoad> betterRoads)
        {
            foreach (var node in betterRoads)
            {
                if (node.Better)
                    tbPathNodes.AppendText("Winner: ");
                else
                    tbPathNodes.AppendText("Choice: ");

                tbPathNodes.AppendText("\r\n");
                tbPathNodes.AppendText("Length of calculated Path: ");
                tbPathNodes.AppendText(node.LengthPath.ToString());
                tbPathNodes.AppendText("\r\n");
                tbPathNodes.AppendText("Drop of calculated Path: ");
                tbPathNodes.AppendText(node.DropPath.ToString());
                tbPathNodes.AppendText("\r\n");
                tbPathNodes.AppendText("Calculated Path: ");
                tbPathNodes.AppendText(node.Path.ToString());
                tbPathNodes.AppendText("\r\n");
            }
        }
    }
}
