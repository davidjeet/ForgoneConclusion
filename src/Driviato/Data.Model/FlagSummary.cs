using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// A Summary of flags.
    /// </summary>
    public class FlagSummary
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Guid DriverId { get; set; }


    }
}
