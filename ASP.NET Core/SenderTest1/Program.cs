using System.Text;
using RabbitMQ.Client;

ConnectionFactory? factory = new ConnectionFactory();
factory.HostName = "127.0.0.1";//RabbitMQ的服务器地址
factory.DispatchConsumersAsync = true;//支持异步
string exchangeName = "exchange1";//交换机的名字
IConnection? connection = factory.CreateConnection();//创建连接

while (true)
{
    using IModel? channel = connection.CreateModel();
    IBasicProperties? prop = channel.CreateBasicProperties();
    prop.DeliveryMode = 2;
    channel.ExchangeDeclare(exchangeName, "direct");
    byte[] bytes = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
    channel.BasicPublish(exchangeName, routingKey: "Key1", mandatory: true, basicProperties: prop, body: bytes);

    Console.WriteLine("消息发送成功！" + DateTime.Now);
    Thread.Sleep(1000);
}
