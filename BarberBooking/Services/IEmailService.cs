using System.Threading.Tasks;

namespace BarberBooking.Services
{
    public interface IEmailService
    {
        Task SendEmailChangeConfirmation(string code, string userId, string email);
        Task SendEmailConfirmation(string code, string userId, string email, string returnUrl = null);
    }
}