using Microsoft.Xna.Framework;
using TerraUI.Utils;

namespace TerraUI.Objects {
    public class TUIBorderedElement : TUIElement {
        private byte _borderWidth;

        /// <summary>
        /// The color of the border.
        /// </summary>
        public Color BorderColor { get; set; }
        /// <summary>
        /// The width of the border.
        /// </summary>
        public byte BorderWidth {
            get { return _borderWidth; }
            set {
                if(value < 0) {
                    _borderWidth = 0;
                }
                else {
                    _borderWidth = value;
                }
            }
        }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="location">location of object</param>
        /// <param name="size">size of object</param>
        /// <param name="borderWidth">width of border around object</param>
        public TUIBorderedElement(StylePoint location, StylePoint size, byte borderWidth = 1) : base(location, size) {
            BorderWidth = borderWidth;
            BorderColor = TUIColors.Button.BorderColor;
        }
    }
}
