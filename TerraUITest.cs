/*
 * todo: set Properties > Debug > Start Action to tModLoader Terraria.exe
 * todo: set Properties > Debug > Working directory to Terraria folder
 * todo: update description.txt
 */

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TerraUI;
using System.Diagnostics;

namespace TerraUITest {
    public class TerraUITest : Mod {
        UITextBox tb;
        UIButton btn;
        //UIScrollbar scrl;

        public override void Load() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };

            tb = new UITextBox(new Vector2(500, 500), new Vector2(100, 22), Main.fontItemStack, "Test text");
            btn = new UIButton(new Vector2(500, 550), new Vector2(100, 22), DoClick, Main.fontItemStack, "Click Here");
            //scrl = new UIScrollbar(new Vector2(500, 600), new Vector2(100, 22), Orientations.Horizontal);
            btn.ClickBackColor = Color.Red;
            btn.ClickBorderColor = Color.Blue;
            btn.ClickTextColor = Color.Green;
            UIUtils.Mod = this;
            UIUtils.Subdirectory = "TerraUI";
        }

        private void DoClick() {
            Main.NewText("Clicked!");
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch) {
            if(tb != null) {
                tb.Draw(spriteBatch);
            }

            if(btn != null) {
                btn.Draw(spriteBatch);
            }

            //if(scrl != null) {
            //    scrl.Draw(spriteBatch);
            //}

            base.PostDrawInterface(spriteBatch);
        }

        public override void PostUpdateInput() {
            if(tb != null) {
                tb.Update();
            }

            if(btn != null) {
                btn.Update();
            }

            //if(scrl != null) {
            //    scrl.Update();
            //}

            UIUtils.UpdateInput();
            base.PostUpdateInput();
        }
    }
}
