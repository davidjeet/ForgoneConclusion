
#r "C:\Users\jamie\Desktop\4Gone.DriveSafe.Analytics\packages\Braintree.2.40.0\lib\Braintree-2.40.0.dll"

open System
open Braintree

let gateway = new BraintreeGateway()
gateway.Environment <- Environment.SANDBOX
gateway.MerchantId <- "rfv2xwcbcwrpdnqk"
gateway.PublicKey <- "qgyf3xzzv3y9rczd"
gateway.PrivateKey <- "765479fccc7bae123b912ca23206fe09"

//POST
let customerRequest = new CustomerRequest()
customerRequest.FirstName <- "Mark"
customerRequest.LastName <- "Jones"
customerRequest.Company <- "Jones Co."
customerRequest.Email <- "mark.jones@example.com"
customerRequest.Fax <- "419-555-1234"
customerRequest.Phone <- "614-555-1234"
customerRequest.Website <- "http://example.com"
let customer = gateway.Customer.Create(customerRequest)

//GET
let tokenRequest = new ClientTokenRequest()
tokenRequest.CustomerId <- customer.Target.Id
let token = gateway.ClientToken.generate(tokenRequest)

//POST
let transaction = new TransactionRequest()
transaction.Amount <- 100.M
transaction.PaymentMethodNonce <- "nonce-from-the-client"
let result = gateway.Transaction.Sale(transaction);
result.Target.Id
