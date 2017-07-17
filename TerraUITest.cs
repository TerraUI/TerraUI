using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerraUITest {
    class TerraUITest : Mod {
        UserInterface ui;
        TestUI testUI;

        public TerraUITest() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load() {
            testUI = new TestUI();
            testUI.Activate();
            testUI.Visible = true;

            ui = new UserInterface();
            ui.SetState(testUI);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int mouseTextIndex = layers.FindIndex(l => l.Name.Equals("Vanilla: Mouse Text"));

            if(mouseTextIndex > -1) {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "TerraUITest: Test UI",
                    delegate {
                        if(testUI.Visible) {
                            ui.Update(Main._drawInterfaceGameTime);
                            testUI.Draw(Main.spriteBatch);
                        }

                        return true;
                    }, InterfaceScaleType.UI));
            }
        }
    }
}
