using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationSample.Helpers
{
    public static class EnvironmentHelper
    {
        public const string EnvironmentDbHostName = "DB_HOSTNAME";
        private static string[] _arguments;
        public static string[] DockerArguments
        {
            get
            {
                bool argumentsExist = _arguments != null && _arguments.Any();
                if (!argumentsExist)
                {
                    IDictionary environmentVariables = Environment.GetEnvironmentVariables();
                    if (environmentVariables.Contains(EnvironmentDbHostName))
                    {
                        var argumentsHolder = environmentVariables[EnvironmentDbHostName] as string;
                        const char argumentSeparator = ' ';
                        _arguments = argumentsHolder?.Split(argumentSeparator);
                    }
                }
                return _arguments;
            }
        }
    }
}
