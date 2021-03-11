using System.Diagnostics;


namespace ServiceInformation
{
    public class Unit
    {
        private const string BaseCommand = "systemctl";
        public string Name { get; protected set; }

        protected Unit(string name)
        {
            Name = name;
        }

        public string GetActiveState()
        {
            const string propertyName = "ActiveState";

            var activeState = GetPropertyValue(propertyName);

            return activeState;
        }

        public string GetActiveEnterTimestamp()
        {
            const string propertyName = "ActiveEnterTimestamp";

            var activeEnterTimestamp = GetPropertyValue(propertyName);

            return activeEnterTimestamp;
        }

        private Process GetCommand(string parameters)
        {
            var command = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = BaseCommand,
                    Arguments = parameters,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            return command;
        }

        private string GetCommandOutput(Process command)
        {
            command.Start();

            command.WaitForExit();

            var output = command.StandardOutput.ReadLine();

            return output;
        }

        protected string GetPropertyValue(string propertyName)
        {
            var baseParameters = $"show {Name} --property=";

            var parameters = baseParameters + propertyName;

            var command = GetCommand(parameters);

            var rawResult = GetCommandOutput(command);

            var propertyValue = rawResult.Substring(propertyName.Length + 1);

            return propertyValue;
        }
    }
}