using JaJpSolver.Common;
using JaJpSolver.LineProcessors;
using JaJpSolver.SolvingHistory;
using JaJpSolver.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaJpSolver
{
	public class CrossWordSolver
	{
		private CrossWordLine[] _colsLines;
		private CrossWordLine[] _rowsLines;
		private ILineProcessor[] _columnProcessors;
		private ILineProcessor[] _rowProcessors;
		private HistoryFrame _globalHistory;

		public Board Board { get; }
		public bool Solved => _colsLines.All(line => line.Solved);

		public CrossWordSolver(CrossWordTask task)
		{
			_globalHistory = new HistoryFrame();
			CreateLineProcessors();

			Board = new Board(task.ColumnsTasks.Length, task.RowsTasks.Length);

			_colsLines = ParseColsLines(task).ToArray();
			_rowsLines = ParseRowsLines(task).ToArray();
		}

		private void CreateLineProcessors()
		{
			_columnProcessors = new ILineProcessor[]
			{
				new ShiftProcessor(false),
				new FillProcessor(false),
				new EmptyProcessor(),
				new AffiliationProcessor(false),
				new CompletionProcessor(),
			};

			_rowProcessors = new ILineProcessor[]
			{
				new ShiftProcessor(true),
				new FillProcessor(true),
				new EmptyProcessor(),
				new AffiliationProcessor(true),
				new CompletionProcessor(),
			};
		}

		private IEnumerable<CrossWordLine> ParseColsLines(CrossWordTask task)
		{
			CrossWordLineTask[] colsTasks = task.ColumnsTasks;
			CrossWordLine[] columns = new CrossWordLine[colsTasks.Length];
			for (int colIndex = 0; colIndex < colsTasks.Length; colIndex++)
			{
				Point[] linePoints = Board.GetColumn(colIndex);
				Group[] groups = colsTasks[colIndex].Select(gLen => new Group(gLen)).ToArray();
				columns[colIndex] = new CrossWordLine(groups, linePoints, false, _columnProcessors);
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
				rows[rowIndex] = new CrossWordLine(groups, linePoints, true, _rowProcessors);
			}
			return rows;
		}

		public bool SolveStep()
		{
			var stepHistoryFrame = new HistoryFrame();
			foreach (var line in _colsLines)
			{
				if (!line.TrySolveStep(stepHistoryFrame))
					return false;
			}

			foreach (var line in _rowsLines)
			{
				if (!line.TrySolveStep(stepHistoryFrame))
					return false;
			}

			_globalHistory.Push(stepHistoryFrame);

			return true;
		}

		public void SetManually(int colIndex, int rowIndex, CellType newCellType)
		{
			_colsLines[colIndex].ResetGroupsOfPoint(rowIndex);
			_rowsLines[rowIndex].ResetGroupsOfPoint(colIndex);
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

		public void ResetAll()
		{
			for (int i = 0; i < _colsLines.Length; i++)
				_colsLines[i].Reset();
			
			for (int i = 0; i < _rowsLines.Length; i++)
				_rowsLines[i].Reset();
		}

		#region History walking

		public void StepBack()
		{
			_globalHistory.RollBack();
		}

		public void StepForward()
		{
			_globalHistory.RollForward();
		}

		#endregion
	}
}
