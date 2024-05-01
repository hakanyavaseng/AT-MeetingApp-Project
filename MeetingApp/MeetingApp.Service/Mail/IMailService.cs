using AutoMapper.Internal;

namespace MeetingApp.Service.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
