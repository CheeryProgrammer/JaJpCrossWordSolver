using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using JaJpSolver;
using JaJpSolver.Common;

namespace JpCrosswordSolverUI
{
	class FieldRenderer: IDisposable
	{
		private int _cellSize = 20;

		private PictureBox _pbCrossWord;
		private Graphics _boardGraphics;
		private CellType[,] _cells;

		private Pen _gridPen = Pens.Black;

		private static Color _bckgColor = Color.LightYellow;
		private SolidBrush _bckgBrush = new SolidBrush(_bckgColor);
		private SolidBrush BckgBrush
		{
			get { return _bckgBrush.Color == _bckgColor ? _bckgBrush : _bckgBrush = new SolidBrush(_bckgColor); }
		}

		public FieldRenderer(PictureBox pbCrossWord)
		{
			_pbCrossWord = pbCrossWord;
		}

		public void InitBoard(Board board)
		{
			var width = board.Points.GetLength(0);
			var height = board.Points.GetLength(1);
			var image = new Bitmap(width * (_cellSize + 1) + 1, height * (_cellSize + 1) + 1);
			_boardGraphics = Graphics.FromImage(image);
			_boardGraphics.SmoothingMode = SmoothingMode.AntiAlias;
			_boardGraphics.Clear(_bckgColor);
			DrawGridLines(_boardGraphics, width, height, _cellSize);

			_pbCrossWord.Width = image.Width;
			_pbCrossWord.Height = image.Height;
			_pbCrossWord.Image = image;

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

		public void DrawBoard(Board board)
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
			_pbCrossWord.Refresh();
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

		private void DrawPoint(Graphics graphics, int x, int y, CellType cellType)
		{
			var cellSize = _cellSize;
			var cellRectangle = GetCellRectangle(x, y);

			switch (cellType)
			{
				case CellType.None:
					graphics.FillRectangle(BckgBrush, cellRectangle);
					break;
				case CellType.Empty:
					var scale = (int)(-cellSize / 2.5);
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

		public void Dispose()
		{
			_boardGraphics?.Dispose();
		}
	}
}
