using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SekerTeshis.Core.CrossCuttingConcerns.MailService;
using SekerTeshisApp.Application.CQRS.Account.Responses;
using SekerTeshisApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace SekerTeshisApp.WebApi.MessageQueue.RabbitMQ
{
    public static class Publisher
    {

        public static void CraeteForgetEmailQuaqe(ForgottenPasswordResponse message, bool isMailConfirm)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://yozwqixo:uL3YK7SRvAsJQ82X72jGCDZe_75WPHn_@cow.rmq2.cloudamqp.com/yozwqixo");

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("directexchange", type: ExchangeType.Direct);

                byte[] bytemessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;



                channel.BasicPublish(exchange: "directexchange", routingKey: "passwordReset", basicProperties: properties, body: bytemessage);

            }
        }
        public static void CreateMailConfirmQuaqe(ConfirmMailModel message, bool isMailConfirm)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://yozwqixo:uL3YK7SRvAsJQ82X72jGCDZe_75WPHn_@cow.rmq2.cloudamqp.com/yozwqixo");

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("directexchange", type: ExchangeType.Direct);

                byte[] bytemessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;


                channel.BasicPublish(exchange: "directexchange", routingKey: "mailConfirm", basicProperties: properties, body: bytemessage);

            }
        }
    }
}
