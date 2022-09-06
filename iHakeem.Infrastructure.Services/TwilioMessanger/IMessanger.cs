using System.Threading.Tasks;

namespace iHakeem.Infrastructure.Services.TwilioMessanger
{
    public interface IMessanger
    {
        Task SendSms(MessageData data);
    }
}
