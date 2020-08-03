using System;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Configuration
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddExtraJsonFiles(this IHostBuilder builder)
        {
            return builder.ConfigureAppConfiguration((hostContext, configure) =>
            {
                string extraJsonConfigFile = hostContext.Configuration.GetValue<string>("EXTRA_JSON_CONFIG_FILE");
                if (!string.IsNullOrEmpty(extraJsonConfigFile))
                    configure.AddJsonFile(extraJsonConfigFile, true, true);

                extraJsonConfigFile = hostContext.Configuration.GetValue<string>("EXTRA_JSON_CONFIG_FILE_0");
                if (!string.IsNullOrEmpty(extraJsonConfigFile))
                    configure.AddJsonFile(extraJsonConfigFile, true, true);

                int fileIndex = 1;
                while (true)
                {
                    extraJsonConfigFile = hostContext.Configuration.GetValue<string>($"EXTRA_JSON_CONFIG_FILE_{fileIndex++}");
                    if (string.IsNullOrEmpty(extraJsonConfigFile))
                        break;
                    configure.AddJsonFile(extraJsonConfigFile, true, true);
                }
            });
        }
    }
}