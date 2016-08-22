using System;
using Windows.UI.Xaml.Controls;

namespace NASAapp.Models
{
    public class MenuItem
    {
        private Symbol icon;

        public char Glyph { get; set; }
        public Symbol Icon
        {
            get
            {
                return icon;
            }
            set { icon = value; }
        }
        public string Label { get; set; }
        public Type Destination { get; set; }
    }
}
