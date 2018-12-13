using JaJpSolver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
