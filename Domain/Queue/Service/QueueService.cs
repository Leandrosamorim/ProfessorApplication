using Domain.Models.EntregaNS;
using Domain.Queue.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queue.Service
{
    public class QueueService /*: IQueueService*/
    {
        //    public Entrega Consume()
        //    {
        //        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "admin" };
        //        Entrega? entrega = null;
        //        var connection = factory.CreateConnection();

        //        var channel = connection.CreateModel();

        //        channel.QueueDeclare(queue: "EntregaQueue",
        //                                     durable: false,
        //                                     exclusive: false,
        //                                     autoDelete: false,
        //                                     arguments: null);

        //        var consumer = new EventingBasicConsumer(channel);
        //        consumer.Received += (ch, ea) =>
        //        {
        //            var body = ea.Body.ToArray();
        //            var message = Encoding.UTF8.GetString(body);
        //            Console.WriteLine("Received: " + message);
        //            var entrega = Newtonsoft.Json.JsonConvert.DeserializeObject<Entrega>(message);

        //            if (ea.DeliveryTag == 1)
        //                channel.BasicAck(ea.DeliveryTag, false);
        //            else
        //                channel.BasicNack(ea.DeliveryTag, false, true);


        //        };
        //        consumer.ConsumerCancelled += OnConsumerCancelled;


        //        channel.BasicConsume(queue: "EntregaQueue",
        //                                 autoAck: false,
        //                                 consumer: consumer);
        //        return entrega;
        //    }

        //    public bool Dequeue()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        //    {
        //        //TODO
        //    }
        //    private void OnShutdown(object sender, ConsumerEventArgs e)
        //    {
        //        //TODO
        //    }
        //}
    }
}
