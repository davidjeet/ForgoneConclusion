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
        public void Post([FromBody]DriverPosition driverPosition)
        {
            var collection = MongoHelper.Current.Database.GetCollection<DriverPosition>("driverpositions");
            collection.Insert(driverPosition);
        }
    }
}
