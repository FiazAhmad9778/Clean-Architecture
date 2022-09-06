using System.Net.Mail;
using System.Security.Authentication;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace iHakeem.Infrastructure.Services.TwilioMessanger
{
    public class Messanger : IMessanger
    {
        public Messanger()
        {
        }
        public async Task SendSms(MessageData smsDto)
        {
            TwilioClient.Init(MessageCredentials.testAccountSID, MessageCredentials.testAuthToken);

            await MessageResource.CreateAsync(
                body: smsDto.MessageText,
                from: new Twilio.Types.PhoneNumber(MessageCredentials.SenderPhoneNo),
                to: new Twilio.Types.PhoneNumber(smsDto.PhoneNo)
            );
        }
    }
}
