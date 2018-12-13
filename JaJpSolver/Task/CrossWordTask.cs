/// Task is numbers. Example of valid file 10x10:
///		,,1,,,,,,,
///		,3,4,,4,3,,,,
///		2,2,1,10,1,2,5,3,1,2
///		-
///		1
///		3
///		2,1
///		5
///		4
///		6
///		7
///		3,2,1
///		1,3,1
///		5,1

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaJpSolver.Task
{
	public class CrossWordTask
	{
		private int _width;
		private int _height;

		public bool TryLoadFromFile(string path)
		{
			if (!File.Exists(path))
				return false;

			var lines = File.ReadAllLines(path);
			if (lines == null || lines.Length < 3)
				return false;

			return TryParseTasks(lines);
		}

		private bool TryParseTasks(string[] lines)
		{
			throw new NotImplementedException();
		}
	}
}
