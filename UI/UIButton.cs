using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Microsoft.Xna.Framework.Input;

namespace TerraUI {
    public class UIButton : UIObject {
        /// <summary>
        /// The font used for the text on the button.
        /// </summary>
        public SpriteFont Font { get; set; }
        /// <summary>
        /// The text displayed on the button.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The texture used for the back of the button. If null, the BackColor value will be used.
        /// </summary>
        public Texture2D BackTexture { get; set; }
        /// <summary>
        /// The width of the button's border.
        /// </summary>
        public byte BorderWidth { get; set; }
        /// <summary>
        /// The normal background color.
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// The background color when the mouse cursor is over the button.
        /// </summary>
        public Color HoverBackColor { get; set; }
        /// <summary>
        /// The background color when the button is clicked.
        /// </summary>
        public Color ClickBackColor { get; set; }
        /// <summary>
        /// The normal border color.
        /// </summary>
        public Color BorderColor { get; set; }
        /// <summary>
        /// The border color when the mouse cursor is over the button.
        /// </summary>
        public Color HoverBorderColor { get; set; }
        /// <summary>
        /// The border color when the button is clicked.
        /// </summary>
        public Color ClickBorderColor { get; set; }
        /// <summary>
        /// The normal text color.
        /// </summary>
        public Color TextColor { get; set; }
        /// <summary>
        /// The text color when the mouse cursor is over the button.
        /// </summary>
        public Color HoverTextColor { get; set; }
        /// <summary>
        /// The text color when the button is clicked.
        /// </summary>
        public Color ClickTextColor { get; set; }

        /// <summary>
        /// Create a new UIButton.
        /// </summary>
        /// <param name="position">position of button in pixels</param>
        /// <param name="size">size of button in pixels</param>
        /// <param name="font">font used for button text</param>
        /// <param name="text">text displayed on button</param>
        /// <param name="borderWidth">width of button border</param>
        /// <param name="backTexture">texture used to draw back of button</param>
        /// <param name="parent">parent UIObject</param>
        public UIButton(Vector2 position, Vector2 size, SpriteFont font, string text = "", byte borderWidth = 1,
            Texture2D backTexture = null, UIObject parent = null) : base(position, size, parent, false) {
            Font = font;
            Text = text;
            BackTexture = backTexture;
            BorderWidth = borderWidth;

            BackColor = UIColors.DarkBackColorTransparent;
            HoverBackColor = ClickBackColor = UIColors.LightBackColorTransparent;
            BorderColor = HoverBorderColor = ClickBorderColor = UIColors.Button.BorderColor;
            TextColor = HoverTextColor = ClickTextColor = UIColors.Button.TextColor;
        }

        /// <summary>
        /// Draw the UIButton.
        /// </summary>
        /// <param name="spriteBatch">drawing SpriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch) {
            Rectangle = new Rectangle((int)RelativePosition.X, (int)RelativePosition.Y, (int)Size.X, (int)Size.Y);

            Color borderColor = BorderColor;
            Color backColor = BackColor;
            Color textColor = TextColor;

            if(MouseUtils.Rectangle.Intersects(Rectangle)) {
                if(MouseUtils.State.LeftButton == ButtonState.Pressed) {
                    borderColor = ClickBorderColor;
                    backColor = ClickBackColor;
                    textColor = ClickTextColor;
                }
                else {
                    borderColor = HoverBorderColor;
                    backColor = HoverBackColor;
                    textColor = HoverTextColor;
                }
            }
            else {
                borderColor = BorderColor;
                backColor = BackColor;
                textColor = TextColor;
            }

            if(BackTexture == null) {
                BaseTextureDrawing.DrawRectangleBox(spriteBatch, borderColor, backColor, Rectangle, BorderWidth);
            }
            else {
                spriteBatch.Draw(BackTexture, Rectangle, Color.White);
            }

            if(!string.IsNullOrWhiteSpace(Text)) {
                Vector2 measure = Font.MeasureString(Text);
                Vector2 origin = new Vector2(measure.X / 2, measure.Y / 2);
                Vector2 textPos = new Vector2(Rectangle.X, Rectangle.Y);

                textPos.X += (Rectangle.Width / 2);
                textPos.Y += (Rectangle.Height / 2) + (measure.Y / 8);

                spriteBatch.DrawString(Font, Text, textPos, textColor, 0f, origin, 1f, SpriteEffects.None, 0f);
            }

            base.Draw(spriteBatch);
        }
    }
}
