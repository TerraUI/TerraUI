using System.Windows.Forms;
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

        public string Text { get; set; }
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
        public SpriteFont Font { get; set; }
        public Color BorderColor { get; set; }
        public Color FocusedBorderColor { get; set; }
        public Color BackColor { get; set; }
        public Color FocusedBackColor { get; set; }
        public Color TextColor { get; set; }
        public Color FocusedTextColor { get; set; }

        public UITextBox(Vector2 position, Vector2 size, SpriteFont font, string text = "", UIObject parent = null)
            : base(position, size, parent, true) {
            Text = text;
            Focused = false;
            Font = font;
            BorderColor = FocusedBorderColor = Color.DarkGray;
            BackColor = FocusedBackColor = Color.White;
            TextColor = FocusedTextColor = Color.Black;
        }

        public override void Focus() {
            base.Focus();
            SelectionStart = Text.Length;
        }

        public override void Update() {
            base.Update();

            if(Focused) {
                Input.Keys[] oldPressed = UIParameters.oldState.GetPressedKeys();
                Input.Keys[] newPressed = UIParameters.newState.GetPressedKeys();

                bool shift = false;
                bool capsLock = false;
                bool numLock = false;
                bool skip = false;

                if(Text.Length > 0) {
                    if(UIParameters.JustPressed(Input.Keys.Left) || UIParameters.HeldDown(Input.Keys.Left)) {
                        if(leftArrow == 0) {
                            SelectionStart--;
                            leftArrow = frameDelay;
                        }
                        leftArrow--;
                        skip = true;
                    }
                    else if(UIParameters.JustPressed(Input.Keys.Right) || UIParameters.HeldDown(Input.Keys.Right)) {
                        if(rightArrow == 0) {
                            SelectionStart++;
                            rightArrow = frameDelay;
                        }
                        rightArrow--;
                        skip = true;
                    }
                    else if(UIParameters.HeldDown(Input.Keys.Back)) {
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
                    else if(UIParameters.JustPressed(Input.Keys.Delete) || UIParameters.HeldDown(Input.Keys.Delete)) {
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
                    if(UIParameters.HeldDown(Input.Keys.LeftShift) || UIParameters.HeldDown(Input.Keys.RightShift)) {
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
                                Text = Text.Insert(SelectionStart, UIParameters.TranslateChar(newPressed[i], shift, capsLock, numLock));
                                SelectionStart++;
                            }
                        }
                    }
                }
            }
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
