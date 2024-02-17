using Notification.Server.Models;

namespace Notification.Server.Services.Interface
{
    public interface IEmailService
    {
        Task<Response<EmailModel>> SendEmailNotificationAsync(EmailModel fileName);
    }
}
