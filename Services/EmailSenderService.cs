using System;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BarberBooking.Services
{
    public class EmailSenderService : IEmailSender
    {
        private AuthEmailSenderOptions Options { get; }

        public EmailSenderService(IOptions<AuthEmailSenderOptions> options)
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

            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}