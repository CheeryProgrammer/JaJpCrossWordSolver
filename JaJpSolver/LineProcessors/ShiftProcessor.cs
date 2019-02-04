using System.Collections.Generic;
using System.Linq;
using JaJpSolver.Common;

namespace JaJpSolver.LineProcessors
{
	/// <summary>
	/// Удаляет группы из тех точек, которые не могут ей (группе) принадлежать.
	/// </summary>
	class ShiftProcessor : ILineProcessor
	{
		private readonly bool _isHorizontal;

		public ShiftProcessor(bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
		}

		public void Process(Point[] points, Group[] groups)
		{
			ShiftToBeginAndExcludeGroups(points, groups);
			ShiftToEndAndExcludeGroups(points, groups);
		}
		
		private void ShiftToBeginAndExcludeGroups(Point[] points, Group[] groups)
		{
			ShiftToOneSideAndExcludeGroups(points, groups);
		}

		private void ShiftToEndAndExcludeGroups(Point[] points, Group[] groups)
		{
			var reversedPoints = points.Reverse().ToArray();
			var reversedGroups= groups.Reverse().ToArray();

			ShiftToOneSideAndExcludeGroups(reversedPoints, reversedGroups);
		}

		private void ShiftToOneSideAndExcludeGroups(Point[] points, Group[] groups)
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
