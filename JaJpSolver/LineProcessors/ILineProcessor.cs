using System.Collections.Generic;
using JaJpSolver.Common;
using JaJpSolver.SolvingHistory;

namespace JaJpSolver.LineProcessors
{
	public interface ILineProcessor
	{
		bool TryProcess(Point[] points, Group[] groups, IHistoryFrame historyFrame = null);
	}
}
