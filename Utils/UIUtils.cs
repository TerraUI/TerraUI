using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.Localization;
using TerraUI.Objects;

namespace TerraUI.Utilities {
    public static class UIUtils {
        /// <summary>
        /// Play a game sound.
        /// </summary>
        /// <param name="type">sound</param>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="style">style</param>
        public static void PlaySound(Sounds type, int x = -1, int y = -1, int style = 1, float volumeScale = 1f,
            float pitchOffset = 0f) {
            Main.PlaySound((int)type, x, y, style, volumeScale, pitchOffset);
        }

        /// <summary>
        /// Updates the current mouse and keyboard state.
        /// Call after all UIObjects have been updated.
        /// </summary>
        public static void UpdateInput() {
            MouseUtils.UpdateState();
            KeyboardUtils.UpdateState();
        }

        /// <summary>
        /// Get the state of a button.
        /// </summary>
        /// <param name="mouseButton">mouse button</param>
        /// <param name="mouseState">mouse state</param>
        /// <returns>state of given mouse button</returns>
        public static ButtonState GetButtonState(MouseButtons mouseButton, MouseState mouseState) {
            switch(mouseButton) {
                case MouseButtons.Left:
                    return mouseState.LeftButton;
                case MouseButtons.Middle:
                    return mouseState.MiddleButton;
                case MouseButtons.Right:
                    return mouseState.RightButton;
                case MouseButtons.XButton1:
                    return mouseState.XButton1;
                case MouseButtons.XButton2:
                    return mouseState.XButton2;
                default:
                    return ButtonState.Released;
            }
        }

        /// <summary>
        /// Get the texture of a slot based on its context.
        /// </summary>
        /// <param name="context">slot context</param>
        /// <returns>texture of the slot</returns>
        public static Texture2D GetContextTexture(Contexts context) {
            switch(context) {
                case Contexts.EquipAccessory:
                case Contexts.EquipArmor:
                case Contexts.EquipGrapple:
                case Contexts.EquipMount:
                case Contexts.EquipMinecart:
                case Contexts.EquipPet:
                case Contexts.EquipLight:
                    return Main.inventoryBack3Texture;
                case Contexts.EquipArmorVanity:
                case Contexts.EquipAccessoryVanity:
                    return Main.inventoryBack8Texture;
                case Contexts.EquipDye:
                    return Main.inventoryBack12Texture;
                case Contexts.ChestItem:
                    return Main.inventoryBack5Texture;
                case Contexts.BankItem:
                    return Main.inventoryBack2Texture;
                case Contexts.GuideItem:
                case Contexts.PrefixItem:
                case Contexts.CraftingMaterial:
                    return Main.inventoryBack4Texture;
                case Contexts.TrashItem:
                    return Main.inventoryBack7Texture;
                case Contexts.ShopItem:
                    return Main.inventoryBack6Texture;
                default:
                    return Main.inventoryBackTexture;
            }
        }

        /// <summary>
        /// Get the hover text of a slot based on its context and the current language.
        /// </summary>
        /// <param name="context">context of the slot</param>
        /// <returns>text in current language</returns>
        public static string GetHoverText(Contexts context) {
            switch(context) {
                case Contexts.EquipAccessory:
                    return Language.GetTextValue("LegacyInterface.9");
                case Contexts.EquipAccessoryVanity:
                    return Language.GetTextValue("LegacyInterface.11") + " " + Language.GetTextValue("LegacyInterface.9");
                case Contexts.EquipDye:
                    return Language.GetTextValue("LegacyInterface.57");
                case Contexts.EquipGrapple:
                    return Language.GetTextValue("LegacyInterface.90");
                case Contexts.EquipLight:
                    return Language.GetTextValue("LegacyInterface.94");
                case Contexts.EquipMinecart:
                    return Language.GetTextValue("LegacyInterface.93");
                case Contexts.EquipMount:
                    return Language.GetTextValue("LegacyInterface.91");
                case Contexts.EquipPet:
                    return Language.GetTextValue("LegacyInterface.92");
                case Contexts.InventoryAmmo:
                    return Language.GetTextValue("LegacyInterface.27");
                case Contexts.InventoryCoin:
                    return Language.GetTextValue("LegacyInterface.26");
            }

            return string.Empty;
        }

        /// <summary>
        /// Clamp a specified value within certain parameters.
        /// </summary>
        /// <typeparam name="T">any comparable type</typeparam>
        /// <param name="value">value to clamp</param>
        /// <param name="min">minimum value</param>
        /// <param name="max">maximum value</param>
        /// <returns>clamped value</returns>
        public static T Clamp<T>(T value, T min, T max) where T : IComparable {
            if(max.CompareTo(min) < 0) {
                throw new ArgumentException(string.Format("Maximum value is smaller than minimum value."));
            }

            int comparedMin = value.CompareTo(min);
            int comparedMax = value.CompareTo(max);

            if(comparedMin < 0) {
                return min;
            }
            else if(comparedMax > 0) {
                return max;
            }
            else return value;
        }

        /// <summary>
        /// Switch two items.
        /// </summary>
        /// <param name="item1">first item</param>
        /// <param name="item2">second item</param>
        public static void SwitchItems(ref Item item1, ref Item item2) {
            if((item1.type == 0 || item1.stack < 1) && (item2.type != 0 || item2.stack > 0)) //if item2 is mouseitem, then if item slot is empty and item is picked up
            {
                item1 = item2;
                item2 = new Item();
                item2.SetDefaults();
            }
            else if((item1.type != 0 || item1.stack > 0) && (item2.type == 0 || item2.stack < 1)) //if item2 is mouseitem, then if item slot is empty and item is picked up
            {
                item2 = item1;
                item1 = new Item();
                item1.SetDefaults();
            }
            else if((item1.type != 0 || item1.stack > 0) && (item2.type != 0 || item2.stack > 0)) //if item2 is mouseitem, then if item slot is empty and item is picked up
            {
                Item item3 = item2;
                item2 = item1;
                item1 = item3;
            }
        }
    }
}
