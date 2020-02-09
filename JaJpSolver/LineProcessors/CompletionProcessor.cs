using System.Linq;
using JaJpSolver.Common;
using JaJpSolver.Extensions;

namespace JaJpSolver.LineProcessors
{
	public class CompletionProcessor : LineProcessorBase
	{
		protected override bool TryProcessInternal(Point[] points, Group[] groups)
		{
			var filledGroups = points.GetFilledSequences().ToList();
			if (filledGroups.Count == groups.Length)
			{
				if(filledGroups.Select(fg=>fg.Count).SequenceEqual(groups.Select(g => g.Length)))
				{
					foreach (var point in points.Where(p=>!p.IsFilled()))
					{
						if (!TrySetState(point, CellType.Empty))
							return false;
					}
				}
			}
			return true;
		}
	}
}
