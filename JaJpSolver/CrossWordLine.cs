using JaJpSolver.Common;
using System.Linq;
using JaJpSolver.LineProcessors;
using JaJpSolver.SolvingHistory;

namespace JaJpSolver
{
	public class CrossWordLine
	{
		private readonly Point[] _allPoints;
		private readonly bool _isHorizontal;
		private readonly ILineProcessor[] _lineProcessors;

		public Group[] Groups { get; }

		public bool Solved => _allPoints.All(p => p.PointType != CellType.None);

		public CrossWordLine(Group[] groups, Point[] allPoints, bool isHorizontal, ILineProcessor[] lineProcessors)
		{
			_isHorizontal = isHorizontal;
			Groups = groups;

			_allPoints = allPoints;

			for (int i = 0; i < _allPoints.Length; i++)
			{
				_allPoints[i].SetPossibleGroups(Groups.ToList(), _isHorizontal);
			}

			_lineProcessors = lineProcessors;
		}

		public bool TrySolveStep(IHistoryFrame historyFrame)
		{
			foreach (var lineProcessor in _lineProcessors)
			{
				if(!lineProcessor.TryProcess(_allPoints, Groups, historyFrame))
					return false;
			}
			return true;
		}

		public void ResetGroupsOfPoint(int index)
		{
			_allPoints[index].SetPossibleGroups(Groups.ToList(), _isHorizontal);
		}

		public void Reset()
		{
			for (int i = 0; i < _allPoints.Length; i++)
			{
				_allPoints[i].SetNone();
				ResetGroupsOfPoint(i);
			}
		}
	}
}