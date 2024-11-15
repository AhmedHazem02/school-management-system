using MailKit.Net.Smtp;
using MimeKit;
using SchoolProject.Data.Helpers;
using SchoolProject.service.Abstracts;
namespace SchoolProject.service.Impelemetions
{
    public class EmailServices : IEmailServices
    {

        #region Fields
        private readonly EmailSetting _emailSettings;
        #endregion
        #region Constructors
        public EmailServices(EmailSetting emailSettings)
        {
            _emailSettings = emailSettings;
        }

        #endregion
        #region Handle Functions
        public async Task<string> SendEmailAsync(string email, string Message )
        {
            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject =   "No Submitted";
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
        #endregion
    }
}
