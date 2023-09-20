namespace 托管服务
{
    public class HostedService1 : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                Console.WriteLine("HostedService1启动");
                await Task.Delay(3000);

                string txt = await File.ReadAllTextAsync(@"D:\MyDemo\ASP.NetCore\第五章\1.txt");
                Console.WriteLine("文件读取完成");

                await Task.Delay(10000);
                Console.WriteLine(txt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常：" + ex);
            }
        }
    }
}
