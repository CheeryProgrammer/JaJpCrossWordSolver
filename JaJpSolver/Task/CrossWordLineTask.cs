﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JaJpSolver.Task
{
	public class CrossWordLineTask : IEnumerable<int>
	{
		private List<int> _groups;

		public int Length => _groups.Count;

		public int this[int index]
		{
			get { return _groups[index]; }
		}

		public CrossWordLineTask()
		{
			_groups = new List<int>();
		}
		public CrossWordLineTask(IEnumerable<int?> groupsOfCells)
		{
			_groups = groupsOfCells.SkipWhile(g => !g.HasValue)
				.Select(g =>
				{
					if (g.HasValue)
						return g.Value;

					throw new InvalidOperationException("Missed one of values in sequence");
				})
				.ToList();
		}

		public void Add(int? group)
		{
			if (group.HasValue)
				_groups.Add(group.Value);
		}

		public IEnumerator<int> GetEnumerator()
		{
			return _groups.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_groups).GetEnumerator();
		}
	}
}
