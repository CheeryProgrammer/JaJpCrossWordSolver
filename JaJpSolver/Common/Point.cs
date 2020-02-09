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
		public Group VerticalGroup { get; private set; }
		public Group HorizontalGroup { get; private set; }

		public Point()
		{
			
		}

		public Point(int x, int y)
		{
			X = x;
			Y = y;
			PointType = CellType.None;
		}

		internal void SetPossibleGroups(List<Group> groups, bool areHorizontal)
		{
			if (areHorizontal)
				PossibleHorizontalGroups = groups;
			else
				PossibleVerticalGroups = groups;
		}

		internal bool CanBelongTo(Group group, bool isHorizontal)
		{
			var possibleGroups = isHorizontal ? PossibleHorizontalGroups : PossibleVerticalGroups;
			return possibleGroups.Any(g => ReferenceEquals(g, group));
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
				{
					SetEmpty();
				}
			}
		}

		public void SetFilled()
		{
			PointType = CellType.Filled;
		}

		public void SetEmpty()
		{
			PointType = CellType.Empty;
			PossibleHorizontalGroups?.Clear();
			PossibleVerticalGroups?.Clear();
		}

		public bool IsFilled()
		{
			return PointType == CellType.Filled;
		}

		public (bool Exists, Group Group) HasSinglePossibleGroup(bool isHorizontal)
		{
			var points = isHorizontal ? PossibleHorizontalGroups : PossibleVerticalGroups;
			if (points.Count != 1)
				return (false, null);
			return (true, points[0]);
		}

		public void SetNone()
		{
			PointType = CellType.None;
		}

		public void SetGroup(Group g, bool isHorizontal)
		{
			if (isHorizontal)
				HorizontalGroup = g;
			else
				VerticalGroup = g;
		}

		public bool IsGroupDetermined(bool isHorizontal)
		{
			return isHorizontal ? HorizontalGroup != null : VerticalGroup != null;
		}
	}
}
