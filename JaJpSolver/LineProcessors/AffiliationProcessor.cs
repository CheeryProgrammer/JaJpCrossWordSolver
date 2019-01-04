using System;
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
				}
			}
		}

		private void ExcludeFromImpossiblePoints(Point[] points, Group @group, int index)
		{
			for (int i = 0; i < points.Length; i++)
			{
				if (Math.Abs(index - i) >= @group.Length)
				{
					points[i].ExcludeGroups(new []{@group}, _isHorizontal);
				}
			}
		}
	}
}


// 000XXXX00X
// 0123456789