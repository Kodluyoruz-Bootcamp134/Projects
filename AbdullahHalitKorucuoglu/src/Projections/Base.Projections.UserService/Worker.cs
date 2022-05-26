using Base.Common.Const;
using Base.Common.Event;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Base.Projections.UserService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMailService _mailService;
    private readonly RabbitMQClientService _rabbitMQClientService;
    private IModel _channel;

    public Worker(ILogger<Worker> logger, IMailService mailService, RabbitMQClientService rabbitMQClientService)
    {
        _logger = logger;
        _mailService = mailService;
        _rabbitMQClientService = rabbitMQClientService;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _channel = _rabbitMQClientService.Connect();
        _channel.BasicQos(0, 1, false);

        return base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        _channel.BasicConsume(MailSendEventConst.QueueName, false, consumer);

        consumer.Received += Consumer_Received;

        await Task.CompletedTask;
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
    {
        var userCreatedEvent = JsonSerializer.Deserialize<MailSendEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));

        await _mailService.Send(userCreatedEvent.MailAdress, userCreatedEvent.Message, userCreatedEvent.Subject);

        _channel.BasicAck(@event.DeliveryTag, false);

        _logger.Log(LogLevel.Information, $"{userCreatedEvent.MailAdress} adresine mail baþarýyla gönderildi");
    }
}