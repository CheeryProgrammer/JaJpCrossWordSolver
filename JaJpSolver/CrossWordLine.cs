using JaJpSolver.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver
{
	internal class CrossWordLine
	{
		private readonly Point[] _allPoints;
		public CrossWordLine(IEnumerable<Group> groups, IEnumerable<Point> allPoints)
		{
			Groups = groups.ToArray();

			_allPoints = allPoints.ToArray();
			
			for (int i = 0; i < _allPoints.Length; i++)
			{
				_allPoints[i].SetPossibleGroups(groups);
			}

		}

		public Group[] Groups { get; }

		internal void TrySolve()
		{
			ShiftToBegin();
			ShiftToEnd();
		}

		private void ShiftToBegin()
		{
			var currentGroupIndex = 0;
			var matchesCount = 0;
			for (int i = 0; i < _allPoints.Length; i++)
			{
				var currentPoint = _allPoints[i];
				var currentGroup = Groups[currentGroupIndex];
				if (currentPoint.BelongsTo(currentGroup))
				{
					matchesCount++;
					if(matchesCount >= currentGroup.Length)
					{
						// at least one white space between groups
						i++;

						matchesCount = 0;
						currentGroupIndex++;
					}
				}

			}
		}

		private void ShiftToEnd()
		{
			throw new NotImplementedException();
		}
	}
}