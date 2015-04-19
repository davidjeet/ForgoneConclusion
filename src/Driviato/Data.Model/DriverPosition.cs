using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Model
{
    [BsonIgnoreExtraElements]
    public class DriverPosition   
    {
        public ObjectId _id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid DriverId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Altitude { get; set; }

        public double Accuracy { get; set; }

        public double AltitudeAccuracy { get; set; }

        public double Heading { get; set; }

        public double Speed { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime TimeStamp { get; set; }  
    }
}
