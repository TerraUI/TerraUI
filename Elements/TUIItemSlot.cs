using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Chat;
using TerraUI.Utils;

namespace TerraUI.Elements {
    public class TUIItemSlot : TUIElement {
        protected const int DEFAULT_SIZE = 52;

        protected Item _item;
        protected string _hoverText = "";
        protected float _backOpacity = 1f;
        protected bool _drawVisibilityIcon = false;
        protected TUIImageButton _tick;

        /// <summary>
        /// Whether the item in the slot is visible on the player character.
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// The context for the slot.
        /// </summary>
        public int Context { get; set; }
        /// <summary>
        /// The scale of the slot.
        /// </summary>
        public float Scale { get; set; }
        /// <summary>
        /// The item shown in the slot.
        /// </summary>
        public Item Item {
            get { return _item; }
            set { _item = value; }
        }
        /// <summary>
        /// Whether to draw the visibility icon (eye icon) on a slot.
        /// </summary>
        public bool DrawVisibilityIcon {
            get { return _drawVisibilityIcon; }
            set {
                _drawVisibilityIcon = value;

                if(_drawVisibilityIcon) {
                    Append(_tick);
                }
                else {
                    RemoveChild(_tick);
                }
            }
        }
        /// <summary>
        /// The opacity of the item slot background (between 0 and 1).
        /// </summary>
        public float BackOpacity {
            get { return _backOpacity; }
            set { _backOpacity = TUIUtils.Clamp(value, 0f, 1f); }
        }
        /// <summary>
        /// The item texture to draw when the slot is empty. If null, texture is determined by slot context.
        /// </summary>
        public Texture2D EmptyTexture { get; set; }
        /// <summary>
        /// Whether to draw an item texture when the slot is empty.
        /// </summary>
        public bool DrawEmptyTexture { get; set; }

        /// <summary>
        /// Create a new TUIItemSlot.
        /// </summary>
        /// <param name="location">location of object</param>
        /// <param name="scale">scale of slot</param>
        /// <param name="context">context of slot</param>
        /// <param name="drawVisibilityIcon">whether to draw visibility (eye) icon</param>
        /// <param name="drawEmptyTexture">whether to draw item texture when slot is empty</param>
        public TUIItemSlot(StylePoint location, float scale = .85f, int context = ItemSlot.Context.InventoryItem,
            bool drawVisibilityIcon = false, bool drawEmptyTexture = true) : base(location, new StylePoint(DEFAULT_SIZE)) {
            _tick = new TUIImageButton(StylePoint.Zero, Main.inventoryTickOnTexture, 1f);
            _tick.OnClick += tick_OnClick;

            Scale = scale;
            Context = context;
            DrawVisibilityIcon = drawVisibilityIcon;
            DrawEmptyTexture = drawEmptyTexture;
            
            Item = new Item();
        }

        private void tick_OnClick(UIMouseEvent evt, UIElement listeningElement) {
            Visible = !Visible;
            Main.PlaySound(SoundID.MenuTick);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            CalculatedStyle dim = GetDimensions();
            Texture2D backTex = TUIUtils.GetContextTexture(Context);

            // draw the background
            spriteBatch.Draw(
                backTex,
                new Vector2(dim.X, dim.Y),
                null,
                Color.White * BackOpacity,
                0f,
                Vector2.Zero,
                Scale,
                SpriteEffects.None,
                1f);

            // draw empty background texture
            if(DrawEmptyTexture && Item.stack < 1) {
                Texture2D tex = (EmptyTexture != null ? EmptyTexture : Main.extraTexture[54]);
                Rectangle bounds = tex.Bounds;

                if(EmptyTexture == null) {
                    bounds = TUIUtils.GetEmptyTextureRectangle(Context);
                }

                spriteBatch.Draw(
                    tex,
                    new Vector2(dim.X + (dim.Width / 2 * Scale), dim.Y + (dim.Height / 2 * Scale)),
                    new Rectangle?(bounds),
                    Color.White * .35f,
                    0f,
                    bounds.Size() / 2f,
                    Scale,
                    SpriteEffects.None,
                    0f);
            }
            // draw item
            else if(Item.stack > 0) {
                Texture2D tex = Main.itemTexture[Item.type];
                Rectangle bounds = tex.Bounds;

                if(Main.itemAnimations[Item.type] != null) {
                    bounds = Main.itemAnimations[Item.type].GetFrame(tex);
                }

                spriteBatch.Draw(
                    tex,
                    new Vector2(dim.X + (dim.Width / 2 * Scale), dim.Y + (dim.Height / 2 * Scale)),
                    new Rectangle?(bounds),
                    Color.White,
                    0f,
                    bounds.Size() / 2f,
                    Scale,
                    SpriteEffects.None,
                    0f);

                // draw item stack count
                if(Item.stack > 1) {
                    ChatManager.DrawColorCodedStringWithShadow(
                        spriteBatch,
                        Main.fontItemStack,
                        Item.stack.ToString(),
                        dim.Position() + new Vector2(10f, 26f) * Scale,
                        Color.White,
                        0f,
                        Vector2.Zero,
                        new Vector2(Scale),
                        -1f,
                        Scale);
                }
            }

            // draw the visibility tick
            if(DrawVisibilityIcon) {
                _tick.Location = new StylePoint(Size.X.Pixels - 18, -2);
                _tick.Texture = (Visible ? Main.inventoryTickOnTexture : Main.inventoryTickOffTexture);
                RecalculateChildren();
            }

            if(DrawVisibilityIcon && _tick.IsMouseHovering) {
                Main.hoverItemName = (Visible ? Language.GetTextValue("LegacyInterface.59") : Language.GetTextValue("GameUI.Hidden"));
            }
            else if(IsMouseHovering) {
                ItemSlot.Handle(ref _item, Context);
            }
        }
    }
}
