using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;

namespace BarberBooking.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender sender;
        private readonly IHttpContextAccessor accessor;
        private readonly LinkGenerator generator;

        public EmailService(IEmailSender sender, IHttpContextAccessor accessor, LinkGenerator generator)
        {
            this.sender = sender;
            this.accessor = accessor;
            this.generator = generator;
        }
        public async Task SendEmailConfirmation(string code, string userId, string email)
        {
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = this.generator.GetUriByPage(accessor.HttpContext,
                "/Account/ConfirmEmail",
                handler: null,
                values: new { area = "Identity", userId = userId, code = code });

            await sender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }
        public async Task SendEmailChangeConfirmation(string code, string userId, string email)
        {
            var callbackUrl = this.generator.GetUriByPage(accessor.HttpContext,
                     "/Account/ConfirmEmailChange",
                     handler: null,
                     values: new { userId = userId, email = email, code = code });

            await sender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }
    }
}