﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;

namespace TerraUI.Utilities {
    public static class MouseUtils {
        private static int[] framesHeld = { 0, 0, 0, 0, 0 };
        
        /// <summary>
        /// The mouse position rectangle.
        /// </summary>
        public static Rectangle Rectangle {
            get { return new Rectangle(Main.mouseX, Main.mouseY, 1, 1); }
        }

        /// <summary>
        /// The mouse position.
        /// </summary>
        public static Vector2 Position {
            get { return new Vector2(Main.mouseX, Main.mouseY); }
        }

        /// <summary>
        /// Update the current state of held buttons.
        /// </summary>
        internal static void UpdateState() {
            foreach(MouseButtons button in Enum.GetValues(typeof(MouseButtons))) {
                if(button != MouseButtons.None) {
                    if(JustPressed(button) || HeldDown(button)) {
                        framesHeld[(int)button]++;
                    }
                    else {
                        framesHeld[(int)button] = 0;
                    }
                }
            }
        }
        
        /// <summary>
        /// Check if a button was just pressed.
        /// </summary>
        /// <param name="mouseButton">button to check</param>
        /// <returns>whether button was just pressed</returns>
        public static bool JustPressed(MouseButtons mouseButton) {
            PlayerInput.
            if(GetButtonState(mouseButton, PlayerInput.MouseInfoOld) == ButtonState.Released &&
               GetButtonState(mouseButton, PlayerInput.MouseInfo) == ButtonState.Pressed) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a button was just released.
        /// </summary>
        /// <param name="mouseButton">button to check</param>
        /// <returns>whether button was just released</returns>
        public static bool JustReleased(MouseButtons mouseButton) {
            if(GetButtonState(mouseButton, PlayerInput.MouseInfoOld) == ButtonState.Pressed &&
               GetButtonState(mouseButton, PlayerInput.MouseInfo) == ButtonState.Released) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a button is held down.
        /// </summary>
        /// <param name="mouseButton">button to check</param>
        /// <param name="frames">how many frames the button must be held down before returning true</param>
        /// <returns>whether button is held down</returns>
        public static bool HeldDown(MouseButtons mouseButton) {
            if(GetButtonState(mouseButton, PlayerInput.MouseInfoOld) == ButtonState.Pressed &&
               GetButtonState(mouseButton, PlayerInput.MouseInfo) == ButtonState.Pressed &&
               framesHeld[(int)mouseButton] > 1) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if any button has just been pressed.
        /// </summary>
        /// <returns>whether any button has just been pressed</returns>
        public static bool AnyButtonPressed() {
            foreach(MouseButtons button in Enum.GetValues(typeof(MouseButtons))) {
                if(JustPressed(button)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if any button has just been pressed.
        /// </summary>
        /// <param name="pressedButton">pressed button</param>
        /// <returns>whether any button has just been pressed</returns>
        public static bool AnyButtonPressed(out MouseButtons pressedButton) {
            foreach(MouseButtons button in Enum.GetValues(typeof(MouseButtons))) {
                if(JustPressed(button)) {
                    pressedButton = button;
                    return true;
                }
            }

            pressedButton = MouseButtons.None;
            return false;
        }

        /// <summary>
        /// Check if any button has just been released.
        /// </summary>
        /// <returns>whether any button has just been released</returns>
        public static bool AnyButtonReleased() {
            foreach(MouseButtons button in Enum.GetValues(typeof(MouseButtons))) {
                if(JustReleased(button)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if any button has just been released.
        /// </summary>
        /// <param name="releasedButton">released button</param>
        /// <returns>whether any button has just been released</returns>
        public static bool AnyButtonReleased(out MouseButtons releasedButton) {
            foreach(MouseButtons button in Enum.GetValues(typeof(MouseButtons))) {
                if(JustReleased(button)) {
                    releasedButton = button;
                    return true;
                }
            }

            releasedButton = MouseButtons.None;
            return false;
        }

        /// <summary>
        /// Check if any button has been held down.
        /// </summary>
        /// <returns>whether any button has been held down</returns>
        public static bool AnyButtonHeldDown() {
            foreach(int idx in framesHeld) {
                if(framesHeld[idx] > 1) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if any button has been held down.
        /// </summary>
        /// <param name="heldButton">held button</param>
        /// <returns>whether any button has been held down</returns>
        public static bool AnyButtonHeldDown(out MouseButtons heldButton) {
            foreach(int idx in framesHeld) {
                if(framesHeld[idx] > 1) {
                    heldButton = (MouseButtons)idx;
                    return true;
                }
            }

            heldButton = MouseButtons.None;
            return false;
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
    }
}
