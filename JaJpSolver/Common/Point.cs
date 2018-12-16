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
		public List<Group> PossibleGroups { get; private set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
			PointType = CellType.None;
		}

		internal void SetPossibleGroups(IEnumerable<Group> groups)
		{
			PossibleGroups = groups.ToList();
		}

		internal bool BelongsTo(Group group)
		{
			return PossibleGroups.Contains(group);
		}
	}
}
