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

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JaJpSolver.Task
{
	public class CrossWordTaskLoader
	{
		public bool TryLoadFromFile(string path, out CrossWordTask task)
		{
			task = null;

			if (!File.Exists(path))
				return false;

			var lines = File.ReadAllLines(path);
			if (lines == null || lines.Length < 3)
				return false;

			return TryParseTasks(lines, out task);
		}

		private bool TryParseTasks(string[] lines, out CrossWordTask task)
		{
			task = null;

			List<CrossWordLineTask> colsLineTasks = new List<CrossWordLineTask>();
			List<CrossWordLineTask> rowsLineTasks = new List<CrossWordLineTask>();

			bool isColsTask = true;

			for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
			{
				var line = lines[lineIndex];
				if (line == "-")
				{
					isColsTask = false;
					continue;
				}

				var numbers = line.Split(',').Select(num => { return int.TryParse(num, out int intNum) ? (int?)intNum : null; })
					.ToList();

				if (isColsTask)
				{
					while(colsLineTasks.Count < numbers.Count)
						colsLineTasks.Add(new CrossWordLineTask());

					for (int i = 0; i < colsLineTasks.Count; i++)
					{
						colsLineTasks[i].Add(numbers[i]);
					}
				}
				else
				{
					rowsLineTasks.Add(new CrossWordLineTask(numbers));
				}
			}

			task = new CrossWordTask(colsLineTasks, rowsLineTasks);

			return true;
		}
	}
}
