using System.Net;
using System.Net.Mail;

namespace Hangfire_EmailNotification.Common;


public class SubscribeEmail
{
    public static void SendEmail(string Email, string Username)
    {
        string fromMail = "sanjairock85@gmail.com";
        string senderPass = "vmrc sKxx ihyK jscu";
        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.To.Add(Email);
        message.Subject = $"Special Offer is Going on !!";
        message.Body =
            $"Dear {Username} \r\n\r\n A Special Offer is waiting for you . Quick and Grab your favorite products before they are gone . \r\n\r\n Best Regards \r\n Ungal Nan";
        
        
        // SMPT client 
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromMail, senderPass),
            EnableSsl = true
        };

        smtpClient.Send(message);
    }
}