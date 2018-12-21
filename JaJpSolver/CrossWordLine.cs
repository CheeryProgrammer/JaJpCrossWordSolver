using JaJpSolver.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver
{
	public class CrossWordLine
	{
		private readonly Point[] _allPoints;
		public CrossWordLine(IEnumerable<Group> groups, IEnumerable<Point> allPoints)
		{
			Groups = groups.ToArray();

			_allPoints = allPoints.ToArray();

			for (int i = 0; i < _allPoints.Length; i++)
			{
				_allPoints[i].SetPossibleGroups(Groups);
			}
		}

		public Group[] Groups { get; }

		public void SolveStep()
		{
			ShiftToBegin(_allPoints, Groups);
			ShiftToEnd(_allPoints, Groups);
		}

		private void ShiftToBegin(IEnumerable<Point> points, IEnumerable<Group> groups)
		{
			ShiftToOneSide(points, groups);
		}

		private void ShiftToEnd(IEnumerable<Point> points, IEnumerable<Group> groups)
		{
			ShiftToOneSide(points.Reverse(), groups.Reverse());
		}

		private void ShiftToOneSide(IEnumerable<Point> points, IEnumerable<Group> groups)
		{
			var pointsArr = points.ToArray();
			var groupsArr = groups.ToArray();
			var currentGroupIndex = 0;
			var matchesCount = 0;
			for (int i = 0; i < pointsArr.Length; i++)
			{
				var currentPoint = pointsArr[i];
				var currentGroup = groupsArr[currentGroupIndex];
				if (currentPoint.BelongsTo(currentGroup))
				{
					matchesCount++;
					if (matchesCount >= currentGroup.Length)
					{
						// at least one white space between groups
						i++;

						matchesCount = 0;
						if (++currentGroupIndex >= groupsArr.Length)
							break;

						ExcludeGroups(pointsArr.Take(i + 1), groupsArr.Skip(currentGroupIndex).ToArray());
					}
				}
			}
		}

		private void ExcludeGroups(IEnumerable<Point> points, Group[] groupsToExclude)
		{
			foreach (var point in points)
			{
				point.ExcludeGroups(groupsToExclude);
			}
		}
	}
}