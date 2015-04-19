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

        /// <summary>
        /// Creates the specified customer w/ a credit card.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void Post([FromBody]Customer customer)
        {
            
            var gateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "rfv2xwcbcwrpdnqk",
                PublicKey = "qgyf3xzzv3y9rczd",
                PrivateKey = "765479fccc7bae123b912ca23206fe09"
            };

            var customerRequest = new CustomerRequest
                                      {
                                          Email = customer.Email,
                                          FirstName = customer.FirstName,
                                          LastName = customer.LastName,
                                          CreditCard = new Braintree.CreditCardRequest
                                                           {
                                                               Number = customer.Number,
                                                               ExpirationDate = customer.ExpirationDate,                                                               
                                                           }
                                      };


            var result = gateway.Customer.Create(customerRequest);
            var target = result.Target;

            customer.Id = target.Id;
            customer.BraintreePaymentToken = target.PaymentMethods[0].Token;
           
            var collection = MongoHelper.Current.Database.GetCollection<Customer>("customers");
            collection.Insert(customer);
        }
    }
}
