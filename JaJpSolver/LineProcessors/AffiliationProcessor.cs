using System;
using System.Linq;
using JaJpSolver.Common;
using JaJpSolver.Extensions;

namespace JaJpSolver.LineProcessors
{

	public class AffiliationProcessor: LineProcessorBase
	{
		private readonly bool _isHorizontal;

		public AffiliationProcessor(bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
		}

		protected override bool TryProcessInternal(Point[] points, Group[] groups)
		{
			for (int i = 0; i < points.Length; i++)
			{
				var p = points[i];
				var singlePossible = p.HasSinglePossibleGroup(_isHorizontal);
				if (p.IsFilled() && singlePossible.Exists)
				{
					if (!p.IsGroupDetermined(_isHorizontal))
					{
						p.SetGroup(singlePossible.Group, _isHorizontal);
					}

					ExcludeFromImpossiblePoints(points, singlePossible.Group, i);

					// remove left groups to right and vice versa
					var left = points.Take(i).ToArray();
					var right = points.Skip(i + 1).ToArray();
					var currentGroupIndex = groups.ToList().IndexOf(singlePossible.Group);
					ExcludeGroups(left, 0, left.Length, groups.Skip(currentGroupIndex + 1).ToArray(), _isHorizontal);
					ExcludeGroups(right, 0, right.Length, groups.Take(currentGroupIndex).ToArray(), _isHorizontal);

					// for the same group remove other groups from list of possible.
					if (p.IsGroupDetermined(_isHorizontal))
					{
						for (int pIndex = i + 1; pIndex < points.Length; pIndex++)
						{
							var coPoint = points[pIndex];
							if (coPoint.IsFilled())
								coPoint.SetGroup(singlePossible.Group, _isHorizontal);
							else
								break;
						}

						for (int pIndex = i - 1; pIndex >= 0; pIndex--)
						{
							var coPoint = points[pIndex];
							if (coPoint.IsFilled())
								coPoint.SetGroup(singlePossible.Group, _isHorizontal);
							else
								break;
						}
					}
				}
			}

			return TryProcessLongest(points, groups);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="groups"></param>
		private bool TryProcessLongest(Point[] points, Group[] groups)
		{
			var maxLength = groups.Max(g => g.Length);
			var sequences = points.GetFilledSequences().Where(seq => seq.Count == maxLength);
			foreach (var sequence in sequences)
			{
				var beforeIndex = points.ToList().IndexOf(sequence.First()) - 1;
				if (beforeIndex >= 0)
				{
					if (!TrySetState(points[beforeIndex], CellType.Empty))
						return false;
				}

				var afterIndex = points.ToList().IndexOf(sequence.Last()) + 1;
				if (afterIndex < points.Length)
				{
					if (!TrySetState(points[afterIndex], CellType.Empty))
						return false;
				}
			}
			return true;
		}

		private void ExcludeFromImpossiblePoints(Point[] points, Group g, int index)
		{
			for (int i = 0; i < points.Length; i++)
			{
				if (Math.Abs(index - i) >= g.Length)
					ExcludeGroup(points[i], g, _isHorizontal);
			}
		}
	}
}


// 000XXXX00X
// 0123456789