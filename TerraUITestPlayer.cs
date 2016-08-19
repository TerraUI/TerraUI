﻿using System;
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
        UIPanel pnl1;

        public override bool Autoload(ref string name) {
            return true;
        }

        public override void Initialize() {
            int width = 100;
            int height = 22;
            int margin = 10;
            int y = margin;
            int x = 10;

            pnl1 = new UIPanel(new Vector2(500, 500), new Vector2(width + (x * 2), (3 * height) + (4 * y)));
            tb = new UITextBox(new Vector2(x, y), new Vector2(width, height), Main.fontItemStack, "Test text", pnl1);
            y += height + margin;
            btn = new UIButton(new Vector2(x, y), new Vector2(width, height), Main.fontItemStack, "Click Here", parent: pnl1);
            y += height + margin;
            bar = new UIProgressBar(new Vector2(x, y), new Vector2(width, height), parent: pnl1);
            
            btn.ClickBackColor = Color.Red;
            btn.ClickBorderColor = Color.Blue;
            btn.ClickTextColor = Color.Green;
            btn.LeftClick += btn_LeftClick;

            bar.Maximum = 100;
            bar.BarMargin = new Vector2(0, 5);

            base.Initialize();
        }

        private bool btn_LeftClick(UIObject sender, ClickEventArgs e) {
            Main.NewText("Clicked!");
            return true;
        }

        public override void PreUpdate() {
            UpdateUI();
            base.PreUpdate();
        }

        public void DrawUI(SpriteBatch spriteBatch) {
            if(pnl1 != null)
                pnl1.Draw(spriteBatch);
        }

        public void UpdateUI() {
            if(pnl1 != null) {
                pnl1.Update();
            }

            if(bar != null) {
                bar.Step();

                if(bar.Value == bar.Maximum) {
                    bar.Reset();
                }
            }

            UIUtils.UpdateInput();
        }
    }
}
