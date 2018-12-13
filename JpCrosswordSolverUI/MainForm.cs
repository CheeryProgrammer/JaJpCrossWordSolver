using JaJpSolver;
using JaJpSolver.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JpCrosswordSolverUI
{
	public partial class MainForm : Form
	{
		private Board _board;
		private Graphics _boardGraphics;
		private CellType[,] _cells;

		private Pen _gridPen = Pens.Black;


		private int _width = 100;
		private int _height = 50;
		private int _cellSize = 30;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_board = new Board(_width, _height);
			DrawBoard(_board);
			var image = new Bitmap(_width * _cellSize + 1, _height *_cellSize + 1);
			_boardGraphics = Graphics.FromImage(image);
			_boardGraphics.Clear(Color.LightYellow);
			DrawGridLines(_boardGraphics, _width, _height, _cellSize);

			pbCrossWord.Width = image.Width;
			pbCrossWord.Height = image.Height;
			pbCrossWord.Image = image;
		}

		private void DrawGridLines(Graphics boardGraphics, int boardWidth, int boardHeight, int cellSize)
		{
			for (int i = 0; i <= boardWidth; i++)
			{
				boardGraphics.DrawLine(_gridPen, i * cellSize, 0, i * cellSize, boardHeight * cellSize);
			}
			for (int i = 0; i <= boardHeight; i++)
			{
				boardGraphics.DrawLine(_gridPen, 0, i * cellSize, boardWidth * cellSize, i * cellSize);
			}
		}

		private void DrawBoard(Board board)
		{
			for (int x = 0; x < board.Points.GetLength(0); x++)
			{
				for (int y = 0; y < board.Points.GetLength(1); y++)
				{

				}
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			_boardGraphics?.Dispose();
			base.OnClosing(e);
		}
	}
}
