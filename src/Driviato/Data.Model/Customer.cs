using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class Customer
    {
        ////[BsonRepresentation(BsonType.ObjectId)]
        [BsonIdAttribute] 
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BraintreePaymentToken { get; set; } // "62n3ng"


        public string Number { get; set; } //"4111111111111111",

        public string ExpirationDate { get; set; } //"05/2020",


        public string StreetAddress { get; set; } // "1 E Main St",
        public string ExtendedAddress { get; set; } // "Unit 2",
        public string Locality { get; set; } // "Chicago",
        public string Region { get; set; } // "Illinois",
        public string PostalCode { get; set; } // "60607",
        public string CountryCodeAlpha2 { get; set; } // "US"


        ////public PaymentHistory PaymentHistory  { get; set; }
    }
}
