using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver.SolvingHistory
{
	public class HistoryFrame : IHistoryFrame, IRevertable
	{
		private ConcurrentStack<IRevertable> _historyBackStack;
		private ConcurrentStack<IRevertable> _historyForwardStack;

		public HistoryFrame()
		{
			_historyBackStack = new ConcurrentStack<IRevertable>();
			_historyForwardStack = new ConcurrentStack<IRevertable>();
		}

		public void Push(IRevertable cellChangeState)
		{
			if (_historyForwardStack.Any())
				_historyForwardStack.Clear();

			_historyBackStack.Push(cellChangeState);
		}

		public void RollBack()
		{
			if (_historyBackStack.Any())
			{
				_historyBackStack.TryPop(out IRevertable revert);
				var undoRevert = revert.Revert();
				_historyForwardStack.Push(undoRevert);
			}
		}

		public void RollForward()
		{
			if (_historyForwardStack.Any())
			{
				_historyForwardStack.TryPop(out IRevertable revert);
				var undoRevert = revert.Revert();
				_historyBackStack.Push(undoRevert);
			}
		}

		public void RollBackAll()
		{
			for (int i = 0; _historyBackStack.Count > 0; i++)
			{
				_historyBackStack.TryPop(out IRevertable revert);
				var undoRevert = revert.Revert();
				_historyForwardStack.Push(undoRevert);
			}
		}

		public void RollForwardAll()
		{
			for (int i = 0; _historyForwardStack.Count > 0; i++)
			{
				_historyForwardStack.TryPop(out IRevertable revert);
				var undoRevert = revert.Revert();
				_historyBackStack.Push(undoRevert);
			}
		}

		public IRevertable Revert()
		{
			var revertHistory = new HistoryFrame();

			for (int i = 0; _historyBackStack.Count > 0; i++)
			{
				_historyBackStack.TryPop(out IRevertable revert);
				var undoRevert = revert.Revert();
				revertHistory._historyBackStack.Push(undoRevert);
			}

			return revertHistory;
		}
	}
}
