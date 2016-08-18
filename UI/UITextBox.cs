using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Input = Microsoft.Xna.Framework.Input;

namespace TerraUI {
    public class UITextBox : UIObject {
        private const int frameDelay = 9;
        private int selectionStart = 0;
        private int leftArrow = 0;
        private int rightArrow = 0;
        private int delete = 0;

        /// <summary>
        /// The text displayed in the UITextBox.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The font used in the UITextBox.
        /// </summary>
        public SpriteFont Font { get; set; }
        /// <summary>
        /// The default border color.
        /// </summary>
        public Color BorderColor { get; set; }
        /// <summary>
        /// The focused border color.
        /// </summary>
        public Color FocusedBorderColor { get; set; }
        /// <summary>
        /// The default background color.
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// The focused background color.
        /// </summary>
        public Color FocusedBackColor { get; set; }
        /// <summary>
        /// The default text color.
        /// </summary>
        public Color TextColor { get; set; }
        /// <summary>
        /// The focused text color.
        /// </summary>
        public Color FocusedTextColor { get; set; }
        /// <summary>
        /// The index where the selection in the UITextBox begins.
        /// </summary>
        public int SelectionStart {
            get { return selectionStart; }
            private set {
                if(value < 0) {
                    selectionStart = 0;
                }
                else if(value > Text.Length) {
                    selectionStart = Text.Length;
                }
                else {
                    selectionStart = value;
                }
            }
        }

        /// <summary>
        /// Create a new UITextBox.
        /// </summary>
        /// <param name="position">position of object in pixels</param>
        /// <param name="size">size of object in pixels</param>
        /// <param name="font">text font</param>
        /// <param name="text">displayed text</param>
        /// <param name="parent">parent object</param>
        public UITextBox(Vector2 position, Vector2 size, SpriteFont font, string text = "", UIObject parent = null)
            : base(position, size, parent, true) {
            Text = text;
            Focused = false;
            Font = font;
            BorderColor = FocusedBorderColor = UIColors.TextBox.BorderColor;
            BackColor = FocusedBackColor = UIColors.TextBox.BackColor;
            TextColor = FocusedTextColor = UIColors.TextBox.TextColor;
        }

        /// <summary>
        /// Give the object focus.
        /// </summary>
        public override void Focus() {
            base.Focus();
            SelectionStart = Text.Length;
        }

        /// <summary>
        /// Update the object. Call during any Update() function.
        /// </summary>
        public override void Update() {
            if(Focused) {
                bool skip = false;

                if(Text.Length > 0) {
                    if(KeyboardUtils.JustPressed(Input.Keys.Left) || KeyboardUtils.HeldDown(Input.Keys.Left)) {
                        if(leftArrow == 0) {
                            SelectionStart--;
                            leftArrow = frameDelay;
                        }
                        leftArrow--;
                        skip = true;
                    }
                    else if(KeyboardUtils.JustPressed(Input.Keys.Right) || KeyboardUtils.HeldDown(Input.Keys.Right)) {
                        if(rightArrow == 0) {
                            SelectionStart++;
                            rightArrow = frameDelay;
                        }
                        rightArrow--;
                        skip = true;
                    }
                    else if(KeyboardUtils.JustPressed(Input.Keys.Delete) || KeyboardUtils.HeldDown(Input.Keys.Delete)) {
                        if(delete == 0) {
                            if(SelectionStart < Text.Length) {
                                Text = Text.Remove(SelectionStart, 1);
                            }
                            delete = frameDelay;
                        }
                        delete--;
                        skip = true;
                    }
                    else {
                        leftArrow = 0;
                        rightArrow = 0;
                        delete = 0;
                    }
                }

                if(!skip) {
                    int oldLength = Text.Length;
                    string substring = Text.Substring(0, SelectionStart);
                    string input = Main.GetInputText(substring);

                    // first, we check if the length of the string has changed, indicating
                    // text has been added or removed
                    if(input.Length != substring.Length) {
                        // we remove the old text and replace it with the new, storing it
                        // in a temporary variable
                        string newText = Text.Remove(0, SelectionStart).Insert(0, input);

                        // now if the text is smaller than previously or if not, the string is
                        // an appropriate size,
                        if(newText.Length < Text.Length || Font.MeasureString(newText).X < Size.X - 12) {
                            // we set the old text to the new text
                            Text = newText;

                            // if the length of the text is now longer,
                            if(Text.Length > oldLength) {
                                // adjust the selection start accordingly
                                SelectionStart += (Text.Length - oldLength);
                            }
                            // or if the length of the text is now shorter
                            else if(Text.Length < oldLength) {
                                // adjust the selection start accordingly
                                SelectionStart -= (oldLength - Text.Length);
                            }
                        }
                    }
                }
            }

            base.Update();
        }

        public override void Draw(SpriteBatch sb) {
            Vector2 position = Position;

            if(Parent != null) {
                position += Parent.Position;
            }

            Rectangle = new Rectangle((int)position.X, (int)position.Y, (int)Size.X, (int)Size.Y);

            if(Focused) {
                BaseTextureDrawing.DrawRectangleBox(sb, FocusedBorderColor, FocusedBackColor, Rectangle, 2);
                sb.DrawString(Font, Text.Insert(SelectionStart, "|"), position + new Vector2(2), FocusedTextColor);
            }
            else {
                BaseTextureDrawing.DrawRectangleBox(sb, BorderColor, BackColor, Rectangle, 2);
                sb.DrawString(Font, Text, position + new Vector2(2), TextColor);
            }

            base.Draw(sb);
        }
    }
}
