﻿using JaJpSolver;
using JaJpSolver.Task;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JaJpSolver.Common;
using JpCrosswordSolverUI.Controls;
using JpCrosswordSolverUI.Properties;
using Point = System.Drawing.Point;
using System.Drawing;
using System.IO;

namespace JpCrosswordSolverUI
{
	public partial class MainForm : Form
	{
		private CrossWordSolver _solver;
		private BoardRenderer _fieldRenderer;
		private PuzzleGrid _colsTaskGrid;
		private PuzzleGrid _rowsTaskGrid;
		private PuzzleGrid _pictureGrid;
		private Panel PicturePanel => splitContainerRight.Panel2;
		private Panel ColsPanel => splitContainerRight.Panel1;
		private Panel RowsPanel => splitContainerLeft.Panel2;

		public MainForm()
		{
			InitializeComponent();

			RowsPanel.AutoSize = true;
			ColsPanel.AutoSize = true;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openDialog = new OpenFileDialog())
			{
				openDialog.CheckPathExists = true;
				openDialog.Filter = "Text file|*.txt|Image|*.png|Image|*.bmp";
				openDialog.Multiselect = false;
				if(openDialog.ShowDialog() == DialogResult.OK)
				{
					var file = openDialog.FileName;
					var task = ParseTask(file);
					DisplayTask(task);

					_solver = new CrossWordSolver(task);

					InitPictureGrid(task);
					_fieldRenderer = new BoardRenderer(_pictureGrid);
					_fieldRenderer.UpdateBoard(_solver.Board);

					splitContainerRight.SplitterDistance = ColsPanel.Height;
					splitContainerCommon.SplitterDistance = RowsPanel.Width;
				}
			}
		}

		private void InitPictureGrid(CrossWordTask task)
		{
			_pictureGrid = new PuzzleGrid(task.ColumnsTasks.Length, task.RowsTasks.Length);
			_pictureGrid.MovingEnabled = true;
			PicturePanel.Controls.Clear();
			PicturePanel.Controls.Add(_pictureGrid);
			_pictureGrid.Moved += PictureMoved;
			_pictureGrid.Scaled += PictureScaled;
			_pictureGrid.HoveredPointChanged += PictureGrid_HoveredPointChanged;
			_pictureGrid.CellChanged += PictureGrid_CellChanged;
		}

		private void PictureGrid_CellChanged(int x, int y, CellType newCellType)
		{
			_solver.SetManually(x, y, newCellType);
			_fieldRenderer.UpdateBoard(_solver.Board);
		}

		private void PictureGrid_HoveredPointChanged(int x, int y)
		{
			tbCoordinates.Clear();
			tbHorizontalAffiliation.Clear();
			tbVerticalAffiliation.Clear();
			tbHorizontalGroups.Clear();
			tbVerticalGroups.Clear();
			tbCoordinates.Text = $"X: {x}; Y: {y}";

			var p = _solver.Board.Points[x, y];

			tbHorizontalAffiliation.Text = p.IsGroupDetermined(true)
				? p.HorizontalGroup.Length.ToString()
				: "undefined";

			tbVerticalAffiliation.Text = p.IsGroupDetermined(false)
				? p.VerticalGroup.Length.ToString()
				: "undefined";

			tbHorizontalGroups.Text = string.Join(", ",
				p.PossibleHorizontalGroups.Select(g => g.Length));

			tbVerticalGroups.Text = string.Join(", ",
				p.PossibleVerticalGroups.Select(g => g.Length));
		}

		private void PictureMoved()
		{
			_colsTaskGrid.Location = new Point(_pictureGrid.Location.X, _colsTaskGrid.Location.Y);
			_rowsTaskGrid.Location = new Point(_rowsTaskGrid.Location.X, _pictureGrid.Location.Y);
		}

		private void PictureScaled(float coeff)
		{
			_colsTaskGrid.ScaleByCoeff(coeff);
			_rowsTaskGrid.ScaleByCoeff(coeff);
			AdjustTaskGrid();
		}

		private void AdjustTaskGrid()
		{
			splitContainerRight.SplitterDistance = _colsTaskGrid.Height;
			splitContainerCommon.SplitterDistance = _rowsTaskGrid.Width;
		}

		private void DisplayTask(CrossWordTask task)
		{
			DisplayColsTask(task);
			DisplayRowsTask(task);
		}

		private void DisplayColsTask(CrossWordTask task)
		{
			var cols = task.ColumnsTasks;
			var gridWidth = cols.Length;
			var gridHeight = cols.Max(c => c.Length);
			_colsTaskGrid = new PuzzleGrid(gridWidth, gridHeight, showHorizontalMainLines:false);
			for (int x = 0; x < gridWidth; x++)
			{
				var emptyCount = gridHeight - cols[x].Length;
				for (int y = 0; y < cols[x].Length; y++)
				{
					_colsTaskGrid.GridCells[x, emptyCount + y] = cols[x][y];
				}
			}

			ColsPanel.Controls.Clear();
			ColsPanel.Controls.Add(_colsTaskGrid);
		}

		private void DisplayRowsTask(CrossWordTask task)
		{
			var rows = task.RowsTasks;
			var gridWidth = rows.Max(r => r.Length);
			var gridHeight = rows.Length;
			_rowsTaskGrid = new PuzzleGrid(gridWidth, gridHeight, showVerticalMainLines:false);
			for (int y = 0; y < gridHeight; y++)
			{
				var emptyCount = gridWidth - rows[y].Length;
				for (int x = 0; x < rows[y].Length; x++)
				{
					_rowsTaskGrid.GridCells[emptyCount + x, y] = rows[y][x];
				}
			}

			RowsPanel.Controls.Clear();
			RowsPanel.Controls.Add(_rowsTaskGrid);
		}

		private CrossWordTask ParseTask(string file)
		{
			var extension = Path.GetExtension(file);

			var taskLoader = new CrossWordTaskLoader();
			CrossWordTask task;
			if (extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase)
				|| extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
			{
				Bitmap bmp = (Bitmap)Bitmap.FromFile(file);
				task = CrossWordTaskLoader.ParseFromBitmap(bmp);
			}
			else
				taskLoader.TryLoadFromFile(file, out task);
			return task;
		}

		private async void BtnSolveStep_Click(object sender, EventArgs e)
		{
			while (!_solver?.Solved ?? false)
			{
				//var delayTask = Task.Delay(100);
				if (!_solver.SolveStep())
				{
					MessageBox.Show(this, "Autosolving is stopped.", "Error occured");
					break;
				}
				_fieldRenderer.UpdateBoard(_solver.Board);
				await  Task.Delay(100);
			}

			if (_solver?.Solved ?? false)
			{
				var points = _solver.Board.Points;
				Bitmap bitmap = new Bitmap(points.GetLength(0), points.GetLength(1));
				for (int x = 0; x < bitmap.Width; x++)
				{
					for (int y = 0; y < bitmap.Height; y++)
					{
						bitmap.SetPixel(x, y, points[x, y].IsFilled() ? Color.Black : Color.Transparent);
					}
				}
				MessageBox.Show(this, "Puzzle is solved!", "Finish");
				splitContainerLeft.Panel1.BackgroundImage = bitmap;
				splitContainerLeft.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
			}
		}

		private void SplitContainerRight_Panel1_Resize(object sender, EventArgs e)
		{
			splitContainerLeft.SplitterDistance = splitContainerRight.SplitterDistance;
		}

		private void cbNone_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender is CheckBox cb) cb.Image = Resources.NoneActive;
			cbFilled.Image = Resources.Filled;
			cbEmpty.Image = Resources.Empty;
			_pictureGrid.PaintMode = CellType.None;
		}

		private void cbFilled_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender is CheckBox cb) cb.Image = Resources.FilledActive;
			cbNone.Image = Resources.None;
			cbEmpty.Image = Resources.Empty;
			_pictureGrid.PaintMode = CellType.Filled;
		}

		private void cbEmpty_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender is CheckBox cb) cb.Image = Resources.EmptyActive;
			cbFilled.Image = Resources.Filled;
			cbNone.Image = Resources.None;
			_pictureGrid.PaintMode = CellType.Empty;
		}

		private void BtnReset_Click(object sender, EventArgs e)
		{
			_solver?.ResetAll();
			_fieldRenderer?.UpdateBoard(_solver.Board);
		}

		private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_solver?.StepBack();
			_fieldRenderer?.UpdateBoard(_solver.Board);
		}

		private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_solver?.StepForward();
			_fieldRenderer?.UpdateBoard(_solver.Board);
		}
	}
}
