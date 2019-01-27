using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using JaJpSolver.Common;
using Point = System.Drawing.Point;

namespace JpCrosswordSolverUI.Controls
{
	class PuzzleGrid: Control
	{
		private readonly int _width;
		private readonly int _height;
		private int _cellSize;
		private readonly int _groupSize = 5;
		private readonly int _lineThickness = 10;
		private readonly int _groupLineThickness = 22;

		private readonly Pen _gridLinePen;
		private readonly Pen _groupGridLinePen;

		private bool _showHorizontalMainLines;
		private bool _showVerticalMainLines;

		public GridCell[,] GridCells { get; }
		public int ColumnsCount => GridCells.GetLength(0);
		public int RowsCount => GridCells.GetLength(1);

		public bool MovingEnabled { get; set; } = false;

		public event Action Moved;
		public event Action<float> Scaled;
		public event Action<int,int> HoveredPointChanged;

		public PuzzleGrid(int width, int height, int cellSize = 7, bool showHorizontalMainLines = true, bool showVerticalMainLines = true)
		{
			_width = width;
			_height = height;
			_cellSize = cellSize;
			_showHorizontalMainLines = showHorizontalMainLines;
			_showVerticalMainLines = showVerticalMainLines;
			_gridLinePen = new Pen(Brushes.Black, _lineThickness);
			_groupGridLinePen = new Pen(Brushes.Black, _groupLineThickness);

			GridCells = new GridCell[width, height];

			AdjustSize();

			base.BackColor = Color.Bisque;
			base.DoubleBuffered = true;
		}

		private void AdjustSize()
		{
			Width = (_width * (_cellSize + _lineThickness)) + _lineThickness;
			var hGroupCount = _width / _groupSize + (_width % _groupSize > 0 ? 1 : 0);
			if (_showVerticalMainLines)
				Width += ((hGroupCount + 1) * (_groupLineThickness - _lineThickness));

			Height = (_height * (_cellSize + _lineThickness)) + _lineThickness;
			var vGroupCount = _height / _groupSize + (_height % _groupSize > 0 ? 1 : 0);
			if(_showHorizontalMainLines)
				Height += ((vGroupCount + 1) * (_groupLineThickness - _lineThickness));
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.None;
			DrawGridLines(e.Graphics);
			DrawValues(e.Graphics);
		}

		private Rectangle GetCellRectangle(int x, int y)
		{
			var rowGroup = y / _groupSize + 1;
			var colGroup = x / _groupSize + 1;

			var cellX = (_cellSize + _lineThickness) * x - _lineThickness + 1;
			if(_showVerticalMainLines)
				cellX += (_groupLineThickness - _lineThickness) * colGroup;

			var cellY = (_cellSize + _lineThickness) * y - _lineThickness + 1;
			if(_showHorizontalMainLines)
				cellY += (_groupLineThickness - _lineThickness) * rowGroup;
			return new Rectangle(cellX,cellY, _cellSize, _cellSize);
		}

		private void DrawGridLines(Graphics g)
		{
			DrawCols(g);
			DrawRows(g);
		}

		private void DrawCols(Graphics g)
		{
			var col = 0f;
			for (int i = 0; i <= _width; i++)
			{
				var pen = (i % _groupSize > 0 && i != _width || !_showVerticalMainLines) ? _gridLinePen : _groupGridLinePen;
				col += pen.Width / 2;
				g.DrawLine(pen, col, 0, col, Height);
				col += pen.Width / 2 + _cellSize;
			}
		}

		private void DrawRows(Graphics g)
		{
			var row = 0f;
			for (int i = 0; i <= _height; i++)
			{
				var pen = (i % _groupSize > 0 && i != _height || !_showHorizontalMainLines) ? _gridLinePen : _groupGridLinePen;
				//row += pen.Width / 2;
				g.DrawLine(pen, 0, row + pen.Width / 2, Width, row + pen.Width / 2);
				row += pen.Width + _cellSize;
			}
		}

		private void DrawValues(Graphics g)
		{
			var colsCount = GridCells.GetLength(1);
			var rowsCount = GridCells.GetLength(0);
			for (int y = 0; y < colsCount; y++)
			{
				for (int x = 0; x < rowsCount; x++)
				{
					var cell = GridCells[x, y];
					if (cell != null)
					{
						var value = cell.Value;
						if (value is int)
						{
							DrawInt(g, x, y, (int) value);
						}

						if (value is CellType)
						{
							DrawCell(g, x, y, (CellType) value);
						}
					}
				}
			}
		}

		private static readonly StringFormat _stringFormat = new StringFormat(StringFormatFlags.NoClip)
			{Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center};

		private void DrawInt(Graphics g, int x, int y, int value)
		{
			var cellRect = GetCellRectangle(x, y);
			var fontSize = _cellSize / 2;
			if (fontSize == 0)
				return;
			var font = new Font(DefaultFont.FontFamily, fontSize);
			cellRect.Inflate(_cellSize, 0);
			g.DrawString(value.ToString(), font, Brushes.Black, cellRect, _stringFormat);
		}

		private void DrawCell(Graphics g, int x, int y, CellType type)
		{
			var cellRect = GetCellRectangle(x, y);
			switch (type)
			{
				case CellType.None:
					break;
				case CellType.Empty:
					var scale = (int)(-_cellSize / 3);
					cellRect.Inflate(scale, scale);
					g.FillEllipse(Brushes.Black, cellRect);
					break;
				case CellType.Filled:
					g.FillRectangle(Brushes.Black, cellRect);
					break;
				default:
					throw new InvalidOperationException("Unknown cell type");
			}
		}

		private System.Drawing.Point? _capturedLocation;
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (_capturedLocation.HasValue && MovingEnabled)
			{
				var loc = _capturedLocation.Value;
				var deltaX = loc.X - e.Location.X;
				var deltaY = loc.Y - e.Location.Y;
				var newX = Location.X - deltaX;
				var newY = Location.Y - deltaY;
				newX = newX > 0 ? 0 : newX;
				newY = newY > 0 ? 0 : newY;

				if (Width > Parent.Width)
				{
					if (newX < Parent.Width - Width)
						newX = Parent.Width - Width;
				}
				else
				{
					newX = 0;
				}

				if (Height > Parent.Height)
				{
					if (newY < Parent.Height - Height)
						newY = Parent.Height - Height;
				}
				else
				{
					newY = 0;
				}

				Location = new Point(newX, newY);
				Moved?.Invoke();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if((e.Button & MouseButtons.Left) == MouseButtons.Left)
				_capturedLocation = e.Location;
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			_capturedLocation = null;
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (!MovingEnabled)
				return;
			
			if ((ModifierKeys & Keys.Control) == Keys.Control)
			{
				float coeff = e.Delta > 0 ? 1.2f : 0.8f;
				ScaleByCoeff(coeff);
				Scaled?.Invoke(coeff);
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Right) != 0)
			{
				var cellCoords = FindCell(e.X, e.Y);
				HoveredPoint = new Point(cellCoords.X, cellCoords.Y);
			}
		}

		private Point _hoveredPoint;
		public Point HoveredPoint
		{
			get { return _hoveredPoint; }
			private set
			{
				_hoveredPoint = value;
				HoveredPointChanged?.Invoke(_hoveredPoint.X, HoveredPoint.Y);
			}
		}

		/// <summary>
		/// TODO: Needs to be fixed. Gives approximate results
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		private (int X, int Y) FindCell(int x, int y)
		{
			var gLen = _groupLineThickness + _cellSize * _groupSize + _lineThickness * (_groupSize - 1);
			var groupX = x / gLen + 1;
			var cellX = (x + 1 - (_groupLineThickness - _lineThickness) * (groupX - 1) - 1.5 * _lineThickness) / (_cellSize + _lineThickness);
			var groupY = y / gLen + 1;
			var cellY = (y + 1 - (_groupLineThickness - _lineThickness) * (groupY - 1) - 1.5 * _lineThickness) / (_cellSize + _lineThickness);
			return ((int)cellX + 1, (int)cellY + 1);
		}

		public void ScaleByCoeff(double coeff)
		{
			int oldSize = _cellSize;
			_cellSize = (int) (_cellSize * coeff);
			if (_cellSize == oldSize)
				_cellSize++;
			AdjustSize();
		}
	}
}


/*
 * a - thin
 * b - thick
 * c - cell
 *
 * 1	-	b																		g - 1
 * 2	-	b + cell + a															g - 1
 * 3	-	b + cell + a + cell + a													g - 1
 * 4	-	b + cell + a + cell + a + cell + a										g - 1
 * 5	-	b + cell + a + cell + a + cell + a + cell + a							g - 1
 * 6	-	b + cell + a + cell + a + cell + a + cell + a + cell + b				g - 2
 *
 * gLen = b + (cell + a) * gCount;
 * g = n / gLen + 1
 * n = b * g + (cell + a) * X
 * n = b * g + cell * X + a * (X - 1)
 */
