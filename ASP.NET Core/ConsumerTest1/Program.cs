using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

ConnectionFactory? factory = new ConnectionFactory();
factory.HostName = "127.0.0.1";//RabbitMQ的服务器地址
factory.DispatchConsumersAsync = true;//支持异步
string exchangeName = "exchange1";//交换机的名字
string queueName = "queue1";
string routingKey = "Key1";
IConnection? connection = factory.CreateConnection();//创建连接

using IModel? channel = connection.CreateModel();
channel.ExchangeDeclare(exchangeName, "direct");
channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
channel.QueueBind(queueName, exchangeName, routingKey);

AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);
consumer.Received += Consumer_Received;
channel.BasicConsume(queueName, autoAck: false, consumer: consumer);
Console.WriteLine("按回车退出！");
Console.ReadLine();
async Task Consumer_Received(object sender, BasicDeliverEventArgs _event)
{
	try
	{
		byte[] bytes = _event.Body.ToArray();
		string text = Encoding.UTF8.GetString(bytes);
		Console.WriteLine(DateTime.Now + "  收到消息  " + text);
		channel.BasicAck(_event.DeliveryTag, multiple: false);
		await Task.Delay(800);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex);
		channel.BasicReject(_event.DeliveryTag, true);
	}
}
