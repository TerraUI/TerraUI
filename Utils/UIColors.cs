using Microsoft.Xna.Framework;

namespace TerraUI.Utilities {
    public static class UIColors {
        public static class ProgressBar {
            public static readonly Color BackColor = UIColors.BackColor;
            public static readonly Color BarColor = Color.White;
            public static readonly Color BorderColor = Color.White;
        }

        public static readonly Color LightBackColor = new Color(100, 102, 190);
        public static readonly Color LightBackColorTransparent = new Color(100, 102, 190) * 0.7f;
        public static readonly Color DarkBackColor = new Color(63, 65, 151);
        public static readonly Color DarkBackColorTransparent = new Color(63, 65, 151) * 0.7f;
        public static readonly Color BackColor = new Color(63, 82, 151);
        public static readonly Color BackColorTransparent = new Color(63, 82, 151) * 0.7f;
    }
}
