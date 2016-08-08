using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;

namespace TerraUI {
    public class UIObject {
        protected bool acceptsKeyboardInput = false;

        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Rectangle Rectangle { get; protected set; }
        public bool Focused { get; protected set; }
        public List<UIObject> Children { get; set; }
        public UIObject Parent { get; set; }

        public UIObject(Vector2 position, Vector2 size, UIObject parent = null, bool acceptsKeyboardInput = false) {
            Position = position;
            Size = size;
            Children = new List<UIObject>();
            Parent = parent;
            this.acceptsKeyboardInput = acceptsKeyboardInput;
        }

        public virtual void Update() {
            if(UIUtils.JustPressed(MouseButtons.Left)) {
                if(UIUtils.MouseRect.Intersects(Rectangle)) {
                    Focus();
                }
                else {
                    Unfocus();
                }
            }

            if(UIUtils.JustPressed(Keys.Escape)) {
                Unfocus();
            }

            foreach(UIObject obj in Children) {
                obj.Update();
            }

            UIUtils.UpdateInput();
        }

        public virtual void Draw(SpriteBatch sb) {
            foreach(UIObject obj in Children) {
                obj.Draw(sb);
            }
        }

        public virtual void Focus() {
            Focused = true;
            if(acceptsKeyboardInput) {
                Main.blockInput = true;
            }
        }

        public virtual void Unfocus() {
            Focused = false;
            if(acceptsKeyboardInput) {
                Main.blockInput = false;
            }
        }
    }
}
