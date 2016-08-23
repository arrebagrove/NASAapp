using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAapp.Models
{
    public class AstronomyPictureOfDay
    {
        public DateTime Date { get; set; }
        public string Explanation { get; set; }
        public string HdUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Copyright { get; set; }
    }
}
