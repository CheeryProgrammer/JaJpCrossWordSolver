using JaJpSolver;
using JaJpSolver.Task;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace JpCrosswordSolverUI
{
	public partial class MainForm : Form
	{
		private CrossWordSolver _solver;
		private FieldRenderer _fieldRenderer;

		public MainForm()
		{
			InitializeComponent();
			_fieldRenderer = new FieldRenderer(pbCrossWord);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			_fieldRenderer?.Dispose();
			base.OnClosing(e);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openDialog = new OpenFileDialog())
			{
				openDialog.CheckPathExists = true;
				openDialog.Filter = "Text file|*.txt";
				openDialog.Multiselect = false;
				if(openDialog.ShowDialog() == DialogResult.OK)
				{
					var file = openDialog.FileName;
					var task = ParseTask(file);
					_solver = new CrossWordSolver(task);
					_fieldRenderer.InitBoard(_solver.Board);
				}
			}
		}

		private CrossWordTask ParseTask(string file)
		{
			var taskLoader = new CrossWordTaskLoader();
			taskLoader.TryLoadFromFile(file, out CrossWordTask task);
			return task;
		}

		private void btnSolveStep_Click(object sender, EventArgs e)
		{
			_solver.SolveStep();
			_fieldRenderer.DrawBoard(_solver.Board);
		}
	}
}
