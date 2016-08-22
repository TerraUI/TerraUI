/*
 * todo: set Properties > Debug > Start Action to tModLoader Terraria.exe
 * todo: set Properties > Debug > Working directory to Terraria folder
 * todo: update description.txt
 */

using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using TerraUI.Utilities;

namespace TerraUITest {
    public class TerraUITest : Mod {
        public override void Load() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };

            UIUtils.Mod = this;
            UIUtils.Subdirectory = "TerraUI";
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch) {
            TerraUITestPlayer player = Main.player[Main.myPlayer].GetModPlayer<TerraUITestPlayer>(this);
            player.DrawUI(spriteBatch);
            base.PostDrawInterface(spriteBatch);
        }
    }
}
