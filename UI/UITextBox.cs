using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Input = Microsoft.Xna.Framework.Input;

namespace TerraUI {
    public class UITextBox : UIObject {
        private const int frameDelay = 9;
        private int selectionStart = 0;
        private int backSpace = 0;
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
                Input.Keys[] oldPressed = KeyboardUtils.LastState.GetPressedKeys();
                Input.Keys[] newPressed = KeyboardUtils.State.GetPressedKeys();

                bool shift = false;
                bool capsLock = false;
                bool numLock = false;
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
                    else if(KeyboardUtils.HeldDown(Input.Keys.Back)) {
                        if(backSpace == 0) {
                            if(SelectionStart > 0) {
                                Text = Text.Remove(SelectionStart - 1, 1);
                                SelectionStart--;
                            }
                            backSpace = frameDelay;
                        }
                        backSpace--;
                        skip = true;
                    }
                    else if(KeyboardUtils.JustPressed(Input.Keys.Delete) || KeyboardUtils.HeldDown(Input.Keys.Delete)) {
                        if(delete == 0) {
                            if(SelectionStart < Text.Length) {
                                Text = Text.Remove(SelectionStart, 1);
                                //SelectionStart--;
                            }
                            delete = frameDelay;
                        }
                        delete--;
                        skip = true;
                    }
                    else {
                        backSpace = 0;
                        leftArrow = 0;
                        rightArrow = 0;
                        delete = 0;
                    }
                }

                if(!skip) {
                    if(KeyboardUtils.HeldDown(Input.Keys.LeftShift) || KeyboardUtils.HeldDown(Input.Keys.RightShift)) {
                        shift = true;
                    }

                    if(Control.IsKeyLocked(Keys.CapsLock)) {
                        capsLock = true;
                    }

                    if(Control.IsKeyLocked(Keys.NumLock)) {
                        numLock = true;
                    }

                    for(int i = 0; i < newPressed.Length; i++) {
                        if(newPressed[i] == Input.Keys.Back) {
                            skip = true;
                        }

                        if(!skip) {
                            bool doTranslate = true;

                            for(int k = 0; k < oldPressed.Length; k++) {
                                if(newPressed[i] == oldPressed[k]) {
                                    doTranslate = false;
                                }
                            }

                            if(Font.MeasureString(Text).X >= this.Size.X - 12) {
                                doTranslate = false;
                            }

                            if(doTranslate) {
                                Text = Text.Insert(SelectionStart, UIUtils.TranslateChar(newPressed[i], shift, capsLock, numLock));
                                SelectionStart++;
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
