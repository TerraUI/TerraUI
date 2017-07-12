using System;
using Terraria;
using Terraria.ModLoader;

namespace TerraUITest {
    class TerraUITest : Mod {
        public TerraUITest() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}
