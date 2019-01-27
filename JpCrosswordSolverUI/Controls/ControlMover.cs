using System.Drawing;
using System.Windows.Forms;

namespace JpCrosswordSolverUI.Controls
{
	class ControlMover
	{
		private readonly Control _control;
		private Point? _capturedLocation;
		public bool Active => _capturedLocation.HasValue;

		public ControlMover(Control control)
		{
			_control = control;
		}

		public void Begin(Point location)
		{
			_capturedLocation = location;
		}

		public void Move(Point newLocation)
		{
			var loc = _capturedLocation.Value;
			var deltaX = loc.X - newLocation.X;
			var deltaY = loc.Y - newLocation.Y;
			var newX = _control.Location.X - deltaX;
			var newY = _control.Location.Y - deltaY;
			newX = newX > 0 ? 0 : newX;
			newY = newY > 0 ? 0 : newY;

			if (_control.Width > _control.Parent.Width)
			{
				if (newX < _control.Parent.Width - _control.Width)
					newX = _control.Parent.Width - _control.Width;
			}
			else
			{
				newX = 0;
			}

			if (_control.Height > _control.Parent.Height)
			{
				if (newY < _control.Parent.Height - _control.Height)
					newY = _control.Parent.Height - _control.Height;
			}
			else
			{
				newY = 0;
			}

			_control.Location = new Point(newX, newY);
		}

		public void End()
		{
			_capturedLocation = null;
		}
	}
}
