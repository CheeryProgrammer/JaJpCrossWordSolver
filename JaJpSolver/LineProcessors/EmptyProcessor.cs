using JaJpSolver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaJpSolver.LineProcessors
{
	class EmptyProcessor : LineProcessorBase
	{
		protected override bool TryProcessInternal(Point[] points, Group[] groups)
		{
			for (int i = 0; i < points.Length; i++)
			{
				if (points[i].NoColumnOrRowGroupsPossible)
				{
					if (!TrySetState(points[i], CellType.Empty))
					{
						return false;
					}
				}

				if (points[i].PointType == CellType.Empty)
				{
					ExcludeGroups(points, i, 1, points[i].PossibleHorizontalGroups.ToArray(), true);
					ExcludeGroups(points, i, 1, points[i].PossibleVerticalGroups.ToArray(), false);
				}
			}
			return true;
		}
	}
}
