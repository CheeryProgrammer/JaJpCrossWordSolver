using System.Collections.Generic;
using System.Linq;
using JaJpSolver.Common;

namespace JaJpSolver.LineProcessors
{
	/// <summary>
	/// Удаляет группы из тех точек, которые не могут ей (группе) принадлежать.
	/// </summary>
	public class ShiftProcessor : LineProcessorBase
	{
		private readonly bool _isHorizontal;

		public ShiftProcessor(bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
		}

		protected override bool TryProcessInternal(Point[] points, Group[] groups)
		{
			ShiftToBeginAndExcludeGroups(points, groups);
			ShiftToEndAndExcludeGroups(points, groups);
			return true;
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
			var currentGroupIndex = 0;
			var matchesCount = 0;
			for (int i = 0; i < points.Length; i++)
			{
				var currentPoint = points[i];
				var currentGroup = groups[currentGroupIndex];
				if (currentPoint.CanBelongTo(currentGroup, _isHorizontal))
				{
					matchesCount++;
					if (matchesCount >= currentGroup.Length)
					{
						// at least one whitespace between groups
						i++;

						matchesCount = 0;
						if (++currentGroupIndex >= groups.Length)
							break;

						ExcludeGroups(points, 0, i + 1, groups.Skip(currentGroupIndex).ToArray(), _isHorizontal);
					}
				}
			}
		}
	}
}
