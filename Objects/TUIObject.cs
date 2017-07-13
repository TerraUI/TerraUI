using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.UI;
using TerraUI.Utils;

namespace TerraUI.Objects {
    public class TUIObject : UIElement {
        public event MouseEvent OnMiddleClick;
        public event MouseEvent OnMiddleDoubleClick;
        public event MouseEvent OnMiddleMouseDown;
        public event MouseEvent OnMiddleMouseUp;

        public event MouseEvent OnXButton1Click;
        public event MouseEvent OnXButton1DoubleClick;
        public event MouseEvent OnXButton1MouseDown;
        public event MouseEvent OnXButton1MouseUp;

        public event MouseEvent OnXButton2Click;
        public event MouseEvent OnXButton2DoubleClick;
        public event MouseEvent OnXButton2MouseDown;
        public event MouseEvent OnXButton2MouseUp;

        /// <summary>
        /// The X and Y location of the object.
        /// </summary>
        public StylePoint Location {
            get { return new StylePoint(Left, Top); }
            set {
                Left = value.X;
                Top = value.Y;
            }
        }
        /// <summary>
        /// The width and height of the object on the screen.
        /// </summary>
        public StylePoint Size {
            get { return new StylePoint(Width, Height); }
            set {
                Width = value.X;
                Height = value.Y;
            }
        }
        /// <summary>
        /// The minimum size of the object.
        /// </summary>
        public StylePoint MinSize {
            get { return new StylePoint(MinWidth, MinHeight); }
            set {
                MinWidth = value.X;
                MinHeight = value.Y;
            }
        }
        /// <summary>
        /// The maximum size of the object.
        /// </summary>
        public StylePoint MaxSize {
            get { return new StylePoint(MaxWidth, MaxHeight); }
            set {
                MaxWidth = value.X;
                MaxHeight = value.Y;
            }
        }
        /// <summary>
        /// The padding around the object.
        /// </summary>
        public Padding Padding {
            get { return new Padding(PaddingTop, PaddingLeft, PaddingBottom, PaddingRight); }
            set {
                PaddingTop = value.Top;
                PaddingLeft = value.Left;
                PaddingBottom = value.Bottom;
                PaddingRight = value.Right;
            }
        }
        /// <summary>
        /// The margin around an object.
        /// </summary>
        public Padding Margin {
            get { return new Padding(MarginTop, MarginLeft, MarginBottom, MarginRight); }
            set {
                MarginTop = value.Top;
                MarginLeft = value.Left;
                MarginBottom = value.Bottom;
                MarginRight = value.Right;
            }
        }
        
        /// <summary>
        /// Create a new UIObject.
        /// </summary>
        /// <param name="location">location of the object in pixels</param>
        /// <param name="size">size of the object in pixels</param>
        public TUIObject(StylePoint location = default(StylePoint), StylePoint size = default(StylePoint)) {
            Location = location;
            Size = size;
        }
        
        public virtual void MiddleClick(UIMouseEvent evt) {
            if(OnMiddleClick != null) {
                OnMiddleClick(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).MiddleClick(evt);
                }
                else {
                    Parent.Click(evt);
                }
            }
        }

        public virtual void MiddleDoubleClick(UIMouseEvent evt) {
            if(OnMiddleDoubleClick != null) {
                OnMiddleDoubleClick(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).MiddleDoubleClick(evt);
                }
                else {
                    Parent.DoubleClick(evt);
                }
            }
        }

        public virtual void MiddleMouseUp(UIMouseEvent evt) {
            if(OnMiddleMouseUp != null) {
                OnMiddleMouseUp(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).MiddleMouseUp(evt);
                }
                else {
                    Parent.MouseUp(evt);
                }
            }
        }

        public virtual void MiddleMouseDown(UIMouseEvent evt) {
            if(OnMiddleMouseDown != null) {
                OnMiddleMouseDown(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).MiddleMouseDown(evt);
                }
                else {
                    Parent.MouseDown(evt);
                }
            }
        }

        public virtual void XButton1Click(UIMouseEvent evt) {
            if(OnXButton1Click != null) {
                OnXButton1Click(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton1Click(evt);
                }
                else {
                    Parent.Click(evt);
                }
            }
        }

        public virtual void XButton1DoubleClick(UIMouseEvent evt) {
            if(OnXButton1DoubleClick != null) {
                OnXButton1DoubleClick(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton1DoubleClick(evt);
                }
                else {
                    Parent.DoubleClick(evt);
                }
            }
        }

        public virtual void XButton1MouseUp(UIMouseEvent evt) {
            if(OnXButton1MouseUp != null) {
                OnXButton1MouseUp(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton1MouseUp(evt);
                }
                else {
                    Parent.MouseUp(evt);
                }
            }
        }

        public virtual void XButton1MouseDown(UIMouseEvent evt) {
            if(OnXButton1MouseDown != null) {
                OnXButton1MouseDown(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton1MouseDown(evt);
                }
                else {
                    Parent.MouseDown(evt);
                }
            }
        }

        public virtual void XButton2Click(UIMouseEvent evt) {
            if(OnXButton2Click != null) {
                OnXButton2Click(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton2Click(evt);
                }
                else {
                    Parent.Click(evt);
                }
            }
        }

        public virtual void XButton2DoubleClick(UIMouseEvent evt) {
            if(OnXButton2DoubleClick != null) {
                OnXButton2DoubleClick(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton2DoubleClick(evt);
                }
                else {
                    Parent.DoubleClick(evt);
                }
            }
        }

        public virtual void XButton2MouseUp(UIMouseEvent evt) {
            if(OnXButton2MouseUp != null) {
                OnXButton2MouseUp(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton2MouseUp(evt);
                }
                else {
                    Parent.MouseUp(evt);
                }
            }
        }

        public virtual void XButton2MouseDown(UIMouseEvent evt) {
            if(OnXButton2MouseDown != null) {
                OnXButton2MouseDown(evt, this);
            }

            if(Parent != null) {
                if(Parent.GetType() == typeof(TUIObject)) {
                    ((TUIObject)Parent).XButton2MouseDown(evt);
                }
                else {
                    Parent.MouseDown(evt);
                }
            }
        }
    }
}
