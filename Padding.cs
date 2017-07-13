using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraUI {
    public struct Padding {
        /// <summary>
        /// The top padding.
        /// </summary>
        public float Top { get; set; }
        /// <summary>
        /// The left padding.
        /// </summary>
        public float Left { get; set; }
        /// <summary>
        /// The bottom padding.
        /// </summary>
        public float Bottom { get; set; }
        /// <summary>
        /// The right padding.
        /// </summary>
        public float Right { get; set; }

        /// <summary>
        /// A Padding instance where top, left, bottom, and right are 0.
        /// </summary>
        public static Padding Zero { get { return new Padding(); } }
        
        /// <summary>
        /// Create a new Padding instance.
        /// </summary>
        /// <param name="padding">padding on all sides</param>
        public Padding(float padding) : this(padding, padding, padding, padding) { }

        /// <summary>
        /// Create a new Padding instance.
        /// </summary>
        /// <param name="topBottom">top and bottom padding</param>
        /// <param name="leftRight">left and right padding</param>
        public Padding(float topBottom, float leftRight) : this(topBottom, leftRight, topBottom, leftRight) { }
        
        /// <summary>
        /// Create a new Padding instance.
        /// </summary>
        /// <param name="top">top padding</param>
        /// <param name="left">left padding</param>
        /// <param name="bottom">bottom padding</param>
        /// <param name="right">right padding</param>
        public Padding(float top, float left, float bottom, float right) {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }
}
