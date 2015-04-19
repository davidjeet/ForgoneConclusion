
#r "C:\Users\jamie\Desktop\4Gone.DriveSafe.Analytics\packages\Sendgrid.5.1.0\lib\SendGridMail.dll"
#r "C:/Users/jamie/Desktop/4Gone.DriveSafe.Analytics/packages/SendGrid.SmtpApi.1.2.1/lib/net40/SendGrid.SmtpApi.dll"

open System
open System.Collections.Generic
open System.Net
open System.Net.Mail
open SendGrid

let message = new SendGridMessage()
message.From <- new MailAddress("jamie@4Gone.com")
let recipients = new List<string>()
recipients.Add("ian@cillay.com")
recipients.Add("davidgreen24@gmail.com")
recipients.Add("ian.henshaw@gmail.com")
message.AddTo(recipients)

message.Subject <- "Testing the SendGrid Library"
message.Html <- "<p>Hello 4Gone!</p>"
message.Text <- "Hello 4Gone plain text!"

let username = "jamie,dixon";
let pswd = "1q2w3e4r";
let credentials = new NetworkCredential(username, pswd);
let transportWeb = new Web(credentials);

try
    let mailResult = transportWeb.Deliver(message);
    ()
with
    | :? Exceptions.InvalidApiRequestException as ex -> ex.Errors |>  Seq.iter( fun e -> printfn "Exception! %s " e)


