using System;
using System.Collections.Generic;
using System.Linq;
using JaJpSolver.Common;

namespace JaJpSolver.LineProcessors
{
	class FillProcessor : ILineProcessor
	{
		private readonly bool _isHorizontal;

		public FillProcessor(bool isHorizontal)
		{
			_isHorizontal = isHorizontal;
		}

		public void Process(Point[] points, Group[] groups)
		{
			for (int i = 0; i < groups.Length; i++)
			{
				ExcludeImpossibleLocations(points, groups[i], out int possibleLocationsCount);
				if (possibleLocationsCount == 1)
					FillFirstPossibleCells(points, groups[i]);
			}
		}

		private void ExcludeImpossibleLocations(Point[] points, Group g, out int count)
		{
			count = 0;
			bool inGroup = false;
			int freeSpace = 0;
			for (int i = 0; i < points.Length; i++)
			{
				var p = points[i];
				if (p.BelongsTo(g, _isHorizontal))
				{
					if (!inGroup)
					{
						inGroup = true;
						freeSpace = 1;
						count++;
					}
					else
					{
						freeSpace++;
					}
				}
				else
				{
					if (inGroup)
					{
						inGroup = false;
						if (g.Length > freeSpace)
						{
							for (int j = i - freeSpace; j < i; j++)
							{
								points[j].ExcludeGroups(new[] { g }, _isHorizontal);
								count--;
							}
						}
					}
				}
			}
		}

		private void FillFirstPossibleCells(Point[] points, Group g)
		{
			int startIndex = -1;
			int stopIndex = -1;
			for (int i = 0; i < points.Length; i++)
			{
				var p = points[i];
				if (p.BelongsTo(g, _isHorizontal))
				{
					if (startIndex == -1)
						startIndex = i;

					stopIndex = i;
				}
				else
				{
					if (startIndex != -1)
						break;
				}
			}
			if (startIndex == -1 || stopIndex == -1)
				throw new InvalidOperationException("Points belonged to group are not found");

			var length = stopIndex + 1 - startIndex;
			for (int i = startIndex + length - g.Length; i <= stopIndex - length + g.Length; i++)
			{
				points[i].SetFilled();
			}

			if (length == g.Length)
			{
				if (startIndex > 0)
					points[startIndex - 1].SetEmpty();
				if (stopIndex < points.Length - 1)
					points[stopIndex + 1].SetEmpty();
			}
		}
	}
}
