using System;
using System.Diagnostics;

namespace ServiceInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    throw new Exception("Invalid input");
                }

                var type = args[0];

                var name = args[1];

                if (type == "--service")
                {
                    var service = new ServiceUnit(name);

                    var state = service.GetActiveState();

                    var lastTimeRun = service.GetActiveEnterTimestamp();

                    var user = service.GetUser();

                    var group = service.GetGroup();
                    
                    Console.WriteLine($"{service.Name} {state}, user {user}, group {group}, last started {lastTimeRun}");
                }
                else
                {
                    var timer = new TimerUnit(name);

                    var state = timer.GetActiveState();

                    var lastTimeRun = timer.GetActiveEnterTimestamp();
                    
                    Console.WriteLine($"{timer.Name} {state}, last started {lastTimeRun}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}