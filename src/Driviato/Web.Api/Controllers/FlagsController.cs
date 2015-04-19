using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Api.Controllers
{
    using Data.Model;

    using Web.Api.Infrastructure.DataAccess;

    public class FlagsController : ApiController
    {
        // POST api/values
        public void Post([FromBody]Flag [] flags)
        {
            var collection = MongoHelper.Current.Database.GetCollection<DriverPosition>("driverpositions");
            foreach (var item in flags)
            {
                var driverPosition = new DriverPosition
                                        {
                                            DriverId = item.CustomerId,
                                            Latitude = item.Position.Coordinates.Latitude,
                                            Longitude = item.Position.Coordinates.Longtitude,
                                            Altitude = item.Altitude,
                                            AltitudeAccuracy = item.AltitudeAccuracy,
                                            TimeStamp = item.Time,
                                            Heading = item.Heading,
                                          ////Type = item.Type,
                                          };
                collection.Insert(driverPosition);
            }

        }
    }
}
