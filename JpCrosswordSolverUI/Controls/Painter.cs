using JaJpSolver.Common;

namespace JpCrosswordSolverUI.Controls
{
	internal class Painter
	{
		private readonly GridCell[,] _gridCells;
		private readonly int _maxX;
		private readonly int _maxY;

		public Painter(GridCell[,] gridCells)
		{
			_gridCells = gridCells;
			_maxX = _gridCells.GetLength(0);
			_maxY = _gridCells.GetLength(1);
		}

		public bool TryChangeCell(int x, int y, CellType newType)
		{
			var canChange = !(x >= _maxX || y >= _maxY
			                           || newType.Equals(_gridCells[x, y]?.Value));

			if (canChange)
			{
				if (_gridCells[x, y] != null)
					_gridCells[x, y].Value = newType;
				else
					_gridCells[x, y] = new GridCell(newType);
			}

			return canChange;
		}
	}
}
