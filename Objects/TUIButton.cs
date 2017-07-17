using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using TerraUI.Utils;

namespace TerraUI.Objects {
    public class TUIButton : TUIBorderedElement {
        /// <summary>
        /// The font used for the text on the object.
        /// </summary>
        public DynamicSpriteFont Font { get; set; }
        /// <summary>
        /// The text displayed on the object.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The normal background color.
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// The normal text color.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="location">location of object</param>
        /// <param name="size">size of object</param>
        /// <param name="font">font used for text</param>
        /// <param name="text">text displayed on object</param>
        /// <param name="borderWidth">width of object border</param>
        public TUIButton(StylePoint location, StylePoint size, string text = "", byte borderWidth = 1)
            : this(location, size, Main.fontMouseText, text, borderWidth) { }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="location">location of object</param>
        /// <param name="size">size of object</param>
        /// <param name="font">font used for text</param>
        /// <param name="text">text displayed on object</param>
        /// <param name="borderWidth">width of object border</param>
        public TUIButton(StylePoint location, StylePoint size, DynamicSpriteFont font, string text = "", byte borderWidth = 1)
            : base(location, size, borderWidth) {
            Font = font;
            Text = text;
            BorderWidth = borderWidth;

            BackColor = TUIColors.Button.BackColor;
            TextColor = TUIColors.Button.TextColor;
        }

        /// <summary>
        /// Fires when the mouse enters the object.
        /// </summary>
        public override void MouseOver(UIMouseEvent evt) {
            base.MouseOver(evt);
            Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            CalculatedStyle dim = GetDimensions();
            Rectangle rect = dim.ToRectangle();

            TUIDrawUtils.DrawRectangleBox(spriteBatch, BorderColor, BackColor, rect, BorderWidth);

            if(!string.IsNullOrWhiteSpace(Text)) {
                Vector2 measure = Font.MeasureString(Text);
                Vector2 origin = new Vector2(measure.X / 2, measure.Y / 2);
                Vector2 textPos = new Vector2(dim.X, dim.Y);

                textPos.X += (dim.Width / 2);
                textPos.Y += (dim.Height / 2) + (measure.Y / 8);

                spriteBatch.DrawString(Font, Text, textPos, TextColor, 0f, origin, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
