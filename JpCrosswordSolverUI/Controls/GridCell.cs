using JaJpSolver.Common;

namespace JpCrosswordSolverUI.Controls
{
	internal class GridCell
	{
		public object Value;

		public GridCell(object value)
		{
			Value = value;
		}

		public static implicit operator GridCell(int value)
		{
			return new GridCell(value);
		}

		public static implicit operator GridCell(CellType value)
		{
			return new GridCell(value);
		}
	}
}