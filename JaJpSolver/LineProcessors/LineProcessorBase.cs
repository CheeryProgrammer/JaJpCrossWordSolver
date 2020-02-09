using JaJpSolver.Common;
using JaJpSolver.SolvingHistory;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver.LineProcessors
{
	public abstract class LineProcessorBase : ILineProcessor
	{
		private IHistoryFrame _historyFrame;

		public bool TryProcess(Point[] points, Group[] groups, IHistoryFrame historyFrame = null)
		{
			_historyFrame = historyFrame;
			return TryProcessInternal(points, groups);
		}

		protected abstract bool TryProcessInternal(Point[] points, Group[] groups);

		protected virtual bool TrySetState(Point target, CellType newType)
		{
			if (target.IsProcessed && target.PointType != newType)
				return false;

			var oldState = target.PointType;
			switch (newType)
			{
				case CellType.None:
					target.SetNone(); break;
				case CellType.Empty:
					target.SetEmpty(); break;
				case CellType.Filled:
					target.SetFilled(); break;
			}
			if (oldState != newType)
				_historyFrame?.Push(new CellChangeState(target, oldState, target.PointType));
			return true;
		}

		public void ExcludeGroups(Point[] points, int startIndex, int count, Group[] groups, bool areHorizontal)
		{
			for (int i = startIndex; i < count; i++)
			{
				var existed = areHorizontal ? points[i].PossibleHorizontalGroups : points[i].PossibleVerticalGroups;
				var toExlude = groups.Intersect(existed).ToArray();

				if (toExlude.Length > 0)
				{
					_historyFrame?.Push(new GroupChangeState(points[i], toExlude, areHorizontal, true));
					points[i].ExcludeGroups(toExlude, areHorizontal);
				}
			}
		}

		public void ExcludeGroup(Point point, Group group, bool areHorizontal)
		{
			var existed = areHorizontal ? point.PossibleHorizontalGroups : point.PossibleVerticalGroups;

			if (existed.Contains(group))
			{
				var groups = new[] { group };
				_historyFrame?.Push(new GroupChangeState(point, groups, areHorizontal, true));
				point.ExcludeGroups(groups, areHorizontal);
			}
		}
	}
}
