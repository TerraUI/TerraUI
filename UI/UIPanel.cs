using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TerraUI {
    public class UIPanel : UIObject {
        /// <summary>
        /// Background color of the panel.
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// Background color when the mouse cursor is over the panel.
        /// </summary>
        public Color HoverBackColor { get; set; }
        /// <summary>
        /// Background color when the panel is clicked.
        /// </summary>
        public Color ClickBackColor { get; set; }
        /// <summary>
        /// Background texture of the panel.
        /// </summary>
        public Texture2D BackTexture { get; set; }
        /// <summary>
        /// Whether to draw as a Terraria-styled box.
        /// </summary>
        public bool DrawStyledBox { get; set; }
        /// <summary>
        /// Border color of the UIPanel if DrawStyledBox is false.
        /// </summary>
        public Color BorderColor { get; set; }
        /// <summary>
        /// Border color if the mouse cursor is over the panel and DrawStyledBox is false.
        /// </summary>
        public Color HoverBorderColor { get; set; }
        /// <summary>
        /// Border color if the panel is clicked and DrawStyledBox is false.
        /// </summary>
        public Color ClickBorderColor { get; set; }
        /// <summary>
        /// The border width if DrawStyledBox is false.
        /// </summary>
        public byte BorderWidth { get; set; }

        /// <summary>
        /// Create a new UIPanel.
        /// </summary>
        /// <param name="position">position of object in pixels</param>
        /// <param name="size">size of object in pixels</param>
        /// <param name="drawStyledBox">whether to draw as Terraria-styled box</param>
        /// <param name="backColor">background color of panel</param>
        /// <param name="backTexture">background texture of panel</param>
        /// <param name="parent">parent UIObject</param>
        public UIPanel(Vector2 position, Vector2 size, bool drawStyledBox = true, Texture2D backTexture = null, UIObject parent = null) : base(position, size, parent, false) {
            BackTexture = backTexture;
            DrawStyledBox = drawStyledBox;

            BackColor = UIColors.BackColorTransparent;
            HoverBackColor = ClickBackColor = UIColors.LightBackColorTransparent;
            BorderColor = HoverBorderColor = ClickBorderColor = UIColors.Panel.BorderColor;
            BorderWidth = 1;
        }

        /// <summary>
        /// Draw the UIPanel.
        /// </summary>
        /// <param name="spriteBatch">drawing SpriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch) {
            Vector2 position = Position;

            if(Parent != null) {
                position += Parent.Position;
            }

            Rectangle = new Rectangle((int)position.X, (int)position.Y, (int)Size.X, (int)Size.Y);

            Color backColor = BackColor;
            Color borderColor = BorderColor;

            if(MouseUtils.Rectangle.Intersects(Rectangle)) {
                if(MouseUtils.State.LeftButton == ButtonState.Pressed) {
                    backColor = ClickBackColor;
                    borderColor = ClickBorderColor;
                }
                else {
                    backColor = HoverBackColor;
                    borderColor = HoverBorderColor;
                }
            }

            if(BackTexture != null) {
                spriteBatch.Draw(BackTexture, Rectangle, Color.White);
            }
            else {
                if(DrawStyledBox) {
                    BaseTextureDrawing.DrawTerrariaStyledBox(spriteBatch, backColor, Rectangle);
                }
                else {
                    BaseTextureDrawing.DrawRectangleBox(spriteBatch, borderColor, backColor, Rectangle, BorderWidth);
                }
            }

            base.Draw(spriteBatch);
        }
    }
}
