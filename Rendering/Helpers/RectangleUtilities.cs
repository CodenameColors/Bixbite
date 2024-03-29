﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BixBite.Rendering.Helpers
{
	static partial class Utilities
		{
			public static void CreateBorder(this Texture2D texture, int borderWidth, Color borderColor)
			{
				Color[] colors = new Color[texture.Width * texture.Height];

				for (int x = 0; x < texture.Width; x++)
				{
					for (int y = 0; y < texture.Height; y++)
					{
						bool colored = false;
						for (int i = 0; i <= borderWidth; i++)
						{
							if (x == i || y == i || x == texture.Width - 1 - i || y == texture.Height - 1 - i)
							{
								colors[x + y * texture.Width] = borderColor;
								colored = true;
								break;
							}
						}

						if (colored == false)
							colors[x + y * texture.Width] = Color.Transparent;
					}
				}

				texture.SetData(colors);
			}

			public static void CreateFilledRectangle(this Texture2D texture, int borderWidth, Color color)
			{
				Color[] colors = new Color[texture.Width * texture.Height];
				for (int x = 0 + borderWidth + 1; x < texture.Width - borderWidth - borderWidth - 1; x++)
				{
					for (int y = 0 + borderWidth + 1; y < texture.Height - borderWidth - 1; y++)
					{
						colors[x + y * texture.Width] = color;
					}
				}

				texture.SetData(colors);
			}

		}
}
