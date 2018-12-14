namespace JaJpSolver.Common
{
	public class Point
	{
		public int X { get; set; }
		public int Y { get; set; }
		public CellType PointType { get; set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
			PointType = CellType.Empty;
		}
	}
}
