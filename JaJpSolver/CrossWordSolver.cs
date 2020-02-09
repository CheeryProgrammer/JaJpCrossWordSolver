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
		private CrossWordLine[] _colsLines;
		private CrossWordLine[] _rowsLines;

		public Board Board { get; }
		public bool Solved => _colsLines.All(line => line.Solved);

		public CrossWordSolver(CrossWordTask task)
		{
			Board = new Board(task.ColumnsTasks.Length, task.RowsTasks.Length);
			_colsLines = ParseColsLines(task).ToArray();
			_rowsLines = ParseRowsLines(task).ToArray();
		}

		private IEnumerable<CrossWordLine> ParseColsLines(CrossWordTask task)
		{
			CrossWordLineTask[] colsTasks = task.ColumnsTasks;
			CrossWordLine[] columns = new CrossWordLine[colsTasks.Length];
			for (int colIndex = 0; colIndex < colsTasks.Length; colIndex++)
			{
				Point[] linePoints = Board.GetColumn(colIndex);
				Group[] groups = colsTasks[colIndex].Select(gLen => new Group(gLen)).ToArray();
				columns[colIndex] = new CrossWordLine(groups, linePoints, false);
			}
			return columns;
		}

		private CrossWordLine[] ParseRowsLines(CrossWordTask task)
		{
			CrossWordLineTask[] rowsTasks = task.RowsTasks;
			CrossWordLine[] rows = new CrossWordLine[rowsTasks.Length];
			for (int rowIndex = 0; rowIndex < rowsTasks.Length; rowIndex++)
			{
				Point[] linePoints = Board.GetRow(rowIndex);
				Group[] groups = rowsTasks[rowIndex].Select(gLen => new Group(gLen)).ToArray();
				rows[rowIndex] = new CrossWordLine(groups, linePoints, true);
			}
			return rows;
		}

		public void SolveStep()
		{
			foreach (var line in _colsLines)
			{
				line.SolveStep();
			}

			foreach (var line in _rowsLines)
			{
				line.SolveStep();
			}
		}

		public void SetManually(int colIndex, int rowIndex, CellType newCellType)
		{
			_colsLines[rowIndex].ResetGroupsOfPoint(colIndex);
			_rowsLines[colIndex].ResetGroupsOfPoint(rowIndex);
			switch (newCellType)
			{
				case CellType.None:
					Board.SetNone(colIndex, rowIndex);
					break;
				case CellType.Empty:
					Board.SetEmpty(colIndex, rowIndex);
					break;
				case CellType.Filled:
					Board.SetFilled(colIndex, rowIndex);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(newCellType), newCellType, null);
			}
		}
	}
}
