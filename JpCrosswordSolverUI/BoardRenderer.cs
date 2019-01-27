using System.Drawing;
using JaJpSolver;
using JaJpSolver.Common;
using JpCrosswordSolverUI.Controls;

namespace JpCrosswordSolverUI
{
	class BoardRenderer
	{
		private PuzzleGrid _pictureGrid;

		public BoardRenderer(PuzzleGrid pictureGrid)
		{
			_pictureGrid = pictureGrid;
		}

		public void UpdateBoard(Board board)
		{
			var colsCount = _pictureGrid.ColumnsCount;
			var rowsCount = _pictureGrid.RowsCount;
			for (int y = 0; y < rowsCount; y++)
			{
				for (int x = 0; x < colsCount; x++)
				{
					var oldValue = _pictureGrid.GridCells[x, y]?.Value ?? CellType.None;
					var newValue = board.Points[x, y].PointType;
					if (!newValue.Equals(oldValue))
						_pictureGrid.GridCells[x, y] = newValue;
				}
			}
			_pictureGrid.Refresh();
		}
	}
}
