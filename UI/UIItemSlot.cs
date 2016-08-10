using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerraUI {
    public class UIItemSlot : UIObject {
        private Item item;
        protected const int defaultSize = 52;
        public delegate void DrawItemSlotHandler(SpriteBatch spriteBatch, UIItemSlot slot);
        public delegate bool ConditionHandler(Item item);

        /// <summary>
        /// Method that checks whether an item can go in the slot.
        /// </summary>
        public ConditionHandler Conditions { get; set; }
        /// <summary>
        /// Method that draws the background of the item slot.
        /// </summary>
        public DrawItemSlotHandler DrawBackground { get; set; }
        /// <summary>
        /// Method that draws the item in the slot.
        /// </summary>
        public DrawItemSlotHandler DrawItem { get; set; }
        /// <summary>
        /// Method called after the item in the slot is drawn.
        /// </summary>
        public DrawItemSlotHandler PostDrawItem { get; set; }
        /// <summary>
        /// Whether to draw the slot as a normal item slot.
        /// </summary>
        public bool DrawAsNormalItemSlot { get; set; }
        /// <summary>
        /// The context for the slot if DrawAsNormalItemSlot is true.
        /// </summary>
        public int Context { get; set; }
        /// <summary>
        /// The item shown in the slot.
        /// </summary>
        public Item Item {
            get { return item; }
            set { item = value; }
        }

        /// <summary>
        /// Create a new UIItemSlot.
        /// </summary>
        /// <param name="position">position of slot in pixels</param>
        /// <param name="size">size of slot in pixels</param>
        /// <param name="condition">checked before item is placed in slot; if null, all items are permitted</param>
        /// <param name="parent">parent UIObject</param>
        /// <param name="drawBackground">run when slot background is drawn; if null, slot is drawn with background texture</param>
        /// <param name="drawItem">run when item in slot is drawn; if null, item is drawn in center of slot</param>
        /// <param name="postDrawItem">run after item in slot is drawn; use to draw elements over the item</param>
        /// <param name="drawAsNormalItemSlot">draw as a normal inventory ItemSlot</param>
        /// <param name="context">context for slot if drawAsNormalItemSlot is true</param>
        public UIItemSlot(Vector2 position, int size = 52, ConditionHandler conditions = null, UIObject parent = null,
            DrawItemSlotHandler drawBackground = null, DrawItemSlotHandler drawItem = null,
            DrawItemSlotHandler postDrawItem = null, bool drawAsNormalItemSlot = false, int context = 0)
            : base(position, new Vector2(size), parent, false) {
            Item = new Item();
            Conditions = conditions;
            DrawBackground = drawBackground;
            DrawItem = drawItem;
            PostDrawItem = postDrawItem;
            DrawAsNormalItemSlot = drawAsNormalItemSlot;
            Context = context;
        }

        /// <summary>
        /// The default left click event.
        /// </summary>
        protected override void DefaultLeftClick() {
            ItemSlot.LeftClick(ref item, 0);
            Recipe.FindRecipes();
        }

        /// <summary>
        /// The default right click event.
        /// </summary>
        protected override void DefaultRightClick() {
            ItemSlot.RightClick(ref item, 0);
        }

        /// <summary>
        /// Draw the object. Call during any Draw() function.
        /// </summary>
        /// <param name="spriteBatch">drawing SpriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch) {
            Vector2 position = Position;
            Point mouse = new Point(Main.mouseX, Main.mouseY);

            if(Parent != null) {
                position += Parent.Position;
            }

            Rectangle = new Rectangle((int)position.X, (int)position.Y, (int)Size.X, (int)Size.Y);

            if(DrawAsNormalItemSlot) {
                ItemSlot.Draw(spriteBatch, ref item, Context, position);
            }
            else {
                if(DrawBackground != null) {
                    DrawBackground(spriteBatch, this);
                }
                else {
                    spriteBatch.Draw(Main.inventoryBackTexture, Rectangle, Color.White);
                }
            }

            if(item.type > 0) {
                if(DrawItem != null) {
                    DrawItem(spriteBatch, this);
                }
                else {
                    Texture2D texture2D = Main.itemTexture[item.type];
                    Rectangle rectangle2;

                    if(Main.itemAnimations[item.type] != null) {
                        rectangle2 = Main.itemAnimations[item.type].GetFrame(texture2D);
                    }
                    else {
                        rectangle2 = texture2D.Frame(1, 1, 0, 0);
                    }

                    Vector2 origin = new Vector2(rectangle2.Width / 2, rectangle2.Height / 2);

                    spriteBatch.Draw(
                        Main.itemTexture[item.type],
                        new Vector2(Rectangle.X + Rectangle.Width / 2, 
                                    Rectangle.Y + Rectangle.Height / 2),
                        new Rectangle?(rectangle2),
                        Color.White,
                        0f,
                        origin,
                        1f,
                        SpriteEffects.None,
                        0f);
                }
            }

            if(PostDrawItem != null) {
                PostDrawItem(spriteBatch, this);
            }

            base.Draw(spriteBatch);
        }
    }
}
