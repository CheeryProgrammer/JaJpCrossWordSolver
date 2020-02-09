using JaJpSolver.Common;

namespace JaJpSolver.SolvingHistory
{
	class CellChangeState: IRevertable
	{
		private Point target;
		private CellType from;
		private CellType to;

		public CellChangeState(Point target, CellType from, CellType to)
		{
			this.target = target;
			this.from = from;
			this.to = to;
		}

		public IRevertable Revert()
		{
			switch (from)
			{
				case CellType.None:
					target.SetNone();
					break;
				case CellType.Empty:
					target.SetEmpty();
					break;
				case CellType.Filled:
					target.SetFilled();
					break;
			}
			return new CellChangeState(target, to, from);
		}

		public override string ToString()
		{
			return $"({target.X};{target.X})({from} -> {to})";
		}
	}
}
