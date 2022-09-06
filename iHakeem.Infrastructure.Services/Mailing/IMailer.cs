using System.Threading.Tasks;

namespace iHakeem.Infrastructure.Services.Mailing
{
    public interface IMailer
    {
        Task Send(MailData data);
    }
}
