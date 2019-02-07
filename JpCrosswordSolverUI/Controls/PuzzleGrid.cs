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
		public int CellSize => _cellSize;
		private readonly int _groupSize = 5;
		public int GroupSize => _groupSize;
		private readonly int _lineThickness = 1;
		public int LineThickness => _lineThickness;
		private readonly int _groupLineThickness = 2;
		public int GroupLineThickness => _groupLineThickness;

		private readonly Pen _gridLinePen;
		private readonly Pen _groupGridLinePen;

		private readonly ControlMover _controlMover;
		private CoordinatesTranslator _coordinatesTranslator;
		private readonly Painter _painter;

		private bool _showHorizontalMainLines;
		private bool _showVerticalMainLines;

		public GridCell[,] GridCells { get; }
		public int ColumnsCount => GridCells.GetLength(0);
		public int RowsCount => GridCells.GetLength(1);

		public bool MovingEnabled { get; set; } = false;

		/// <summary>
		/// Raised when control is moved
		/// </summary>
		public event Action Moved;

		/// <summary>
		/// Raised when picture grid is scaled
		/// </summary>
		public event Action<float> Scaled;

		/// <summary>
		/// Used for coordinates tracking
		/// </summary>
		public event Action<int,int> HoveredPointChanged;

		/// <summary>
		/// Raised when CellType is changed
		/// </summary>
		public event Action<int,int,CellType> CellChanged;

		public PuzzleGrid(int width, int height, int cellSize = 7, bool showHorizontalMainLines = true, bool showVerticalMainLines = true)
		{
			_width = width;
			_height = height;
			_cellSize = cellSize;
			_showHorizontalMainLines = showHorizontalMainLines;
			_showVerticalMainLines = showVerticalMainLines;
			_gridLinePen = new Pen(Brushes.Black, _lineThickness);
			_groupGridLinePen = new Pen(Brushes.Black, _groupLineThickness);
			_controlMover = new ControlMover(this);
			_coordinatesTranslator = new CoordinatesTranslator(this, showHorizontalMainLines, showVerticalMainLines);

			GridCells = new GridCell[width, height];
			_painter = new Painter(GridCells);

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


		#region Drawing control and contents
		
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
			var cellRect = _coordinatesTranslator.GetCellRectangle(x, y);
			var fontSize = _cellSize / 2;
			if (fontSize == 0)
				return;
			var font = new Font(DefaultFont.FontFamily, fontSize);
			cellRect.Inflate(_cellSize, 0);
			g.DrawString(value.ToString(), font, Brushes.Black, cellRect, _stringFormat);
		}

		private void DrawCell(Graphics g, int x, int y, CellType type)
		{
			var cellRect = _coordinatesTranslator.GetCellRectangle(x, y);
			switch (type)
			{
				case CellType.None:
					break;
				case CellType.Empty:
					var scale = (int)(-_cellSize / 3);
					cellRect.Inflate(scale, scale);
					g.FillEllipse(_drawingBrush, cellRect);
					break;
				case CellType.Filled:
					g.FillRectangle(_drawingBrush, cellRect);
					break;
				default:
					throw new InvalidOperationException("Unknown cell type");
			}
		}

		#endregion

		protected override void OnMouseMove(MouseEventArgs e)
		{
			PrintStatistics(e);

			if (!MovingEnabled)
				return;

			if (_controlMover.Active)
			{
				_controlMover.Move(e.Location);
				Moved?.Invoke();
			}
			else
			{
				if ((e.Button & MouseButtons.Right) != 0)
				{
					DrawManually(e);
				}
			}
		}

		private void PrintStatistics(MouseEventArgs e)
		{
			var cellCoords = _coordinatesTranslator.FindCell(e.X, e.Y);
			cellCoords.X--;
			cellCoords.Y--;
			if (cellCoords.X >= 0 
			    && cellCoords.X < _width
			    && cellCoords.Y >= 0
			    && cellCoords.Y < _height)
			{
				HoveredPoint = new Point(cellCoords.X, cellCoords.Y);
			}
		}

		private void DrawManually(MouseEventArgs e)
		{
			var coords = _coordinatesTranslator.FindCell(e.X, e.Y);
			coords.X--;
			coords.Y--;
			if (_painter.TryChangeCell(coords.X, coords.Y, PaintMode))
				CellChanged?.Invoke(coords.X, coords.Y, PaintMode);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				_controlMover.Begin(e.Location);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			_controlMover.End();
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
				DrawManually(e);
			}
		}

		private Point _hoveredPoint;
		private Brush _drawingBrush = Brushes.Gray;
		public CellType PaintMode { get; set; }

		public Point HoveredPoint
		{
			get { return _hoveredPoint; }
			private set
			{
				_hoveredPoint = value;
				HoveredPointChanged?.Invoke(_hoveredPoint.X, HoveredPoint.Y);
			}
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
