using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace TerraUI {
    public delegate void FocusHandler(UIObject sender);
    public delegate bool ClickHandler(UIObject sender, ClickEventArgs e);
    public delegate void StepHandler(UIObject sender);
    public delegate void DrawHandler(UIObject sender, SpriteBatch spriteBatch);
    public delegate bool ConditionHandler(Item item);
    public delegate bool ValueChanged<T>(UIObject sender, ValueChangedEventArgs<T> e);

    public class ValueChangedEventArgs<T> {
        public T PreviousValue { get; private set; }
        public T Value { get; private set; }

        public ValueChangedEventArgs(T previousValue, T value) {
            PreviousValue = previousValue;
            Value = value;
        }
    }

    public class ClickEventArgs {
        public Vector2 Position { get; private set; }

        public ClickEventArgs(Vector2 position) {
            Position = position;
        }
    }
}
