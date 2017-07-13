using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraUI.Objects;

namespace TerraUI.Utilities {
    public delegate void UIEventHandler(UIObject sender);
    public delegate void ValueChangedEventHandler<T>(UIObject sender, ValueChangedEventArgs<T> e);

    public class ValueChangedEventArgs<T> {
        public T PreviousValue { get; private set; }
        public T Value { get; private set; }

        public ValueChangedEventArgs(T previousValue, T value) {
            PreviousValue = previousValue;
            Value = value;
        }
    }
}
