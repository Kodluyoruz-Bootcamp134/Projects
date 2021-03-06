using Base.Common.Const;
using RabbitMQ.Client;

namespace Base.Projections.UserService
{
    public class RabbitMQClientService : IDisposable
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IConfiguration configuration;

        public RabbitMQClientService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IModel Connect()
        {
            var connectionFactory = new ConnectionFactory() { HostName = configuration.GetSection("RabbitMQ").Value, DispatchConsumersAsync = true };

            _connection = connectionFactory.CreateConnection();

            if (_channel is { IsOpen: true })
            {
                return _channel;
            }

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(MailSendEventConst.ExchangeName, type: ExchangeType.Direct, true, false);
            _channel.QueueDeclare(MailSendEventConst.QueueName, true, false, false, null);
            _channel.QueueBind(MailSendEventConst.QueueName, MailSendEventConst.ExchangeName, MailSendEventConst.RouteKey);

            return _channel;
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}