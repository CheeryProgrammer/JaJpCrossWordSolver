namespace JaJpSolver.Task
{
	public class CrossWordTask
	{
		public CrossWordLineTask[] ColumnsTasks { get; }
		public CrossWordLineTask[] RowsTasks { get; }
		
		public CrossWordTask(CrossWordLineTask[] colsTasks, CrossWordLineTask[] rowsTasks)
		{
			ColumnsTasks = colsTasks;
			RowsTasks = rowsTasks;
		}
	}
}
