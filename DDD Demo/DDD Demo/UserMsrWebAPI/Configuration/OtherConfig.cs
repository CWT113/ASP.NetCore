using Yitter.IdGenerator;

namespace UserMsrWebAPI.Configuration
{
    public static class OtherConfig
    {
        public static void AddOtherConfiguration(this IServiceCollection services)
        {
            // 雪花ID
            var options = new IdGeneratorOptions(1);
            YitIdHelper.SetIdGenerator(options);
        }
    }
}
