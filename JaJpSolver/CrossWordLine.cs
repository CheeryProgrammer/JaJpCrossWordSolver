using JaJpSolver.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver
{
	public class CrossWordLine
	{
		private readonly Point[] _allPoints;
		private readonly bool _isHorizontal;

		public CrossWordLine(IEnumerable<Group> groups, IEnumerable<Point> allPoints, bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
			Groups = groups.ToArray();

			_allPoints = allPoints.ToArray();

			for (int i = 0; i < _allPoints.Length; i++)
			{
				_allPoints[i].SetPossibleGroups(Groups, _isHorizontal);
			}
		}

		public Group[] Groups { get; }

		public void SolveStep()
		{
			ShiftToBeginAndExludeGroups(_allPoints, Groups);
			ShiftToEndAndExcludeGroups(_allPoints, Groups);
			FillPossibleCells();
		}

		private void FillPossibleCells()
		{
			for (int i = 0; i < Groups.Length; i++)
			{
				ExcludeImpossibleLocations(Groups[i], out int possibleLocationsCount);
				if (possibleLocationsCount == 1)
					FillFirstPossibleCells(Groups[i]);
			}
		}

		private void ExcludeImpossibleLocations(Group g, out int count)
		{
			count = 0;
			bool inGroup = false;
			int freeSpace = 0;
			for (int i = 0; i < _allPoints.Length; i++)
			{
				var p = _allPoints[i];
				if (p.BelongsTo(g, _isHorizontal))
				{
					if (!inGroup)
					{
						inGroup = true;
						freeSpace = 1;
						count++;
					}
					else
					{
						freeSpace++;
					}
				}
				else
				{
					if (inGroup)
					{
						inGroup = false;
						if (g.Length > freeSpace)
						{
							for (int j = i - freeSpace; j < i; j++)
							{
								_allPoints[j].ExcludeGroups(new[] {g}, _isHorizontal);
								count--;
							}
						}
					}
				}
			}
		}

		private void FillFirstPossibleCells(Group g)
		{
			int startIndex = -1;
			int stopIndex = -1;
			for (int i = 0; i < _allPoints.Length; i++)
			{
				var p = _allPoints[i];
				if (p.BelongsTo(g, _isHorizontal))
				{
					if (startIndex == -1)
						startIndex = i;

					stopIndex = i;
				}
				else
				{
					if (startIndex != -1)
						break;
				}
			}
			if(startIndex == -1 || stopIndex == -1)
				throw new InvalidOperationException("Points belonged to group are not found");

			var length = stopIndex + 1 - startIndex;
			for (int i = startIndex + length - g.Length; i <= stopIndex - length + g.Length; i++)
			{
				_allPoints[i].SetFilled();
			}

			if (length == g.Length)
			{
				if (startIndex > 0)
					_allPoints[startIndex - 1].SetEmpty();
				if (stopIndex < _allPoints.Length - 1)
					_allPoints[stopIndex + 1].SetEmpty();
			}
		}

		private void ShiftToBeginAndExludeGroups(IEnumerable<Point> points, IEnumerable<Group> groups)
		{
			ShiftToOneSideAndExcludeGroups(points, groups);
		}

		private void ShiftToEndAndExcludeGroups(IEnumerable<Point> points, IEnumerable<Group> groups)
		{
			ShiftToOneSideAndExcludeGroups(points.Reverse(), groups.Reverse());
		}

		private void ShiftToOneSideAndExcludeGroups(IEnumerable<Point> points, IEnumerable<Group> groups)
		{
			var pointsArr = points.ToArray();
			var groupsArr = groups.ToArray();
			var currentGroupIndex = 0;
			var matchesCount = 0;
			for (int i = 0; i < pointsArr.Length; i++)
			{
				var currentPoint = pointsArr[i];
				var currentGroup = groupsArr[currentGroupIndex];
				if (currentPoint.BelongsTo(currentGroup, _isHorizontal))
				{
					matchesCount++;
					if (matchesCount >= currentGroup.Length)
					{
						// at least one whitespace between groups
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
				point.ExcludeGroups(groupsToExclude, _isHorizontal);
			}
		}
	}
}