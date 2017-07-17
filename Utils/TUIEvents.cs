using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using TerraUI.Elements;

namespace TerraUI.Utils {
    public delegate void UIEventHandler(TUIElement sender);
    public delegate void ValueChangedEventHandler<T>(TUIElement sender, ValueChangedEventArgs<T> e);
    public delegate bool AcceptedItemHandler(Item item);
    public delegate void DrawHandler(UIElement sender, SpriteBatch spriteBatch);

    public class ValueChangedEventArgs<T> {
        public T PreviousValue { get; private set; }
        public T Value { get; private set; }

        public ValueChangedEventArgs(T previousValue, T value) {
            PreviousValue = previousValue;
            Value = value;
        }
    }
}
