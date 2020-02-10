using JaJpSolver.Task;
using System.Collections.Generic;
using System.Drawing;

namespace JaJpSolver.ImageTaskParser
{
	class TaskParser
	{
		public static CrossWordTask ParseFromBitmap(Bitmap bitmap)
		{
			var cols = ParseColumnsTasks(bitmap);
			var rows = ParseRowsTasks(bitmap);
			return new CrossWordTask(cols, rows);
		}

		private static CrossWordLineTask[] ParseColumnsTasks(Bitmap bitmap)
		{
			var colTasks = new List<CrossWordLineTask>();
			for (int w = 0; w < bitmap.Width; w++)
			{
				var colTask = new CrossWordLineTask();

				int group = 0;
				for (int h = 0; h < bitmap.Height; h++)
				{
					var filled = bitmap.GetPixel(w, h).GetBrightness() <= 0.5;
					if (filled)
					{
						group++;
					}
					else
					{
						if(group > 0)
						{
							colTask.Add(group);
							group = 0;
						}
					}
				}
				
				if (group > 0)
					colTask.Add(group);
				
				colTasks.Add(colTask);
			}
			return colTasks.ToArray();
		}

		private static CrossWordLineTask[] ParseRowsTasks(Bitmap bitmap)
		{
			var rowTasks = new List<CrossWordLineTask>();
			for (int h = 0; h < bitmap.Height; h++)
			{
				var colTask = new CrossWordLineTask();

				int group = 0;
				for (int w = 0; w < bitmap.Width; w++)
				{
					var filled = bitmap.GetPixel(w, h).GetBrightness() <= 0.5;
					if (filled)
					{
						group++;
					}
					else
					{
						if (group > 0)
						{
							colTask.Add(group);
							group = 0;
						}
					}
				}

				if (group > 0)
					colTask.Add(group);

				rowTasks.Add(colTask);
			}
			return rowTasks.ToArray();
		}
	}
}
