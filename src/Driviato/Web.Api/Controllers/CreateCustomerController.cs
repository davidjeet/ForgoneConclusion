using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Api.Controllers
{
    using Braintree;

    using Web.Api.Infrastructure.DataAccess;

    using Customer = Data.Model.Customer;

    public class CreateCustomerController : ApiController
    {
        // POST api/values
        /// <summary>
        /// Posts the specified customer request.
        /// </summary>
        /// <param name="customerRequest">The customer request.</param>
        public void Post([FromBody]CustomerRequest customerRequest)
        {
            var gateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "rfv2xwcbcwrpdnqk",
                PublicKey = "qgyf3xzzv3y9rczd",
                PrivateKey = "765479fccc7bae123b912ca23206fe09"
            };

            var result = gateway.Customer.Create(customerRequest);
            var target = result.Target;

            var customer = new Data.Model.Customer
            {
                Id = target.Id,
                FirstName = target.FirstName,
                LastName = target.LastName,
                BraintreePaymentToken = target.PaymentMethods[0].Token
            };

            var collection = MongoHelper.Current.Database.GetCollection<Customer>("customers");
            collection.Insert(customer);
        }
    }
}
