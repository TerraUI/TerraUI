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
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public Texture2D BackTexture { get; set; }
        public Action Action { get; set; }

        public byte BorderWidth { get; set; }

        public Color BackColor { get; set; }
        public Color HoverBackColor { get; set; }
        public Color ClickBackColor { get; set; }

        public Color BorderColor { get; set; }
        public Color HoverBorderColor { get; set; }
        public Color ClickBorderColor { get; set; }

        public Color TextColor { get; set; }
        public Color HoverTextColor { get; set; }
        public Color ClickTextColor { get; set; }

        public UIButton(Vector2 position, Vector2 size, Action action, SpriteFont font, string text = "",
            byte borderWidth = 1, Texture2D backTexture = null, UIObject parent = null) : base(position, size, parent, false) {
            Action = action;
            Font = font;
            Text = text;
            BackTexture = backTexture;
            BorderWidth = borderWidth;

            BackColor = new Color(63, 65, 151, 255);
            HoverBackColor = new Color(100, 102, 190, 255);
            ClickBackColor = new Color(100, 102, 190, 255);

            BorderColor = Color.White;
            HoverBorderColor = Color.White;
            ClickBorderColor = Color.White;

            TextColor = Color.White;
            HoverTextColor = Color.White;
            ClickTextColor = Color.White;
        }

        protected override void DefaultLeftClick() {
            Action();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            Vector2 position = Position;

            if(Parent != null) {
                Position += Parent.Position;
            }

            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

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
