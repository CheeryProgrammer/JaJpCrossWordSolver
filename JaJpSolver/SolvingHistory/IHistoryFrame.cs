namespace JaJpSolver.SolvingHistory
{
	public interface IHistoryFrame
	{
		void Push(IRevertable changeState);
	}
}
