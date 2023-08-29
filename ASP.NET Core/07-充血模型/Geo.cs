using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_充血模型
{
    public record Geo
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public Geo(double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}
