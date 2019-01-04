using System.Collections.Generic;
using System.Linq;
using JaJpSolver;
using JaJpSolver.Common;

namespace JaJpSolverTests
{
	public static class TestHelper
	{
		public static string RenderToString(this IEnumerable<Point> points)
		{
			return string.Join(string.Empty, points.Select(p =>
			{
				switch (p.PointType)
				{
					case CellType.Empty: return ".";
					case CellType.Filled: return "X";
					default: return "0";
				}
			}));
		}

		public static IEnumerable<Group> ParseGroups(string lineData)
		{
			return lineData.Split(',')
				.Select(n => new Group(int.Parse(n)));
		}
	}
}
