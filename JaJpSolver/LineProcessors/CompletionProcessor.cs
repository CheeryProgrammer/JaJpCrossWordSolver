using System.Collections.Generic;
using System.Linq;
using JaJpSolver.Common;

namespace JaJpSolver.LineProcessors
{
	class CompletionProcessor : ILineProcessor
	{
		public void Process(Point[] points, Group[] groups)
		{
			var filledGroups = FindLocations(points).ToList();
			if (filledGroups.Count == groups.Length)
			{
				if(filledGroups.Select(fg=>fg.Count).SequenceEqual(groups.Select(g => g.Length)))
				{
					foreach (var point in points.Where(p=>!p.IsFilled()))
					{
						point.SetEmpty();
					}
				}
			}
		}

		private IEnumerable<List<Point>> FindLocations(Point[] points)
		{
			var index = 0;
			List<Point> location;
			do
			{
				location = GetLocation(points, ref index);
				if (location != null)
				{
					yield return location;
				}
			} while (location != null);
		}

		private List<Point> GetLocation(Point[] points, ref int index)
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
