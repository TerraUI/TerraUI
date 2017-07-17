using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using TerraUI;
using TerraUI.Elements;

namespace TerraUITest {
    public class TestUI : TUIState {
        private UIPanel panel;
        private UITextBox textBox;
        private TUIProgressBar progressBar;
        private TUIButton button;
        private TUIItemSlot itemSlot;

        public override void OnInitialize() {
            byte objects = 5;
            int width = 300;
            int height = 22;
            int margin = 10;
            int y = margin;
            int x = 10;

            panel = new UIPanel();
            panel.SetPadding(0);
            panel.Left.Set(500, 0);
            panel.Top.Set(500, 0);
            panel.Width.Set(width + (x * 2), 0);
            panel.Height.Set((objects * height) + ((objects + 1) * y + 30), 0);

            textBox = new UITextBox("Test text");
            textBox.Left.Set(x, 0);
            textBox.Top.Set(y, 0);
            textBox.Width.Set(width, 0);
            textBox.Height.Set(height, 0);
            textBox.DrawPanel = false;
            panel.Append(textBox);

            y += 50 + margin;

            progressBar = new TUIProgressBar(new StylePoint(x, y), new StylePoint(width, height));
            progressBar.Target = 100;
            progressBar.Value = 0;
            progressBar.BarMargin = new Padding(5, 0);
            progressBar.OnClick += ProgressBar_Click;
            progressBar.OnMiddleClick += ProgressBar_Click;
            progressBar.OnXButton1Click += ProgressBar_Click;
            progressBar.OnXButton2Click += ProgressBar_Click;
            progressBar.OnProgressFinished += ProgressBar_OnProgressFinished;
            panel.Append(progressBar);

            y += height + margin;

            button = new TUIButton(new StylePoint(x, y), new StylePoint(width, height), "Click Me!");
            button.OnClick += Button_OnClick;
            panel.Append(button);

            y += height + margin;

            itemSlot = new TUIItemSlot(new StylePoint(x, y), context: ItemSlot.Context.EquipDye, drawVisibilityIcon: true);
            panel.Append(itemSlot);

            Append(panel);
        }

        private void Button_OnClick(UIMouseEvent evt, UIElement listeningElement) {
            Main.NewText("You clicked me!");
        }

        private void ProgressBar_OnProgressFinished(TUIElement sender) {
            Main.NewText("ProgressBar finished!");
        }

        private void ProgressBar_Click(UIMouseEvent evt, UIElement listeningElement) {
            progressBar.Value += 25;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            if(panel.ContainsPoint(Main.MouseScreen)) {
                Main.LocalPlayer.mouseInterface = true;
            }
        }
    }
}
