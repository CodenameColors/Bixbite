﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixBite
{
	//adding a this to the parameters of the method will EXTEND that class and AUTO add this function to it methods.
	public static class TileCollisionChecker
	{
		public static bool TouchTopOf(this Rectangle r1, Rectangle r2)
		{
			return (r1.Bottom >= r2.Top - 1 &&
				r1.Bottom <= r2.Top + (r2.Height / 2) &&
				r1.Right >= r2.Left + r2.Width / 5 &&
				r1.Left <= r2.Right - r2.Width / 5);
		}

		public static bool TouchBottomOf(this Rectangle r1, Rectangle r2)
		{
			return (r1.Top <= r2.Bottom + (r2.Height / 5) &&
				r1.Top >= r2.Bottom - 1 &&
				r1.Right >= r2.Left + r2.Width / 5 &&
				r1.Right >= r2.Left + r2.Width / 5 &&
				r1.Left <= r2.Right - (r2.Width / 5));

		}

		public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
		{
			return (r1.Right <= r2.Right &&
				r1.Right >= r2.Left - 5 &&
				r1.Top <= r2.Bottom - (r2.Width / 4) &&
				r1.Bottom >= r2.Top + (r2.Width / 4));
		}

		public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
		{
			return (r1.Left >= r2.Left &&
				r1.Left <= r2.Right + 5 &&
				r1.Top <= r2.Bottom - (r2.Width / 4) &&
				r1.Bottom >= r2.Top + (r2.Width / 4));
		}


		public static Rectangle ScaleRectangle(this Rectangle r1, float scalarx, float scalary)
		{
			r1.Width = (int)(r1.Width * scalarx);
			r1.Height = (int)(r1.Height * scalary);

			return r1;
		}

		public static Rectangle AddRectanglePosition(this Rectangle r1, Rectangle r2)
		{
			r1.Location += r2.Location;
			return r1;
		}

		public static Rectangle AddRectanglePosition(this Rectangle r1, Vector2 v2)
		{
			r1.Location += v2.ToPoint();
			return r1;
		}


	}
}
