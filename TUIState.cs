using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.UI;
using TerraUI.Elements;
using TerraUI.Utils;

namespace TerraUI {
    public class TUIState : Terraria.UI.UIState {
        public bool Visible { get; set; }

        private bool _wasMouseMiddleDown;
        private bool _wasMouseXButton1Down;
        private bool _wasMouseXButton2Down;

        private TUIElement _lastObjectMiddleDown;
        private TUIElement _lastObjectXButton1Down;
        private TUIElement _lastObjectXButton2Down;

        private TUIElement _lastObjectMiddleClicked;
        private TUIElement _lastObjectXButton1Clicked;
        private TUIElement _lastObjectXButton2Clicked;

        private double _lastMouseMiddleDownTime;
        private double _lastMouseXButton1DownTime;
        private double _lastMouseXButton2DownTime;

        private double _clickDisabledTimeRemaining;

        public override void OnActivate() {
            Visible = true;
        }

        public override void OnDeactivate() {
            Visible = false;
        }

        public override void Update(GameTime time) {
            if(Visible) {
                Vector2 mouse = Main.MouseScreen;

                UIElement elem = GetElementAt(mouse);
                TUIElement uiObject = elem as TUIElement;

                bool middle = (TUIMouseUtils.State.MiddleButton == ButtonState.Pressed);
                bool xButton1 = (TUIMouseUtils.State.XButton1 == ButtonState.Pressed);
                bool xButton2 = (TUIMouseUtils.State.XButton2 == ButtonState.Pressed);

                _clickDisabledTimeRemaining = Math.Max(0.0, _clickDisabledTimeRemaining - time.ElapsedGameTime.TotalMilliseconds);
                bool disabled = (_clickDisabledTimeRemaining > 0.0);

                if(middle && !_wasMouseMiddleDown && uiObject != null && !disabled) {
                    _lastObjectMiddleDown = uiObject;
                    uiObject.MiddleMouseDown(new UIMouseEvent(uiObject, mouse));

                    if(_lastObjectMiddleClicked == uiObject && (time.TotalGameTime.TotalMilliseconds - _lastMouseMiddleDownTime) < 500.0) {
                        uiObject.MiddleDoubleClick(new UIMouseEvent(uiObject, mouse));
                        _lastObjectMiddleClicked = null;
                    }

                    _lastMouseMiddleDownTime = time.TotalGameTime.TotalMilliseconds;
                }
                else if(!middle && _wasMouseMiddleDown && _lastObjectMiddleDown != null && !disabled) {
                    TUIElement lastObjectMiddleDown = _lastObjectMiddleDown;

                    if(lastObjectMiddleDown.ContainsPoint(mouse)) {
                        lastObjectMiddleDown.MiddleClick(new UIMouseEvent(lastObjectMiddleDown, mouse));
                        _lastObjectMiddleClicked = _lastObjectMiddleDown;
                    }

                    lastObjectMiddleDown.MouseUp(new UIMouseEvent(lastObjectMiddleDown, mouse));
                    _lastObjectMiddleDown = null;
                }

                if(xButton1 && !_wasMouseXButton1Down && uiObject != null && !disabled) {
                    _lastObjectXButton1Down = uiObject;
                    uiObject.XButton1MouseDown(new UIMouseEvent(uiObject, mouse));
                    if(_lastObjectXButton1Clicked == uiObject && (time.TotalGameTime.TotalMilliseconds - _lastMouseXButton1DownTime) < 500.0) {
                        uiObject.XButton1DoubleClick(new UIMouseEvent(uiObject, mouse));
                        _lastObjectXButton1Clicked = null;
                    }
                    _lastMouseXButton1DownTime = time.TotalGameTime.TotalMilliseconds;
                }
                else if(!xButton1 && _wasMouseXButton1Down && _lastObjectXButton1Down != null && !disabled) {
                    TUIElement lastObjectXButton1Down = _lastObjectXButton1Down;
                    if(lastObjectXButton1Down.ContainsPoint(mouse)) {
                        lastObjectXButton1Down.XButton1Click(new UIMouseEvent(lastObjectXButton1Down, mouse));
                        _lastObjectXButton1Clicked = _lastObjectXButton1Down;
                    }
                    lastObjectXButton1Down.MouseUp(new UIMouseEvent(lastObjectXButton1Down, mouse));
                    _lastObjectXButton1Down = null;
                }

                if(xButton2 && !_wasMouseXButton2Down && uiObject != null && !disabled) {
                    _lastObjectXButton2Down = uiObject;
                    uiObject.XButton2MouseDown(new UIMouseEvent(uiObject, mouse));
                    if(_lastObjectXButton2Clicked == uiObject && (time.TotalGameTime.TotalMilliseconds - _lastMouseXButton2DownTime) < 500.0) {
                        uiObject.XButton2DoubleClick(new UIMouseEvent(uiObject, mouse));
                        _lastObjectXButton2Clicked = null;
                    }
                    _lastMouseXButton2DownTime = time.TotalGameTime.TotalMilliseconds;
                }
                else if(!xButton2 && _wasMouseXButton2Down && _lastObjectXButton2Down != null && !disabled) {
                    TUIElement lastObjectXButton2Down = _lastObjectXButton2Down;
                    if(lastObjectXButton2Down.ContainsPoint(mouse)) {
                        lastObjectXButton2Down.XButton2Click(new UIMouseEvent(lastObjectXButton2Down, mouse));
                        _lastObjectXButton2Clicked = _lastObjectXButton2Down;
                    }
                    lastObjectXButton2Down.MouseUp(new UIMouseEvent(lastObjectXButton2Down, mouse));
                    _lastObjectXButton2Down = null;
                }

                _wasMouseMiddleDown = middle;
                _wasMouseXButton1Down = xButton1;
                _wasMouseXButton2Down = xButton2;
            }

            TUIUtils.UpdateInput();
        }
    }
}
