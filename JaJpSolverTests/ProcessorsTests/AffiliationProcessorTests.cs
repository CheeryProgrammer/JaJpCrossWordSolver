using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JaJpSolver;
using JaJpSolver.Common;
using JaJpSolver.LineProcessors;
using NUnit.Framework;

namespace JaJpSolverTests.ProcessorsTests
{
	[TestFixture]
	public class AffiliationProcessorTests
	{
		[Test]
		[TestCaseSource(typeof(DataSource), nameof(DataSource.TestCases))]
		public string AffiliationProcessorTest(string groups, IEnumerable<Point> points)
		{
			var isHorizontal = false;
			var processor = new AffiliationProcessor(isHorizontal);
			var line = new CrossWordLine(TestHelper.ParseGroups(groups).ToArray(), points.ToArray(), isHorizontal, new[] { processor });
			line.TrySolveStep(null);
			line.TrySolveStep(null);
			return points.RenderToString();
		}
	}


	public class DataSource
	{
		public static Point[] PointsData_10 = Enumerable.Range(0, 10).Select(n => new Point(0, n)).ToArray();

		public static IEnumerable TestCases
		{
			get
			{
				yield return new TestCaseData("5,1", PointsData_10)
					.Returns("..0XXXX0.X");
			}
		}

		static DataSource()
		{
			PointsData_10 = ParsePoints("00000XX00X");

		}

		private static Point[] ParsePoints(string input)
		{
			int y = 0;
			return input.Select(c =>
			{
				var p = new Point(0, y++);

				switch (c)
				{
					case 'X':
						p.SetFilled();
						break;
					case '.':
						p.SetEmpty();
						break;
					default:
						break;
				}
				return p;
			}).ToArray();
		}
	}
}
