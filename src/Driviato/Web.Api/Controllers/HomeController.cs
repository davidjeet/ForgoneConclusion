using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Api.Controllers
{
    using System.Threading.Tasks;

    using Braintree;

    using Data.Model;

    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    using Web.Api.Infrastructure.DataAccess;

    using Customer = Data.Model.Customer;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ////var gateway = new BraintreeGateway()
            ////{
            ////    Environment = Environment.SANDBOX,
            ////    //MerchantId = "fjt77jqq47hjp38t",
            ////    //PublicKey = "2nhjdvr59jntwyqy",
            ////    //PrivateKey = "25cb8f94bd79f0a4093d6e9e3eb38de5"
            ////    MerchantId = "rfv2xwcbcwrpdnqk",
            ////    PublicKey = "qgyf3xzzv3y9rczd",
            ////    PrivateKey = "765479fccc7bae123b912ca23206fe09"
            ////};

            ////// 1. create new customer in braintree
            ////var request = new CustomerRequest
            ////{
            ////    FirstName = "David",
            ////    LastName = "Green",
            ////    CreditCard = new CreditCardRequest
            ////    {
            ////        Number = "4111111111111111",
            ////        ExpirationDate = "05/2020",
            ////        BillingAddress = new CreditCardAddressRequest
            ////        {
            ////            StreetAddress = "1 E Main St",
            ////            ExtendedAddress = "Unit 2",
            ////            Locality = "Chicago",
            ////            Region = "Illinois",
            ////            PostalCode = "60607",
            ////            CountryCodeAlpha2 = "US"
            ////        }
            ////    }
            ////};

            ////var result = gateway.Customer.Create(request);
            ////var target = result.Target;
            //////string streetAddress = customer.CreditCards[0].BillingAddress.StreetAddress;



            ////// 2. add to mongo
            ////var customer2 = new Customer
            ////                        {
            ////                            Id = target.Id,
            ////                            BraintreePaymentToken = target.PaymentMethods[0].Token,
            ////                            FirstName = "David",
            ////                            LastName = "Green"
            ////                        };
            ////var collection = MongoHelper.Current.Database.GetCollection<Customer>("customers");
            ////collection.Insert(customer2);


            //////3. retreive from mongo and make a transaction when I want to
            ////var collection2 = MongoHelper.Current.Database.GetCollection<Customer>("customers");
            ////var customer = collection2.AsQueryable().FirstOrDefault(x => x.Id == target.Id);
            ////if (customer != null)
            ////{
            ////    var trequest = new TransactionRequest
            ////    {
            ////        Amount = 10.00M,
            ////        CustomerId = customer.Id,
            ////        PaymentMethodToken = customer.BraintreePaymentToken
            ////    };

            ////    Result<Transaction> tresult = gateway.Transaction.Sale(trequest);
            ////    if (result.IsSuccess())
            ////    {
            ////        Console.WriteLine("Yes!!!! " + tresult.Message);
            ////    }
            ////}


            return View();
        }

        public ActionResult TestGetAllDriverPositions()
        {
            var collection = MongoHelper.Current.Database.GetCollection<DriverPosition>("driverpositions");
            var list = collection.AsQueryable().ToList();
            return View(list.ToArray());
        }


        public ActionResult TestPostDriverPosition()
        {
            var driverPosition = new DriverPosition
                       {
                           DriverId = "123465",
                           Latitude = 36.828959f,
                           Longitude = -79.895663f,
                           Altitude = 0,
                           Accuracy = 1,
                           AltitudeAccuracy = 2,
                           Heading = 1,
                           Speed = 40.2f,
                           TimeStamp = DateTime.Now
                       };
            var collection = MongoHelper.Current.Database.GetCollection<DriverPosition>("driverpositions");
            collection.Insert(driverPosition);
            return View(driverPosition);
        }
    }
}
