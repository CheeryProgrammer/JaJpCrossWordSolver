using System;
using System.Linq;
using JaJpSolver.Common;

namespace JaJpSolver.LineProcessors
{

	public class AffiliationProcessor: ILineProcessor
	{
		private readonly bool _isHorizontal;

		public AffiliationProcessor(bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
		}

		public void Process(Point[] points, Group[] groups)
		{
			for (int i = 0; i < points.Length; i++)
			{
				var p = points[i];
				var singlePossible = p.HasSinglePossibleGroup(_isHorizontal);
				if (p.IsFilled() && singlePossible.Exists)
				{
					ExcludeFromImpossiblePoints(points, singlePossible.Group, i);
					var left = points.Take(i);
					var right = points.Skip(i + 1);
					var currentGroupIndex = groups.ToList().IndexOf(singlePossible.Group);
					foreach (var point in left)
					{
						point.ExcludeGroups(groups.Skip(currentGroupIndex + 1).ToArray(), _isHorizontal);
					}
					foreach (var point in right)
					{
						point.ExcludeGroups(groups.Take(currentGroupIndex).ToArray(), _isHorizontal);
					}

					// todo: for the same group remove other groups from list of possible.
				}
			}
		}

		private void ExcludeFromImpossiblePoints(Point[] points, Group g, int index)
		{
			for (int i = 0; i < points.Length; i++)
			{
				if (Math.Abs(index - i) >= g.Length)
				{
					points[i].ExcludeGroups(new[] {g}, _isHorizontal);
				}
			}
		}
	}
}


// 000XXXX00X
// 0123456789