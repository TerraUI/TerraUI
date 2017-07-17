using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.Localization;
using Terraria.UI;

namespace TerraUI.Utils {
    public static class TUIUtils {
        /// <summary>
        /// Updates the current mouse and keyboard state.
        /// Call after all UIObjects have been updated.
        /// </summary>
        public static void UpdateInput() {
            TUIMouseUtils.UpdateState();
            TUIKeyboardUtils.UpdateState();
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
        public static Texture2D GetContextTexture(int context) {
            switch(context) {
                case ItemSlot.Context.EquipAccessory:
                case ItemSlot.Context.EquipArmor:
                case ItemSlot.Context.EquipGrapple:
                case ItemSlot.Context.EquipMount:
                case ItemSlot.Context.EquipMinecart:
                case ItemSlot.Context.EquipPet:
                case ItemSlot.Context.EquipLight:
                    return Main.inventoryBack3Texture;
                case ItemSlot.Context.EquipArmorVanity:
                case ItemSlot.Context.EquipAccessoryVanity:
                    return Main.inventoryBack8Texture;
                case ItemSlot.Context.EquipDye:
                    return Main.inventoryBack12Texture;
                case ItemSlot.Context.ChestItem:
                    return Main.inventoryBack5Texture;
                case ItemSlot.Context.BankItem:
                    return Main.inventoryBack2Texture;
                case ItemSlot.Context.GuideItem:
                case ItemSlot.Context.PrefixItem:
                case ItemSlot.Context.CraftingMaterial:
                    return Main.inventoryBack4Texture;
                case ItemSlot.Context.TrashItem:
                    return Main.inventoryBack7Texture;
                case ItemSlot.Context.ShopItem:
                    return Main.inventoryBack6Texture;
                default:
                    return Main.inventoryBackTexture;
            }
        }

        /// <summary>
        /// Get the empty texture rectangle of a slot based on its context.
        /// </summary>
        /// <param name="context">slot context</param>
        /// <returns>empty item texture</returns>
        public static Rectangle GetEmptyTextureRectangle(int context) {
            return GetEmptyTextureRectangle(context, ArmorType.Chest);
        }

        /// <summary>
        /// Get the empty texture rectangle of a slot based on its context and armor type.
        /// </summary>
        /// <param name="context">slot context</param>
        /// <param name="armorType">armor type</param>
        /// <returns>empty item texture</returns>
        public static Rectangle GetEmptyTextureRectangle(int context, ArmorType armorType) {
            int pos = -1;

            switch(context) {
                case ItemSlot.Context.EquipArmor:
                    if(armorType == ArmorType.Head) {
                        pos = 0;
                    }
                    else if(armorType == ArmorType.Chest) {
                        pos = 6;
                    }
                    else if(armorType == ArmorType.Legs) {
                        pos = 12;
                    }
                    break;
                case ItemSlot.Context.EquipArmorVanity:
                    if(armorType == ArmorType.Head) {
                        pos = 3;
                    }
                    else if(armorType == ArmorType.Chest) {
                        pos = 9;
                    }
                    else if(armorType == ArmorType.Legs) {
                        pos = 15;
                    }
                    break;
                case ItemSlot.Context.EquipAccessory:
                    pos = 11;
                    break;
                case ItemSlot.Context.EquipAccessoryVanity:
                    pos = 2;
                    break;
                case ItemSlot.Context.EquipDye:
                    pos = 1;
                    break;
                case ItemSlot.Context.EquipGrapple:
                    pos = 4;
                    break;
                case ItemSlot.Context.EquipMount:
                    pos = 13;
                    break;
                case ItemSlot.Context.EquipMinecart:
                    pos = 7;
                    break;
                case ItemSlot.Context.EquipPet:
                    pos = 10;
                    break;
                case ItemSlot.Context.EquipLight:
                    pos = 17;
                    break;
                default:
                    return Rectangle.Empty;
            }

            Rectangle rectangle = Main.extraTexture[54].Frame(3, 6, pos % 3, pos / 3);
            rectangle.Width -= 2;
            rectangle.Height -= 2;

            return rectangle;
        }

        /// <summary>
        /// Get the hover text of a slot based on its context and the current language.
        /// </summary>
        /// <param name="context">context of the slot</param>
        /// <returns>text in current language</returns>
        public static string GetHoverText(int context) {
            switch(context) {
                case ItemSlot.Context.EquipAccessory:
                    return Language.GetTextValue("LegacyInterface.9");
                case ItemSlot.Context.EquipAccessoryVanity:
                    return Language.GetTextValue("LegacyInterface.11") + " " + Language.GetTextValue("LegacyInterface.9");
                case ItemSlot.Context.EquipDye:
                    return Language.GetTextValue("LegacyInterface.57");
                case ItemSlot.Context.EquipGrapple:
                    return Language.GetTextValue("LegacyInterface.90");
                case ItemSlot.Context.EquipLight:
                    return Language.GetTextValue("LegacyInterface.94");
                case ItemSlot.Context.EquipMinecart:
                    return Language.GetTextValue("LegacyInterface.93");
                case ItemSlot.Context.EquipMount:
                    return Language.GetTextValue("LegacyInterface.91");
                case ItemSlot.Context.EquipPet:
                    return Language.GetTextValue("LegacyInterface.92");
                case ItemSlot.Context.InventoryAmmo:
                    return Language.GetTextValue("LegacyInterface.27");
                case ItemSlot.Context.InventoryCoin:
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
