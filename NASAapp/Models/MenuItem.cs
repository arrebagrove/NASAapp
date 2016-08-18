using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAapp.Models
{
    public class MenuItem
    {
        public char Glyph { get; set; }
        public string Label { get; set; }
        public Type Destination { get; set; }
    }
}
