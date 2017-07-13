using Terraria.UI;

namespace TerraUI.Objects {
    public class TUIObject : UIElement {
        /// <summary>
        /// Fires when the middle mouse button is clicked.
        /// </summary>
        public event MouseEvent OnMiddleClick;
        /// <summary>
        /// Fires when the middle mouse button is double clicked.
        /// </summary>
        public event MouseEvent OnMiddleDoubleClick;
        /// <summary>
        /// Fires when the middle mouse button is pressed.
        /// </summary>
        public event MouseEvent OnMiddleMouseDown;
        /// <summary>
        /// Fires when the middle mouse button is released.
        /// </summary>
        public event MouseEvent OnMiddleMouseUp;

        /// <summary>
        /// Fires when the first extra button is clicked.
        /// </summary>
        public event MouseEvent OnXButton1Click;
        /// <summary>
        /// Fires when the first extra button is double clicked.
        /// </summary>
        public event MouseEvent OnXButton1DoubleClick;
        /// <summary>
        /// Fires when the first extra button is pressed.
        /// </summary>
        public event MouseEvent OnXButton1MouseDown;
        /// <summary>
        /// Fires when the first extra button is released.
        /// </summary>
        public event MouseEvent OnXButton1MouseUp;

        /// <summary>
        /// Fires when the second extra button is clicked.
        /// </summary>
        public event MouseEvent OnXButton2Click;
        /// <summary>
        /// Fires when the second extra button is double clicked.
        /// </summary>
        public event MouseEvent OnXButton2DoubleClick;
        /// <summary>
        /// Fires when the second extra button is pressed.
        /// </summary>
        public event MouseEvent OnXButton2MouseDown;
        /// <summary>
        /// Fires when the second extra button is released.
        /// </summary>
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
        /// Create a new object.
        /// </summary>
        /// <param name="location">location of object in pixels</param>
        /// <param name="size">size of object in pixels</param>
        public TUIObject(StylePoint location, StylePoint size) {
            Location = location;
            Size = size;
        }

        /// <summary>
        /// Call the OnMiddleClick event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void MiddleClick(UIMouseEvent evt) {
            if(OnMiddleClick != null) {
                OnMiddleClick(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).MiddleClick(evt);
                }
                else {
                    Parent.Click(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnMiddleDoubleClick event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void MiddleDoubleClick(UIMouseEvent evt) {
            if(OnMiddleDoubleClick != null) {
                OnMiddleDoubleClick(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).MiddleDoubleClick(evt);
                }
                else {
                    Parent.DoubleClick(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnMiddleMouseUp event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void MiddleMouseUp(UIMouseEvent evt) {
            if(OnMiddleMouseUp != null) {
                OnMiddleMouseUp(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).MiddleMouseUp(evt);
                }
                else {
                    Parent.MouseUp(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnMiddleMouseDown event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void MiddleMouseDown(UIMouseEvent evt) {
            if(OnMiddleMouseDown != null) {
                OnMiddleMouseDown(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).MiddleMouseDown(evt);
                }
                else {
                    Parent.MouseDown(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton1Click event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton1Click(UIMouseEvent evt) {
            if(OnXButton1Click != null) {
                OnXButton1Click(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton1Click(evt);
                }
                else {
                    Parent.Click(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton1DoubleClick event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton1DoubleClick(UIMouseEvent evt) {
            if(OnXButton1DoubleClick != null) {
                OnXButton1DoubleClick(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton1DoubleClick(evt);
                }
                else {
                    Parent.DoubleClick(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton1MouseUp event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton1MouseUp(UIMouseEvent evt) {
            if(OnXButton1MouseUp != null) {
                OnXButton1MouseUp(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton1MouseUp(evt);
                }
                else {
                    Parent.MouseUp(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton1MouseDown event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton1MouseDown(UIMouseEvent evt) {
            if(OnXButton1MouseDown != null) {
                OnXButton1MouseDown(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton1MouseDown(evt);
                }
                else {
                    Parent.MouseDown(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton2Click event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton2Click(UIMouseEvent evt) {
            if(OnXButton2Click != null) {
                OnXButton2Click(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton2Click(evt);
                }
                else {
                    Parent.Click(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton2DoubleClick event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton2DoubleClick(UIMouseEvent evt) {
            if(OnXButton2DoubleClick != null) {
                OnXButton2DoubleClick(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton2DoubleClick(evt);
                }
                else {
                    Parent.DoubleClick(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton2MouseUp event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton2MouseUp(UIMouseEvent evt) {
            if(OnXButton2MouseUp != null) {
                OnXButton2MouseUp(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton2MouseUp(evt);
                }
                else {
                    Parent.MouseUp(evt);
                }
            }
        }

        /// <summary>
        /// Call the OnXButton2MouseDown event.
        /// </summary>
        /// <param name="evt">mouse event</param>
        public virtual void XButton2MouseDown(UIMouseEvent evt) {
            if(OnXButton2MouseDown != null) {
                OnXButton2MouseDown(evt, this);
            }

            if(Parent != null) {
                if((Parent as TUIObject) != null) {
                    ((TUIObject)Parent).XButton2MouseDown(evt);
                }
                else {
                    Parent.MouseDown(evt);
                }
            }
        }
    }
}
