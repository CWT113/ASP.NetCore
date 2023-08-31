using Zack.EventBus;

namespace ConsumerWebAPI
{
    [EventName("OrderCreated")]
    public class EventWebAPI : IIntegrationEventHandler
    {
        public Task Handle(string eventName, string eventData)
        {
            if (eventName == "OrderCreated")
            {
                Console.WriteLine("收到了订单，eventData = " + eventData);
            }
            return Task.CompletedTask;
        }
    }
}
