﻿using System.Drawing;

namespace JpCrosswordSolverUI.Controls
{
	class CoordinatesTranslator
	{
		private readonly bool _showHorizontalMainLines;
		private readonly bool _showVerticalMainLines;
		private readonly PuzzleGrid _puzzleGrid;

		public CoordinatesTranslator(PuzzleGrid puzzleGrid)
		{
			_puzzleGrid = puzzleGrid;
		}

		public CoordinatesTranslator(PuzzleGrid puzzleGrid, bool showHorizontalMainLines, bool showVerticalMainLines):this(puzzleGrid)
		{
			_showHorizontalMainLines = showHorizontalMainLines;
			_showVerticalMainLines = showVerticalMainLines;
		}


		public Rectangle GetCellRectangle(int x, int y)
		{
			var rowGroup = y / _puzzleGrid.GroupSize + 1;
			var colGroup = x / _puzzleGrid.GroupSize + 1;

			var cellX = (_puzzleGrid.CellSize + _puzzleGrid.LineThickness) * x - _puzzleGrid.LineThickness + 1;
			if (_showVerticalMainLines)
				cellX += (_puzzleGrid.GroupLineThickness - _puzzleGrid.LineThickness) * colGroup;

			var cellY = (_puzzleGrid.CellSize + _puzzleGrid.LineThickness) * y - _puzzleGrid.LineThickness + 1;
			if (_showHorizontalMainLines)
				cellY += (_puzzleGrid.GroupLineThickness - _puzzleGrid.LineThickness) * rowGroup;
			return new Rectangle(cellX+1, cellY+1, _puzzleGrid.CellSize, _puzzleGrid.CellSize);
		}

		public (int X, int Y) FindCell(int x, int y)
		{
			var gLen = _puzzleGrid.GroupLineThickness + _puzzleGrid.CellSize * _puzzleGrid.GroupSize + _puzzleGrid.LineThickness * (_puzzleGrid.GroupSize - 1);
			var groupX = x / gLen + 1;
			var cellX = (x + 1 - (_puzzleGrid.GroupLineThickness - _puzzleGrid.LineThickness) * groupX - _puzzleGrid.LineThickness) / (_puzzleGrid.CellSize + _puzzleGrid.LineThickness);
			var groupY = y / gLen + 1;
			var cellY = (y + 1 - (_puzzleGrid.GroupLineThickness - _puzzleGrid.LineThickness) * groupY - _puzzleGrid.LineThickness) / (_puzzleGrid.CellSize + _puzzleGrid.LineThickness);
			return (cellX + 1, cellY + 1);
		}
	}
}
