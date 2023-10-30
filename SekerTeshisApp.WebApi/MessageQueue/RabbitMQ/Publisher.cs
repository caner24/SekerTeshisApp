using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SekerTeshis.Core.CrossCuttingConcerns.MailService;
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

        public static void CreateQueue(Message message, bool isMailConfirm)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("directexchange", type: ExchangeType.Direct);

                byte[] bytemessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                //password reset,mail confirm

                if (isMailConfirm != true)
                    channel.BasicPublish(exchange: "directexchange", routingKey: "passwordReset", basicProperties: properties, body: bytemessage);
                else
                    channel.BasicPublish(exchange: "directexchange", routingKey: "mailConfirm", basicProperties: properties, body: bytemessage);

            }
        }
    }
}
