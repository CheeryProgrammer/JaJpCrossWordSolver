using JaJpSolver.Common;
using System.Collections.Generic;

namespace JaJpSolver
{
	public class Group
	{
		private readonly int _length;

		public Group(int length)
		{
			_length = length;
		}

		public int Length => _length;
	}
}