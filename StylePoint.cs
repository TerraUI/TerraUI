using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace TerraUI {
    public struct StylePoint {
        /// <summary>
        /// The x-coordinate.
        /// </summary>
        public StyleDimension X { get; set; }
        /// <summary>
        /// The y-coordinate.
        /// </summary>
        public StyleDimension Y { get; set; }

        /// <summary>
        /// A StylePoint where X and Y are 0.
        /// </summary>
        public static StylePoint Zero { get { return new StylePoint(); } }
        
        /// <summary>
        /// Create a new StylePoint.
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        public StylePoint(StyleDimension x, StyleDimension y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Create a new StylePoint.
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        public StylePoint(float x, float y) {
            X = new StyleDimension(x, 0);
            Y = new StyleDimension(y, 0);
        }

        /// <summary>
        /// Create a new StylePoint.
        /// </summary>
        /// <param name="vector">vector to convert</param>
        public StylePoint(Vector2 vector) {
            X = new StyleDimension(vector.X, 0);
            Y = new StyleDimension(vector.Y, 0);
        }

        /// <summary>
        /// Create a new StylePoint.
        /// </summary>
        /// <param name="size">x- and y-coordinate</param>
        public StylePoint(float xy) {
            X = new StyleDimension(xy, 0);
            Y = new StyleDimension(xy, 0);
        }
        
        /// <summary>
        /// Multiply a StylePoint by a float value.
        /// </summary>
        public static StylePoint operator *(StylePoint point, float value) {
            return new StylePoint(point.X.Pixels * value, point.Y.Pixels * value);
        }
    }
}
