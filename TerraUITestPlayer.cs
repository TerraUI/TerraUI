using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using TerraUI;

namespace TerraUITest {
    public class TerraUITestPlayer : ModPlayer {
        UITextBox tb;
        UIButton btn;
        UIProgressBar bar;
        //UIScrollbar scrl;

        public override bool Autoload(ref string name) {
            return true;
        }

        public override void Initialize() {
            tb = new UITextBox(new Vector2(500, 500), new Vector2(100, 22), Main.fontItemStack, "Test text");
            btn = new UIButton(new Vector2(500, 550), new Vector2(100, 22), DoClick, Main.fontItemStack, "Click Here");
            bar = new UIProgressBar(new Vector2(500, 600), new Vector2(100, 22));
            //scrl = new UIScrollbar(new Vector2(500, 600), new Vector2(100, 22), Orientations.Horizontal);

            btn.ClickBackColor = Color.Red;
            btn.ClickBorderColor = Color.Blue;
            btn.ClickTextColor = Color.Green;

            bar.Maximum = 100;
            bar.BarMargin = new Vector2(0, 5);

            base.Initialize();
        }

        private void DoClick() {
            Main.NewText("Clicked!");
        }

        public override void PreUpdate() {
            UpdateUI();
            base.PreUpdate();
        }

        public void DrawUI(SpriteBatch spriteBatch) {
            if(tb != null) {
                tb.Draw(spriteBatch);
            }

            if(btn != null) {
                btn.Draw(spriteBatch);
            }

            if(bar != null) {
                bar.Draw(spriteBatch);
            }

            //if(scrl != null) {
            //    scrl.Draw(spriteBatch);
            //}
        }

        public void UpdateUI() {
            if(tb != null) {
                tb.Update();
            }

            if(btn != null) {
                btn.Update();
            }

            if(bar != null) {
                bar.Step();

                if(bar.Value == bar.Maximum) {
                    bar.Reset();
                }
            }

            //if(scrl != null) {
            //    scrl.Update();
            //}

            UIUtils.UpdateInput();
        }
    }
}
