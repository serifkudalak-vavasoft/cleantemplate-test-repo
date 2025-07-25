using TestProject.Application.Models.Mail;

namespace TestProject.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
