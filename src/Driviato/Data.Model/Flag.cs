using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Flag
    {
        public Guid DriverId { get; set; }

        public string Type { get; set; }

        public DateTime Time { get; set; }

        public Position Position { get; set; }

    }

    public struct Position
    {
        public string Description { get; set; }

        public Coordinates Coordinates { get; set; }
    }

    public struct Coordinates
    {
        public double Latitude { get; set; }

        public double Longtitude { get; set; }
    }
}
