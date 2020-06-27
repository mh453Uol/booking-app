using System;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace BarberBooking.Services
{
    public class EmailSender : IEmailSender
    {
        private AuthEmailSenderOptions Options { get; }

        public EmailSender(IOptions<AuthEmailSenderOptions> options)
        {
            this.Options = options.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var sender = new SendGridSender(Options.ApiKey);

            Email.DefaultSender = sender;

            var response = await Email.From(Options.From)
                .To(email)
                .Subject(subject)
                .Body(htmlMessage, true)
                .SendAsync();

            Console.WriteLine(response);
        }
    }
}