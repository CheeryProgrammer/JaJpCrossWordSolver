using System;
using System.Linq;
using JaJpSolver.Common;
using JaJpSolver.Extensions;

namespace JaJpSolver.LineProcessors
{

	public class AffiliationProcessor: ILineProcessor
	{
		private readonly bool _isHorizontal;

		public AffiliationProcessor(bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
		}

		public void Process(Point[] points, Group[] groups)
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
					var left = points.Take(i);
					var right = points.Skip(i + 1);
					var currentGroupIndex = groups.ToList().IndexOf(singlePossible.Group);
					foreach (var point in left)
					{
						point.ExcludeGroups(groups.Skip(currentGroupIndex + 1).ToArray(), _isHorizontal);
					}
					foreach (var point in right)
					{
						point.ExcludeGroups(groups.Take(currentGroupIndex).ToArray(), _isHorizontal);
					}

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

			ProcessLongest(points, groups);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="groups"></param>
		private void ProcessLongest(Point[] points, Group[] groups)
		{
			var maxLength = groups.Max(g => g.Length);
			var sequences = points.GetFilledSequences().Where(seq => seq.Count == maxLength);
			foreach (var sequence in sequences)
			{
				var beforeIndex = points.ToList().IndexOf(sequence.First()) - 1;
				if (beforeIndex >= 0)
				{
					points[beforeIndex].SetEmpty();
				}

				var afterIndex = points.ToList().IndexOf(sequence.Last()) + 1;
				if (afterIndex < points.Length)
				{
					points[afterIndex].SetEmpty();
				}
			}
		}

		private void ExcludeFromImpossiblePoints(Point[] points, Group g, int index)
		{
			for (int i = 0; i < points.Length; i++)
			{
				if (Math.Abs(index - i) >= g.Length)
				{
					points[i].ExcludeGroups(new[] {g}, _isHorizontal);
				}
			}
		}
	}
}


// 000XXXX00X
// 0123456789