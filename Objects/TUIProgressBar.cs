using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using TerraUI.Utils;

namespace TerraUI.Objects {
    public class TUIProgressBar : TUIBorderedElement {
        private float _target = 100;
        private float _value = 0;
        private bool _callFinished = true;

        /// <summary>
        /// Fires when the value of the UIProgressBar is equal to the maximum value.
        /// </summary>
        public event UIEventHandler OnProgressFinished;
        /// <summary>
        /// The target value of the UIProgressBar.
        /// </summary>
        public float Target {
            get { return _target; }
            set {
                if(value < 1) {
                    _target = 1;
                }
                else {
                    _target = value;
                }

                if(Value > value) {
                    Value = value;
                }
            }
        }
        /// <summary>
        /// The current filled percent of the UIProgressBar (between 0 and 1).
        /// </summary>
        public float Percent {
            get { return Value / Target; }
        }
        /// <summary>
        /// The current value of the UIProgressBar.
        /// </summary>
        public float Value {
            get { return _value; }
            set {
                if(value < 0) {
                    _value = 0;
                }
                else if(value >= Target) {
                    Finish();
                }
                else {
                    _value = value;
                }
            }
        }
        /// <summary>
        /// The background color of the UIProgressBar.
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// The color of the progress bar.
        /// </summary>
        public Color BarColor { get; set; }
        /// <summary>
        /// The margin around the progress bar inside the UIProgressBar.
        /// </summary>
        public Padding BarMargin { get; set; }

        /// <summary>
        /// Create a new UIProgressBar.
        /// </summary>
        /// <param name="location">location of the object in pixels</param>
        /// <param name="size">size of the object in pixels</param>
        /// <param name="parent">parent UIObject</param>
        public TUIProgressBar(StylePoint location, StylePoint size) : base(location, size) {
            BackColor = Colors.ProgressBar.BackColor;
            BorderColor = Colors.ProgressBar.BorderColor;
            BarColor = Colors.ProgressBar.BarColor;
            BorderWidth = 1;
            BarMargin = default(Padding);
        }

        /// <summary>
        /// Reset the UIProgressBar's progress.
        /// </summary>
        public void Reset() {
            _value = 0;
            _callFinished = true;
        }

        /// <summary>
        /// Finish the UIProgressBar's progress.
        /// </summary>
        public void Finish() {
            _value = _target;

            if(OnProgressFinished != null && _callFinished) {
                OnProgressFinished(this);
                _callFinished = false;
            }
        }

        /// <summary>
        /// Fires when the progress bar finishes.
        /// </summary>
        /// <param name="e"></param>
        public virtual void ProgressFinished() {
            if(OnProgressFinished != null) {
                OnProgressFinished(this);
                _callFinished = false;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            CalculatedStyle dim = GetDimensions();
            Rectangle rect = new Rectangle(
                    (int)(dim.X + BarMargin.Left + BorderWidth),
                    (int)(dim.Y + BarMargin.Top + BorderWidth),
                    (int)((dim.Width * Percent) - BarMargin.Left - BarMargin.Right - (BorderWidth * 2)),
                    (int)(dim.Height - BarMargin.Top - BarMargin.Bottom - (BorderWidth * 2)));

            DrawingUtils.DrawRectangleBox(spriteBatch, BorderColor, BackColor, GetDimensions().ToRectangle(), BorderWidth);
            DrawingUtils.DrawRectangleBox(spriteBatch, BorderColor, BarColor, rect, 0);
        }
    }
}
