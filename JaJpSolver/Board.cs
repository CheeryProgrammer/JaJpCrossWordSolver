using JaJpSolver.Common;
using System;

namespace JaJpSolver
{
	public class Board
	{
		public Point[,] Points { get; }

		public Board(int cols, int rows)
		{
			Points = new Point[cols, rows];

			for (int i = 0; i < cols; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					Points[i, j] = new Point(i, j);
				}
			}
		}

		public Point[] GetRow(int rowIndex)
		{
			var row = new Point[Points.GetLength(0)];
			for (int colIndex = 0; colIndex < row.Length; colIndex++)
				row[colIndex] = Points[colIndex, rowIndex];
			return row;
		}

		public Point[] GetColumn(int colIndex)
		{
			var column = new Point[Points.GetLength(1)];
			for (int rowIndex = 0; rowIndex < column.Length; rowIndex++)
				column[rowIndex] = Points[colIndex, rowIndex];
			return column;
		}

		internal void SetNone(int x, int y)
		{
			Points[x, y].SetFilled();
		}

		internal void SetEmpty(int x, int y)
		{
			Points[x, y].SetEmpty();
		}

		internal void SetFilled(int x, int y)
		{
			Points[x, y].SetFilled();
		}
	}
}
