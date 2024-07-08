using System.Net;
using System.Net.Mail;

namespace Testique.API.Infrastructure.Services;

/// <summary>
/// Отвечает за отправку писем на почту
/// </summary>
public class EmailSender(IOptions<EmailSettings> emailSettings) : IEmailSender
{
    private readonly EmailSettings _emailSettings = emailSettings.Value;

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };
        mailMessage.To.Add(email);

        using var smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
        smtpClient.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
        smtpClient.EnableSsl = true;

        await smtpClient.SendMailAsync(mailMessage);
    }
}