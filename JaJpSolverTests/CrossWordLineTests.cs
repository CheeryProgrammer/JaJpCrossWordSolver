using JaJpSolver;
using JaJpSolver.Common;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaJpSolverTests
{
	[TestFixture]
	public class CrossWordLineTests
	{
		[Test]
		public void CreateCrossWordLine_Test()
		{
			var groups = DataSourceCWLine.GroupsData;
			var points = DataSourceCWLine.PointsData_10;
			var cwLine = new CrossWordLine(groups, points, true);
			foreach(var point in points)
			{
				var possible = point.PossibleHorizontalGroups;
				for (int i = 0; i < possible.Count; i++)
				{
					var expected = groups.ElementAt(i);
					var actual = possible.ElementAt(i);
					Assert.AreEqual(expected, actual);
				}
			}
		}

		[Test]
		[TestCaseSource(typeof(DataSourceCWLine), "TestCases")]
		public string SolveStep_Test(string lineData, IEnumerable<Point> points)
		{
			var groups = TestHelper.ParseGroups(lineData);
			var cwLine = new CrossWordLine(groups, points, true);
			cwLine.SolveStep();
			return points.RenderToString();
		}
	}

	public class DataSourceCWLine
	{
		public static Point[] PointsData_10 = Enumerable.Range(0, 10).Select(n => new Point(0, n)).ToArray();
		public static Group[] GroupsData = Enumerable.Range(0, 5).Select(n => new Group(n)).ToArray();

		public static IEnumerable TestCases
		{
			get
			{
				yield return new TestCaseData("6", PointsData_10)
					.Returns("0000XX0000");
				yield return new TestCaseData("4,5", PointsData_10)
					.Returns("XXXX.XXXXX");
			}
		}
	}
}
