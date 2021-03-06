﻿using Braintree;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Web.Http;
using Web.Api.Infrastructure.DataAccess;
using Customer = Data.Model.Customer;
using Environment = Braintree.Environment;

namespace Web.Api.Controllers
{
    public class BrainTreeTransactionController : ApiController
    {

        public bool Post([FromBody]TransactionInfo transactionInfo)
        {
            Result<Transaction> tresult = null;
            var gateway = new BraintreeGateway()
            {
                Environment = Environment.SANDBOX,
                MerchantId = "rfv2xwcbcwrpdnqk",
                PublicKey = "qgyf3xzzv3y9rczd",
                PrivateKey = "765479fccc7bae123b912ca23206fe09"
            };

            // Retreive from mongo and make a transaction when I want to
            var collection2 = MongoHelper.Current.Database.GetCollection<Customer>("customers");
            var customer = collection2.AsQueryable().FirstOrDefault(x => x.Id == transactionInfo.CustomerId);
            if (customer != null)
            {
                var trequest = new TransactionRequest
                {
                    Amount = Convert.ToDecimal(transactionInfo.Amount),
                    CustomerId = customer.Id,
                    PaymentMethodToken = customer.BraintreePaymentToken
                };

                tresult = gateway.Transaction.Sale(trequest);
                if (tresult.IsSuccess())
                {
                    Console.WriteLine("Yes!!!! " + tresult.Message);
                }
            }

            return (tresult != null) ? tresult.IsSuccess() : false;
        }

        public class TransactionInfo
        {
            public string CustomerId { get; set; }
            public double Amount { get; set; }
        }
    }
}
