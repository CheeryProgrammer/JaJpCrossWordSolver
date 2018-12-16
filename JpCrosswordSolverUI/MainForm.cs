using JaJpSolver;
using JaJpSolver.Common;
using JaJpSolver.Task;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JpCrosswordSolverUI
{
	public partial class MainForm : Form
	{
		private CrossWordSolver _solver;
		private Graphics _boardGraphics;
		private CellType[,] _cells;

		private Pen _gridPen = Pens.Black;

		private int _cellSize = 20;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//InitSolver();
		}

		private void InitBoard()
		{
			var board = _solver.Board;
			var width = board.Points.GetLength(0);
			var height = board.Points.GetLength(1);
			var image = new Bitmap(width * (_cellSize + 1) + 1, height * (_cellSize + 1) + 1);
			_boardGraphics = Graphics.FromImage(image);
			_boardGraphics.SmoothingMode = SmoothingMode.AntiAlias;
			_boardGraphics.Clear(Color.LightYellow);
			DrawGridLines(_boardGraphics, width, height, _cellSize);

			pbCrossWord.Width = image.Width;
			pbCrossWord.Height = image.Height;
			pbCrossWord.Image = image;

			_cells = new CellType[width, height];
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					_cells[x, y] = CellType.None;
				}
			}
			DrawBoard(board);
		}

		private void DrawGridLines(Graphics boardGraphics, int boardWidth, int boardHeight, int cellSize)
		{
			for (int i = 0; i <= boardWidth; i++)
			{
				boardGraphics.DrawLine(_gridPen, i * (cellSize + 1), 0, i * (cellSize + 1), boardHeight * (cellSize + 1));
			}
			for (int i = 0; i <= boardHeight; i++)
			{
				boardGraphics.DrawLine(_gridPen, 0, i * (cellSize + 1), boardWidth * (cellSize + 1), i * (cellSize + 1));
			}
		}

		private void DrawBoard(Board board)
		{
			for (int x = 0; x < board.Points.GetLength(0); x++)
			{
				for (int y = 0; y < board.Points.GetLength(1); y++)
				{
					if (_cells[x, y] != board.Points[x, y].PointType)
					{
						_cells[x, y] = board.Points[x, y].PointType;
						DrawPoint(_boardGraphics, x, y, _cells[x, y]);
					}
				}
			}
		}

		private void DrawPoint(Graphics graphics, int x, int y, CellType cellType)
		{
			var cellSize = _cellSize;
			var cellRectangle = GetCellRectangle(x, y);

			switch (cellType)
			{
				case CellType.None:
					graphics.FillRectangle(Brushes.LightYellow, cellRectangle);
					break;
				case CellType.Empty:
					var scale = (int) (-cellSize / 2.5);
					cellRectangle.Inflate(scale, scale);
					graphics.FillEllipse(Brushes.Black, cellRectangle);
					break;
				case CellType.Filled:
					graphics.FillRectangle(Brushes.Black, cellRectangle);
					break;
				default:
					throw new InvalidOperationException("Unknown cell type");
			}
		}

		private Rectangle GetCellRectangle(int x, int y)
		{
			var cellUpperLeftX = x * (_cellSize + 1) + 1;
			var cellUpperLeftY = y * (_cellSize + 1) + 1;
			return new Rectangle(cellUpperLeftX, cellUpperLeftY, _cellSize, _cellSize);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			_boardGraphics?.Dispose();
			base.OnClosing(e);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openDialog = new OpenFileDialog())
			{
				openDialog.CheckPathExists = true;
				openDialog.Filter = "Text file|*.txt";
				openDialog.Multiselect = false;
				if(openDialog.ShowDialog() == DialogResult.OK)
				{
					var file = openDialog.FileName;
					var task = ParseTask(file);
					_solver = new CrossWordSolver(task);
					InitBoard();
				}
			}
		}

		private CrossWordTask ParseTask(string file)
		{
			var taskLoader = new CrossWordTaskLoader();
			taskLoader.TryLoadFromFile(file, out CrossWordTask task);
			return task;
		}

		private void btnSolveStep_Click(object sender, EventArgs e)
		{
			_solver.SolveStep();
		}
	}
}
