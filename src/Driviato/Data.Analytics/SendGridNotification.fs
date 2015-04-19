namespace Data.Analytics

open System
open System.Collections.Generic
open System.Net
open System.Net.Mail
open SendGrid
open Data.Model

type SendGridNotification() = 
    interface INotificaton with 
        member this.SendEmail(recipient, subject, body) = 
            let message = new SendGridMessage()
            message.From <- new MailAddress("admin@4Gone.com")
            let recipients = new List<string>()
            recipients.Add(recipient)
            message.AddTo(recipients)

            message.Subject <- subject
            message.Html <- "<p>" + body + "</p>"
            message.Text <- body

            let username = "jamie,dixon";
            let pswd = "1q2w3e4r";
            let credentials = new NetworkCredential(username, pswd);
            let transportWeb = new Web(credentials);

            try
                let mailResult = transportWeb.Deliver(message);
                ()
            with
                | :? Exceptions.InvalidApiRequestException as ex -> ex.Errors |>  Seq.iter( fun e -> printfn "Exception! %s " e)

