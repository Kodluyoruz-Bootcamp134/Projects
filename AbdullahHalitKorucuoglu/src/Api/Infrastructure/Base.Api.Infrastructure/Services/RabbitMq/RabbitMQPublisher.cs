using Base.Common.Const;
using Base.Common.Event;
using System.Text;
using System.Text.Json;

namespace Base.Api.Infrastructure.Services
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQClientService _rabbitMQClientService;

        public RabbitMQPublisher(RabbitMQClientService rabbitMQClientService)
        {
            _rabbitMQClientService = rabbitMQClientService;
        }

        public void Publish(MailSendEvent mailSendEvent)
        {
            var channel = _rabbitMQClientService.Connect();

            var bodyString = JsonSerializer.Serialize(mailSendEvent);

            var bodyByte = Encoding.UTF8.GetBytes(bodyString);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(MailSendEventConst.ExchangeName, MailSendEventConst.RouteKey, false, properties, bodyByte);
        }
    }
}