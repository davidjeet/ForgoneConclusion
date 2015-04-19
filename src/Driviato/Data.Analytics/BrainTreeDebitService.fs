namespace Data.Analytics

open System
open Braintree
open Data.Model

type BrainTreeDebitService() = 
    interface IDebitService with 
        member this.DebitAccount(customerId, token, amount) = 
            let gateway = new BraintreeGateway()
            gateway.Environment <- Environment.SANDBOX
            gateway.MerchantId <- "rfv2xwcbcwrpdnqk"
            gateway.PublicKey <- "qgyf3xzzv3y9rczd"
            gateway.PrivateKey <- "765479fccc7bae123b912ca23206fe09"

            let transaction = new TransactionRequest()
            transaction.Amount <- amount
            transaction.CustomerId <- customerId
            transaction.PaymentMethodToken <- token
            gateway.Transaction.Sale(transaction) |> ignore

