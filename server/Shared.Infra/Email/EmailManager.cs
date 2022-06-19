using System.Net;
using System.Net.Mail;

namespace Shared.Infra.Email
{
    public class EmailManager
    {
        public static async Task SendVerificationEmail(string userEmail, string userName, string body)
        {
            var email = Environment.GetEnvironmentVariable("EMAIL");
            var pwd = Environment.GetEnvironmentVariable("PWD");
            var host = Environment.GetEnvironmentVariable("HOST");
            var url = $"http://localhost:4200/verification/{body}";
            using var smtpClient = new SmtpClient(host)
            {
                Port = 587,
                Credentials = new NetworkCredential(email, pwd),
                EnableSsl = true,
            };
            await smtpClient.SendMailAsync(email, userEmail, $"Hello {userName}", url);
        }
    }
}
