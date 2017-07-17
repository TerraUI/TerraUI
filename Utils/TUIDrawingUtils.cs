using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace TerraUI.Utils {
    public class DrawingUtils {
        public static void DrawRectangleBox(SpriteBatch spriteBatch, Color borderColour, Color backColour, Rectangle rect,
            int borderWidth) {
            Texture2D texture = Main.magicPixel;

            spriteBatch.Draw(texture, new Rectangle(rect.X + borderWidth, rect.Y + borderWidth, rect.Width - (borderWidth * 2), rect.Height - (borderWidth * 2)), backColour);
            spriteBatch.Draw(texture, new Rectangle(rect.X, rect.Y, rect.Width, borderWidth), new Rectangle(0, 0, 0, 0), borderColour);
            spriteBatch.Draw(texture, new Rectangle(rect.X, rect.Y, borderWidth, rect.Height), new Rectangle(0, 0, 0, 0), borderColour);
            spriteBatch.Draw(texture, new Rectangle(rect.X, rect.Y + rect.Height - borderWidth, rect.Width, borderWidth), new Rectangle(0, 0, 0, 0), borderColour);
            spriteBatch.Draw(texture, new Rectangle(rect.X + rect.Width - borderWidth, rect.Y, borderWidth, rect.Height), new Rectangle(0, 0, 0, 0), borderColour);
        }
    }
}
