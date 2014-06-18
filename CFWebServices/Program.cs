using System;

namespace CFWebServices
{
    class Program
    {
        static void Main(string[] args)
        {
            const String FROM = "SENDER@EXAMPLE.COM";   // Replace with your "From" address. This address must be verified.
            const String TO = "RECIPIENT@EXAMPLE.COM";  // Replace with a "To" address. If you have not yet requested
            // production access, this address must be verified.

            const String SUBJECT = "Amazon SES test (SMTP interface accessed using C#)";
            const String BODY = "This email was sent through the Amazon SES SMTP interface by using C#.";

            // Supply your SMTP credentials below. Note that your SMTP credentials are different from your AWS credentials.
            const String SMTP_USERNAME = "YOUR_SMTP_USERNAME";  // Replace with your SMTP username. 
            const String SMTP_PASSWORD = "YOUR_SMTP_PASSWORD";  // Replace with your SMTP password.

            // Amazon SES SMTP host name. This example uses the us-east-1 region.
            const String HOST = "email-smtp.us-west-2.amazonaws.com";

            // Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
            // STARTTLS to encrypt the connection.
            const int PORT = 2587;

            // Create an SMTP client with the specified host name and port.
            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Create a network credential with your SMTP user name and password.
                client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
                // the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
                client.EnableSsl = true;

                // Send the email. 
                try
                {
                    Console.WriteLine("Attempting to send an email through the Amazon SES SMTP interface...");
                    client.Send(FROM, TO, SUBJECT, BODY);
                    Console.WriteLine("Email sent!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}