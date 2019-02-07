using JaJpSolver.Common;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver.LineProcessors
{

	class FillProcessor : ILineProcessor
	{
		private readonly bool _isHorizontal;

		public FillProcessor(bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
		}

		public void Process(Point[] points, Group[] groups)
		{
			for (int i = 0; i < groups.Length; i++)
			{
				ExcludeImpossibleLocations(points, groups[i], out int possibleLocationsCount);
				if (possibleLocationsCount == 1)
					FillFirstPossibleCells(points, groups[i]);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="g"></param>
		/// <param name="count"></param>
		private void ExcludeImpossibleLocations(Point[] points, Group g, out int locationCount)
		{
			locationCount = 0;
			var locations = FindLocations(points, g).ToList();

			foreach (var location in locations)
			{
				if (location.Count < g.Length)
				{
					foreach (var point in location)
					{
						point.ExcludeGroups(new []{g}, _isHorizontal);
					}

					continue;
				}

				locationCount++;
			}
		}

		private IEnumerable<List<Point>> FindLocations(Point[] points, Group g)
		{
			var index = 0;
			List<Point> location;
			do
			{
				location = GetLocation(points, g, ref index);
				if (location != null)
				{
					yield return location;
				}
			} while (location != null);
		}

		private List<Point> GetLocation(Point[] points, Group g, ref int index)
		{
			List<Point> location = null;

			while (index < points.Length && !points[index].BelongsTo(g, _isHorizontal))
			{
				index++;
			}

			while (index < points.Length && points[index].BelongsTo(g, _isHorizontal))
			{
				if (location == null)
				{
					location = new List<Point>();
				}
				location.Add(points[index++]);
			}

			return location;
		}

		private void FillFirstPossibleCells(Point[] points, Group g)
		{
			var location = points
				.SkipWhile(p => !p.BelongsTo(g, _isHorizontal))
				.TakeWhile(p => p.BelongsTo(g, _isHorizontal)).ToList();

			if (location.Count < (g.Length << 1))
			{
				var skip = location.Count - g.Length;
				var take = location.Count - (skip << 1);
				foreach (var point in location.Skip(skip).Take(take))
				{
					point.SetFilled();
				}
			}
		}
	}
}
