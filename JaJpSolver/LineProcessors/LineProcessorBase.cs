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
			var maxIndex = startIndex + count;
			for (int i = startIndex; i < maxIndex; i++)
			{
				var excluded = new List<Group>();

				for (int groupdIndex = 0; groupdIndex < groups.Length; groupdIndex++)
				{
					if (points[i].TryExcludeGroup(groups[groupdIndex], areHorizontal))
						excluded.Add(groups[groupdIndex]);
				}

				if (excluded.Count > 0)
					_historyFrame?.Push(new GroupChangeState(points[i], excluded.ToArray(), areHorizontal, true));
			}
		}

		public void ExcludeGroup(Point point, Group group, bool areHorizontal)
		{
			if(point.TryExcludeGroup(group, areHorizontal))
				_historyFrame?.Push(new GroupChangeState(point, new [] { group }, areHorizontal, true));
		}
	}
}
