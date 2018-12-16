using JaJpSolver.Common;
using JaJpSolver.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaJpSolver
{
	public class CrossWordSolver
	{
		private CrossWordTask _task;
		private Board _board;
		private IEnumerable<CrossWordLine> _colsLines;
		private IEnumerable<CrossWordLine> _rowsLines;

		public Board Board { get => _board; }

		public CrossWordSolver(CrossWordTask task)
		{
			_task = task;
			InitializeBoard(task);
			_colsLines = ParseColsLines(task);
			_rowsLines = ParseRowsLines(task);
		}

		private void InitializeBoard(CrossWordTask task)
		{
			_board = new Board(task.ColumnsTasks.Length, task.RowsTasks.Length);
		}

		private IEnumerable<CrossWordLine> ParseColsLines(CrossWordTask task)
		{
			var cols = task.ColumnsTasks;
			for (int colIndex = 0; colIndex < cols.Length; colIndex++)
			{
				var rowPoints = GetColumnFromBoard(Board.Points, colIndex);
				yield return new CrossWordLine(cols[colIndex].Select(gLen => new Group(gLen, rowPoints)));
			}
		}

		private IEnumerable<CrossWordLine> ParseRowsLines(CrossWordTask task)
		{
			var rows = task.RowsTasks;
			for(int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
			{
				var rowPoints = GetRowFromBoard(Board.Points, rowIndex);
				yield return new CrossWordLine(rows[rowIndex].Select(gLen=> new Group(gLen)), rowPoints);
			}
		}

		private IEnumerable<Point> GetRowFromBoard(Point[,] points, int rowIndex)
		{
			for (int i = 0; i < points.GetLength(0); i++)
			{
				yield return points[i, rowIndex];
			}
		}

		private IEnumerable<Point> GetColumnFromBoard(Point[,] points, int colIndex)
		{
			for (int i = 0; i < points.GetLength(1); i++)
			{
				yield return points[colIndex, i];
			}
		}

		public void SolveStep()
		{
			foreach(var line in _colsLines)
			{
				line.TrySolve();
			}
		}
	}
}
