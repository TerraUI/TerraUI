using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using TerraUI.Utils;

namespace TerraUI.Elements {
    public class TUIImageButton : TUIElement {
        private Texture2D _texture;
        private float _opacity = 1f;
        private float _scale = 1f;

        /// <summary>
        /// The texture to display on the object.
        /// </summary>
        public Texture2D Texture {
            get { return _texture; }
            set {
                _texture = value;

                if(_texture != null) {
                    Size = new StylePoint(_texture.Width, _texture.Height);
                }
                else {
                    Size = new StylePoint(0);
                }
            }
        }
        /// <summary>
        /// The opacity of the image.
        /// </summary>
        public float Opacity {
            get { return _opacity; }
            set { _opacity = TUIUtils.Clamp(_opacity, 0f, 1f); }
        }
        /// <summary>
        /// The scale of the image.
        /// </summary>
        public float Scale {
            get { return _scale; }
            set {
                _scale = value;
                Size = new StylePoint(Texture.Width * _scale, Texture.Height * _scale);
            }
        }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="location">location of object</param>
        /// <param name="texture">size of object</param>
        /// <param name="opacity">opacity of image</param>
        public TUIImageButton(StylePoint location, Texture2D texture, float opacity = 1f, float scale = 1f)
            : base(location, new StylePoint(texture.Width, texture.Height)) {
            Texture = texture;
            Opacity = opacity;
            Scale = 1f;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, GetDimensions().Position(), null, Color.White * Opacity, 0f, Vector2.Zero, Scale, 
                SpriteEffects.None, 0f);
        }
    }
}
