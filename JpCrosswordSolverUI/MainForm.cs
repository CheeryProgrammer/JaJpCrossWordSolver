using JaJpSolver;
using JaJpSolver.Common;
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
		private Board _board;
		private Graphics _boardGraphics;
		private CellType[,] _cells;

		private Pen _gridPen = Pens.Black;


		private int _width = 100;
		private int _height = 50;
		private int _cellSize = 20;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_board = new Board(_width, _height);
			var image = new Bitmap(_width * (_cellSize + 1) + 1, _height * (_cellSize + 1) + 1);
			_boardGraphics = Graphics.FromImage(image);
			_boardGraphics.SmoothingMode = SmoothingMode.AntiAlias;
			_boardGraphics.Clear(Color.LightYellow);
			DrawGridLines(_boardGraphics, _width, _height, _cellSize);

			pbCrossWord.Width = image.Width;
			pbCrossWord.Height = image.Height;
			pbCrossWord.Image = image;

			_cells = new CellType[_width, _height];
			for (int x = 0; x < _width; x++)
			{
				for (int y = 0; y < _height; y++)
				{
					_cells[x, y] = CellType.None;
				}
			}
			DrawBoard(_board);
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
	}
}
