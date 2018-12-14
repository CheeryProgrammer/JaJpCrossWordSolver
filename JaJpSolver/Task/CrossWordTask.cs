using System.Collections.Generic;

namespace JaJpSolver.Task
{
	public class CrossWordTask
	{
		public CrossWordLineTask[] ColumnsTasks { get; }
		public CrossWordLineTask[] RowsTasks { get; }
		
		public CrossWordTask(List<CrossWordLineTask> colsTasks, List<CrossWordLineTask> rowsTasks)
		{
			ColumnsTasks = colsTasks.ToArray();
			RowsTasks = rowsTasks.ToArray();
		}
	}
}
