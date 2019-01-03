using System;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver.Common
{
	public class Point
	{
		public int X { get; set; }
		public int Y { get; set; }
		public CellType PointType { get; private set; }
		public List<Group> PossibleVerticalGroups { get; private set; }
		public List<Group> PossibleHorizontalGroups { get; private set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
			PointType = CellType.None;
		}

		internal void SetPossibleGroups(IEnumerable<Group> groups, bool areHorizontal)
		{
			if (areHorizontal)
				PossibleHorizontalGroups = groups.ToList();
			else
				PossibleVerticalGroups = groups.ToList();
		}

		internal bool BelongsTo(Group group, bool isHorizontal)
		{
			var possibleGroups = isHorizontal ? PossibleHorizontalGroups : PossibleVerticalGroups;

			return possibleGroups.Contains(group);
		}

		public void ExcludeGroups(Group[] groupsToExclude, bool areHorizontal)
		{
			var possibleGroups = areHorizontal ? PossibleHorizontalGroups : PossibleVerticalGroups;

			if (possibleGroups.Any())
			{
				for (int i = 0; i < groupsToExclude.Length; i++)
				{
					var g = groupsToExclude[i];
					if (possibleGroups.Contains(g))
						possibleGroups.Remove(g);
				}

				if (!possibleGroups.Any())
					PointType = CellType.Empty;
			}
		}

		public void SetFilled()
		{
			PointType = CellType.Filled;
		}

		public void SetEmpty()
		{
			PointType = CellType.Empty;
		}
	}
}
