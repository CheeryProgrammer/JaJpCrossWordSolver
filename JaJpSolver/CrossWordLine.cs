using JaJpSolver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using JaJpSolver.LineProcessors;

namespace JaJpSolver
{
	public class CrossWordLine
	{
		private readonly Point[] _allPoints;
		private readonly bool _isHorizontal;
		private readonly IEnumerable<ILineProcessor> _lineProcessors;

		public Group[] Groups { get; }

		public bool Solved => _allPoints.All(p => p.PointType != CellType.None);

		public CrossWordLine(Group[] groups, Point[] allPoints, bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
			Groups = groups;

			_allPoints = allPoints;

			for (int i = 0; i < _allPoints.Length; i++)
			{
				_allPoints[i].SetPossibleGroups(Groups.ToList(), _isHorizontal);
			}

			_lineProcessors = new List<ILineProcessor>
			{
				new ShiftProcessor(_isHorizontal),
				new FillProcessor(_isHorizontal),
				new AffiliationProcessor(_isHorizontal),
				new CompletionProcessor(),
			};
		}

		public void SolveStep()
		{
			foreach (var lineProcessor in _lineProcessors)
			{
				lineProcessor.Process(_allPoints, Groups);
			}
		}

		public void ResetGroupsOfPoint(int index)
		{
			_allPoints[index].SetPossibleGroups(Groups.ToList(), _isHorizontal);
		}
	}
}