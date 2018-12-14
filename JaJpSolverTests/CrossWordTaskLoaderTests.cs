using System.IO;
using JaJpSolver.Task;
using NUnit.Framework;

namespace JaJpSolverTests
{
	public class CrossWordTaskLoaderTests
	{
		private const string CROSSWORD_10_X_10_TASK_PATH = "TaskSample10x10.txt";

		[SetUp]
		public void Setup()
		{
			File.WriteAllText(CROSSWORD_10_X_10_TASK_PATH, TestData.Task_10_X_10);
		}

		[Test]
		public void ParseTaskTest()
		{
			var taskLoader = new CrossWordTaskLoader();
			CrossWordTask task;
			Assert.IsTrue(taskLoader.TryLoadFromFile(CROSSWORD_10_X_10_TASK_PATH, out task));
			Assert.AreEqual(task.ColumnsTasks.Length, 10);
			Assert.AreEqual(task.RowsTasks.Length, 10);
		}

		[TearDown]
		public void TearDown()
		{
			if (File.Exists(CROSSWORD_10_X_10_TASK_PATH))
				File.Delete(CROSSWORD_10_X_10_TASK_PATH);
		}
	}
}
