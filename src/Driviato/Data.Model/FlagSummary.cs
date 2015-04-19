using System;

namespace Data.Model
{
    /// <summary>
    /// A Summary of flags. (this object should never hit MongoDB directly. 
    /// It should be transformed into a driverposition object which is transformed!)
    /// </summary>
    public class FlagSummary
    {
        public string CustomerId { get; set; }

        public string Type { get; set; }

        public DateTime Time { get; set; }

        public Position Position { get; set; }
    }

    public class Position
    {
        public Position(string description, double lat, double lng)
        {
            Description = description ?? "";
            Coordinates = new Coordinates { Latitude = lat, Longtitude = lng };

        }

        public string Description { get; set; }

        public Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        public double Latitude { get; set; }

        public double Longtitude { get; set; }
    }
}
