using System.Collections.Generic;
using JaJpSolver.Common;

namespace JaJpSolver.Extensions
{
	public static class PointsExtensions
	{
		public static IEnumerable<List<Point>> GetFilledSequences(this Point[] line)
		{
			var index = 0;
			List<Point> location;
			do
			{
				location = GetLocation(line, ref index);
				if (location != null)
				{
					yield return location;
				}
			} while (location != null);
		}

		private static List<Point> GetLocation(Point[] points, ref int index)
		{
			List<Point> location = null;

			while (index < points.Length && !points[index].IsFilled())
			{
				index++;
			}

			while (index < points.Length && points[index].IsFilled())
			{
				if (location == null)
				{
					location = new List<Point>();
				}
				location.Add(points[index++]);
			}

			return location;
		}
	}
}
