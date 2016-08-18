using NASASDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAapp.Models
{
    public class ObjectListItem
    {
        public DateTime Key { get; set; }
        public IList<NearEarthObject> ListObjects { get; set; }
    }
}
