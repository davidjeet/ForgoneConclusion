using Data.Model;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.Api.Infrastructure.DataAccess;

namespace Web.Api.Controllers
{
    public class DriverPositionsController : ApiController
    {
        // GET api/values
        public IEnumerable<DriverPosition> Get()
        {            
            ////var drivers = new []
            ////                  {
            ////                      new DriverPosition
            ////                          {
            ////                              DriverId = Guid.NewGuid(),
            ////                               Latitude= 35.828959f,
            ////                               Longitude= -78.895663f,
            ////                               Altitude=0, Accuracy=1,
            ////                                AltitudeAccuracy=1, Heading=1,
            ////                              Speed=35.1f, TimeStamp=new DateTime(2015, 5, 1, 8, 30, 52, 10)
            ////                          },
            ////                      new DriverPosition
            ////                          {
            ////                              DriverId = Guid.NewGuid(),
            ////                               Latitude= 36.828959f,
            ////                               Longitude= -79.895663f,
            ////                               Altitude=0, Accuracy=1,
            ////                                AltitudeAccuracy=1, Heading=1,
            ////                              Speed=40.2f, TimeStamp=new DateTime(2015, 5, 1, 8, 30, 59, 10)
            ////                          }
                                  

                                  
            ////                  };

            var collection = MongoHelper.Current.Database.GetCollection<DriverPosition>("driverpositions");
            var list = collection.FindAll();
            return list;
        }

        // GET api/values/5
        public DriverPosition Get(string driverId)
        {
            ////var driverPosition =  new DriverPosition
            ////           {
            ////               DriverId = Guid.NewGuid(),
            ////               Latitude = 36.828959f,
            ////               Longitude = -79.895663f,
            ////               Altitude = 0,
            ////               Accuracy = 1,
            ////               AltitudeAccuracy = 1,
            ////               Heading = 1,
            ////               Speed = 40.2f,
            ////               TimeStamp = new DateTime(2015, 5, 1, 8, 30, 59, 10)
                       ////};
            var collection = MongoHelper.Current.Database.GetCollection<DriverPosition>("driverpositions");
            var item = collection.AsQueryable().FirstOrDefault(x => x.DriverId.ToString() == driverId);
            return item;
        }

        // POST api/values
        public void Post([FromBody]DriverPosition driverPosition)
        {
            var  collection = MongoHelper.Current.Database.GetCollection<DriverPosition>("driverpositions");
            collection.Insert(driverPosition);
        }
    }
}
