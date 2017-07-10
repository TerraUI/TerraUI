using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using TerraUI;
using TerraUI.Objects;
using TerraUI.Panels;
using TerraUI.Utilities;

namespace TerraUITest {
    public class TerraUITestPlayer : ModPlayer {
        UITextBox tb;
        UIButton btn;
        UIProgressBar bar;
        UICheckBox chk;
        UINumberBox num;

        UIPanel pnl1;

        public override bool Autoload(ref string name) {
            return true;
        }

        public override void Initialize() {
            byte objects = 5;
            int width = 300;
            int height = 22;
            int margin = 10;
            int y = margin;
            int x = 10;

            pnl1 = new UIPanel(new Vector2(500, 500), new Vector2(width + (x * 2), (objects * height) + ((objects + 1) * y + 30)));
            tb = new UITextBox(new Vector2(x, y), new Vector2(width, height), Main.fontItemStack, "Test text", parent: pnl1);
            y += height + margin;
            bar = new UIProgressBar(new Vector2(x, y), new Vector2(width, height), parent: pnl1);
            y += height + margin;
            chk = new UICheckBox(new Vector2(x, y), width, 20, Main.fontItemStack, "Check this", parent: pnl1);
            y += height + margin;
            num = new UINumberBox(new Vector2(x, y), new Vector2(width, height), Main.fontItemStack, parent: pnl1);
            y += height + margin;
            btn = new UIButton(new Vector2(x, y), new Vector2(width, height), Main.fontItemStack, "Click Here", parent: pnl1);

            tb.GotFocus += tb_GotFocus;
            tb.LostFocus += tb_LostFocus;
            
            pnl1.MouseEnter += pnl1_MouseEnter;
            pnl1.MouseLeave += pnl1_MouseLeave;

            bar.Maximum = 100;
            bar.BarMargin = new Vector2(0, 5);
            bar.StepAmount = 10;

            chk.BoxColor = Color.CornflowerBlue;
            chk.TickColor = Color.Crimson;

            btn.Click += btn_Click;
            btn.MouseEnter += btn_MouseEnter;
            btn.MouseLeave += btn_MouseLeave;
            btn.MouseDown += btn_MouseDown;
            btn.MouseUp += btn_MouseUp;

            base.Initialize();
        }

        private void pnl1_MouseLeave(UIObject sender, MouseEventArgs e) {
            ((UIPanel)sender).BackColor = UIColors.BackColorTransparent;
        }

        private void pnl1_MouseEnter(UIObject sender, MouseEventArgs e) {
            ((UIPanel)sender).BackColor = UIColors.LightBackColorTransparent;
        }

        private void tb_LostFocus(UIObject sender) {
            ((UITextBox)sender).BackColor = UIColors.TextBox.BackColor;
        }

        private void tb_GotFocus(UIObject sender) {
            ((UITextBox)sender).BackColor = Color.LightGoldenrodYellow;
        }

        private void btn_MouseUp(UIObject sender, MouseButtonEventArgs e) {
            ((UIButton)sender).BackColor = UIColors.LightBackColor;
        }

        private void btn_MouseDown(UIObject sender, MouseButtonEventArgs e) {
            ((UIButton)sender).BackColor = UIColors.DarkBackColor;
        }

        private void btn_MouseLeave(UIObject sender, MouseEventArgs e) {
            ((UIButton)sender).BackColor = UIColors.BackColor;
        }

        private void btn_MouseEnter(UIObject sender, MouseEventArgs e) {
            ((UIButton)sender).BackColor = UIColors.LightBackColor;
        }

        private bool btn_Click(UIObject sender, MouseButtonEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                if(KeyboardUtils.State.PressingShift()) {
                    Main.NewText("CheckBox is " + (chk.Checked ? "checked" : "not checked"));
                }
                else {
                    Main.NewText("You entered: " + tb.Text);
                }
                return true;
            }
            else if(e.Button == MouseButtons.Right) {
                Main.NewText("Right clicked!");
                return true;
            }
            else if(e.Button == MouseButtons.Middle) {
                bar.Step();

                if(bar.Value >= bar.Maximum) {
                    bar.Reset();
                }
            }

            return false;
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

            UIUtils.UpdateInput();
        }
    }
}
