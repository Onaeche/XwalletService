
using StackExchange.Redis;
    namespace WalletService.Cache
    {
        public class ConnectionHelper
        {
            static ConnectionHelper()
            {
                ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                    return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
                });
            }
            //private static Lazy<ConnectionMultiplexer> lazyConnection;

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
            return ConnectionMultiplexer.Connect("mycache.redis.cache.windows.net,abortConnect=false,ssl=true,password=...");
        });
        public static ConnectionMultiplexer Connection
            {
                get
                {
                    return lazyConnection.Value;
                }
            }
        }
    }