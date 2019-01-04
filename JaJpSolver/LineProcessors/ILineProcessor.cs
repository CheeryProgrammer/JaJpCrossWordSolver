using System.Collections.Generic;
using JaJpSolver.Common;

namespace JaJpSolver.LineProcessors
{
	interface ILineProcessor
	{
		void Process(Point[] points, Group[] groups);
	}
}
