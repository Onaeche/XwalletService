﻿
using StackExchange.Redis;
    namespace WalletService.DAL.Cache
    {
        public class ConnectionHelper
        {
            static ConnectionHelper()
            {
                ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                    return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
                });
            }
            private static Lazy<ConnectionMultiplexer> lazyConnection;
            public static ConnectionMultiplexer Connection
            {
                get
                {
                    return lazyConnection.Value;
                }
            }
        }
    }