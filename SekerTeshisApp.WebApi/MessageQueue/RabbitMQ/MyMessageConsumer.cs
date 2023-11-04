using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;
using SekerTeshisApp.Application.Mail.Abstract;
using Newtonsoft.Json;
using SekerTeshis.Core.CrossCuttingConcerns.MailService;
using SekerTeshisApp.WebApi.Models;
using SekerTeshisApp.Application.CQRS.Account.Responses;
using Microsoft.AspNetCore.Identity;
using SekerTeshis.Entity;
using SekerTeshisApp.Application.CQRS.Account.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SekerTeshisApp.WebApi.MessageQueue.RabbitMQ
{
    public class MyMessageConsumer
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IMailSender _mailSender;

        public MyMessageConsumer(IMailSender mailSender)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri =new Uri("amqps://yozwqixo:uL3YK7SRvAsJQ82X72jGCDZe_75WPHn_@cow.rmq2.cloudamqp.com/yozwqixo");

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("directexchange", type: ExchangeType.Direct);
            _mailSender = mailSender;
        }

        public void StartConsuming()
        {
            string passwordResetQueueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: passwordResetQueueName, exchange: "directexchange", routingKey: "passwordReset");

            string mailConfirmQueueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: mailConfirmQueueName, exchange: "directexchange", routingKey: "mailConfirm");

            var passwordResetConsumer = new EventingBasicConsumer(_channel);
            passwordResetConsumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var messageString = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<ForgottenPasswordResponse>(messageString);
                var sendMessage = new Message(new string[] { message.MailAdress }, "Şifre Sifirlama", MailBody.MailBodyConfirmation(message.MailAdress.Substring(0, message.MailAdress.IndexOf("@")), "Şifrenizi Sifirlayin", "2 hour", message.Token), null);
                await _mailSender.SendEmailAsync(sendMessage);
                Serilog.Log.Information(" Queue message was sent");
            };

            var mailConfirmConsumer = new EventingBasicConsumer(_channel);
            mailConfirmConsumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var messageString = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<ConfirmMailModel>(messageString);
                var sendMessage = new Message(new string[] { message.Email }, "Mail Onaylama", MailBody.DefaultMailBody(message.Email.Substring(0, message.Email.IndexOf("@")), "Lütfen Mailinizi Onaylayiniz ", "2 hour", message.Callback.ToString()), null);
                await _mailSender.SendEmailAsync(sendMessage);
                Serilog.Log.Information(" Queue message was sent");
            };

            _channel.BasicConsume(queue: passwordResetQueueName, autoAck: true, consumer: passwordResetConsumer);
            _channel.BasicConsume(queue: mailConfirmQueueName, autoAck: true, consumer: mailConfirmConsumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
