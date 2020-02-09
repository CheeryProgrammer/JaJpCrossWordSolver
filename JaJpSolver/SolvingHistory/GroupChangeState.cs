using JaJpSolver.Common;
using System.Linq;

namespace JaJpSolver.SolvingHistory
{
	public class GroupChangeState: IRevertable
	{
		private Point target;
		private Group[] groups;
		private bool areHorizontal;
		private readonly bool isExcluding;

		public GroupChangeState(Point target, Group[] groups, bool areHorizontal, bool isExcluding)
		{
			this.target = target;
			this.groups = groups;
			this.areHorizontal = areHorizontal;
			this.isExcluding = isExcluding;
		}

		public IRevertable Revert()
		{
			if (isExcluding)
			{
				var targetGroups = areHorizontal ? target.PossibleHorizontalGroups : target.PossibleVerticalGroups;
				targetGroups.AddRange(groups);
			}
			else
			{
				target.ExcludeGroups(groups, areHorizontal);
			}

			return new GroupChangeState(target, groups, areHorizontal, !isExcluding);
		}
	}
}
