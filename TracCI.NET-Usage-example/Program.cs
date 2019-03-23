using System;
using System.Collections.Generic;
using System.Diagnostics;

using CodingConnected.TraCI.NET;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.UsageExample
{
    class Program
    {
        static Process ServeSumo(string sumoCfgFile, int remotePort,
            bool useSumoGui = true, bool quitOnEnd = true, bool redirectOutputToConsole = false)
        {
            Process sumoProcess;

            /* Serve Sumo Gui or Sumo */
            try
            {
                var args = " -c " + sumoCfgFile +
                    " --remote-port " + remotePort.ToString() +
                    (useSumoGui ? " --start " : " ") + // this arguments only makes sense if using gui
                    (quitOnEnd ? " --quit-on-end  " : " ");

                // Assumes that bin is in PATHs
                var sumoExecutable = useSumoGui ? @"sumo-gui" : "sumo";

                sumoProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        Arguments = args,
                        FileName = sumoExecutable, // The executable for the sumo

                        /* Ignore the rest if you don't care for redirecting the output to console */
                        CreateNoWindow = redirectOutputToConsole,
                        UseShellExecute = !redirectOutputToConsole,
                        ErrorDialog = false,
                        RedirectStandardOutput = redirectOutputToConsole,
                        RedirectStandardError = redirectOutputToConsole,
                    },

                    EnableRaisingEvents = redirectOutputToConsole //Not importand if not redirecting output
                };

                if (redirectOutputToConsole)
                {
                    sumoProcess.ErrorDataReceived += SumoProcess_ErrorDataReceived;
                    sumoProcess.OutputDataReceived += SumoProcess_OutputDataReceived;
                }

                sumoProcess.Start();

                if (redirectOutputToConsole)
                {
                    sumoProcess.BeginErrorReadLine();
                    sumoProcess.BeginOutputReadLine();
                }

                Console.WriteLine("Arguments: " + args);
                Console.WriteLine("Sumo Executable used " + sumoExecutable);
                Console.WriteLine(sumoProcess.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e);
                Console.WriteLine("Please enter a correct path to sumocfg file");
                return null;
            }

            return sumoProcess;
        }

        /// <summary>
        /// Ignore if you don't care about redirecting output
        /// </summary>
        private static void SumoProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("SUMO stdout : " + e.Data);
        }

        /// <summary>
        /// Ignore if you don't care about redirecting output
        /// </summary>
        private static void SumoProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("SUMO stderr : " + e.Data);
        }

        private static string DEFAULT_SUMOCFG = @"Path\To\Configurationfile\<name>.sumocfg";

        static void Main(string[] args)
        {
            var client = new TraCIClient();
            var sumoCfgPath = args[0] != null ? args[0] : DEFAULT_SUMOCFG;

            var sumoProcess = ServeSumo(@"", 4321);
            if (sumoProcess == null)
            {
                Console.WriteLine("Something went wrong launching SUMO server. Maybe .sumocfg path is wrong" +
                    "or sumo executables not defined in PATH.\n Sumo Configuration Path provided " + sumoCfgPath);
            }

            /* Connecting to Sumo Server is async but we wait for the task to complete for simplicity */
            var task = Connect(client);
            while (!task.IsCompleted)
            {

            }

            /* The Variables used for Variable and Context Subscription */
            List<byte> variablesToSubscribeTo = new List<byte>();
            variablesToSubscribeTo.AddRange(new byte[] {
                TraCIConstants.VAR_SPEED,
                TraCIConstants.VAR_ACCEL,
                TraCIConstants.VAR_ANGLE,
                TraCIConstants.VAR_ROUTE_ID
            });

            /* Variable Subscriptions Listeners */
            //client.VehicleSubscription += Client_VehicleSubscriptionOldWay;
            client.VehicleSubscription += Client_VehicleSubscriptionNewWay;

            /* Context Subscriptions Listeners*/
            client.VehicleContextSubscription += Client_VehicleContextSubscriptionOldWay;
            client.VehicleContextSubscription += Client_VehicleContextSubscriptionNewWay;

            string id;
            Console.WriteLine("");
            Console.WriteLine(
                @"
                ************************************************************
                * Press:                                                   *
                *   Enter - to make Simulation Step                        *
                *   V - to make Variable Subscription                      *
                *   C - to make Context Subscription                       *
                *   P - to print Vehicles                                  *
                *   T - to print Simulation Time                           *
                *   ESC - to stop the simulation.                          *
                ************************************************************");

            bool isEscapePressed = false;
            Console.WriteLine("************************************************************");
            Console.Write($"Current Simulation time {client.Simulation.GetCurrentTime("ignored").Content}");
            do
            {
                Console.Write("\n>");
                var curTime = client.Simulation.GetCurrentTime("ignored").Content;
                //PrintVehicles(client);

                var keyPressed = Console.ReadKey(false).Key;

                switch (keyPressed)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine("************************************************************");
                        Console.Write($"Current Simulation time {curTime}");
                        client.Control.SimStep();
                        break;
                    case ConsoleKey.Escape:
                        isEscapePressed = true;
                        break;
                    case ConsoleKey.V:
                        Console.Write(" id for vehicle subscripition: >");
                        id = Console.ReadLine();
                        Console.Write("Attempted to subscrible to vehicle with id " + id + " (see sumo output if it failed)");
                        client.Vehicle.Subscribe(id, 0, 1000, variablesToSubscribeTo);
                        break;
                    case ConsoleKey.C:
                        Console.Write(" id for vehicle context subscrption: >");
                        id = Console.ReadLine();
                        client.Vehicle.SubscribeContext(id, 0, 1000, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, 1000f, variablesToSubscribeTo);
                        Console.Write("Attempted to subscrible to vehicle with id " + id + " (see sumo output if it failed. " +
                            "Context subscription ends the simulation if it fails)");
                        break;
                    case ConsoleKey.P:
                        Console.WriteLine();
                        PrintActiveVehicles(client);
                        PrintDepartedVehicles(client);
                        PrintLoadedVehicles(client);
                        PrintArrivedVehicles(client);
                        break;
                    case ConsoleKey.T:
                        Console.WriteLine();
                        Console.WriteLine("Current Simulation time " + curTime);
                        break;
                    default:
                        Console.Write("No such command press esc to cancel.");
                        break;
                }
            } while (!isEscapePressed);

            client.Control.Close();
            Console.WriteLine("Simulation ended. Press any key to quit");
            Console.ReadKey();
        }

        /// <summary>
        /// Event Args are still SubscriptionEventArgs for backwards compatability but 
        /// can be casted to VariableSubscriptionEventArgs for ResponseByVariableCode support.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Client_VehicleSubscriptionNewWay(object sender, SubscriptionEventArgs e)
        {

            var objectID = e.ObjecId;
            var eventArgsNew = e as VariableSubscriptionEventArgs;

            Console.WriteLine("*** Vehicle Variable Subscription NEW WAY ***");
            Console.WriteLine("Subscription Object Id: " + objectID);

            var responseInfo = eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_SPEED];
            Console.WriteLine(" VAR_SPEED  " + responseInfo.GetContentAs<float>());
            responseInfo = eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_ACCEL];
            Console.WriteLine(" VAR_SPEED  " + responseInfo.GetContentAs<float>());
            // Can still retrieve using TraCIResult<double> 
            var traCIResponse = (TraCIResponse<double>)eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_ANGLE];
            Console.WriteLine(" VAR_ANGLE  " + traCIResponse.Content);
            Console.WriteLine(" VAR_ROUTE_ID " + eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_ROUTE_ID].GetContentAs<string>());

        }

        private static void Client_VehicleContextSubscriptionNewWay(object sender, ContextSubscriptionEventArgs e)
        {
            Console.WriteLine("*** Vehicle Context Subscription NEW WAY ***");
            var egoObjectID = e.ObjecId;
            Console.WriteLine("EGO Object " + " id: " + egoObjectID);

            foreach (var r in e.Responses) /* Responses are TraCIVariableSubscriptionResponse */
            {
                var variableSubscriptionResponse = r as TraCIVariableSubscriptionResponse;
                var vehicleID = variableSubscriptionResponse.ObjectId;

                Console.Write("     VAR_SPEED  " +
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_SPEED]).GetContentAs<float>());
                Console.Write("     VAR_ACCEL  " +
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_ACCEL]).GetContentAs<float>());
                Console.Write("     VAR_ANGLE  " +
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_ANGLE]).GetContentAs<float>());
                Console.Write("     VAR_ROUTE  " +
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_ROUTE_ID]).GetContentAs<string>());
            }
        }

        private static List<string> vehicleIds;


        private static void Client_VehicleContextSubscriptionOldWay(object sender, ContextSubscriptionEventArgs e)
        {
            Console.WriteLine("*** Vehicle Context Subscription Second way ***");
            var objectCount = 0;
            var egoObjectID = e.ObjecId;
            Console.WriteLine("EGO Object " + " id: " + egoObjectID);

            foreach (var r in e.Responses) /* Responses are TraCIVariableSubscriptionResponse */
            {
                var variableCount = 0;
                var variableSubscriptionResponse = r as TraCIVariableSubscriptionResponse;
                var vehicleID = variableSubscriptionResponse.ObjectId;

                Console.WriteLine(" Object in contaxt range " + objectCount++ + " id: " + vehicleID);

                foreach (var response in variableSubscriptionResponse.Responses)
                {
                    Console.Write("     Variable Count  " + variableCount++);
                    var variableResponse = ((IResponseInfo)response);
                    byte? varType = variableResponse.Variable;

                    switch (varType)
                    {
                        case TraCIConstants.VAR_SPEED: // Returns the speed of the named vehicle within the last step [m/s]; error value: -2^30
                            Console.Write("     VAR_SPEED  " + ((TraCIResponse<double>)response).Content);
                            break;
                        case TraCIConstants.VAR_ACCEL: // Returns the acceleration in the previous time step [m/s^2]	
                            Console.Write("     VAR_ACCEL  " + ((TraCIResponse<double>)variableResponse).Content);
                            break;
                        case TraCIConstants.VAR_ANGLE: // Returns the angle of the named vehicle within the last step [°]; error value: -2^30
                            Console.Write("     VAR_ANGLE  " + ((TraCIResponse<double>)variableResponse).Content);
                            break;
                        case TraCIConstants.VAR_ROUTE_ID:
                            Console.Write("     VAR_ROUTE_ID " + ((TraCIResponse<string>)variableResponse).Content);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(" " + varType);
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void PrintActiveVehicles(TraCIClient client)
        {
            vehicleIds = client.Vehicle.GetIdList().Content;
            Console.Write("Active Vehicles: [");
            foreach (var id in vehicleIds)
            {
                Console.Write($"{id} ,");
            }
            Console.WriteLine("]");
        }

        private static void PrintArrivedVehicles(TraCIClient client)
        {
            vehicleIds = client.Simulation.GetArrivedIDList("ignored").Content;
            Console.Write("Arrived Vehicles: [");
            foreach (var id in vehicleIds)
            {
                Console.Write($"{id} ,");
            }
            Console.WriteLine("]");
        }
        private static void PrintLoadedVehicles(TraCIClient client)
        {
            vehicleIds = client.Simulation.GetLoadedIDList("ignored").Content;
            Console.Write("Loaded Vehicles: [");
            foreach (var id in vehicleIds)
            {
                Console.Write($"{id} ,");
            }
            Console.WriteLine("]");
        }

        private static void PrintDepartedVehicles(TraCIClient client)
        {
            vehicleIds = client.Simulation.GetDepartedIDList("ignored").Content;
            Console.Write("Departed Vehicles: [");
            foreach (var id in vehicleIds)
            {
                Console.Write($"{id} ,");
            }
            Console.WriteLine("]");
        }

        private static void Client_VehicleSubscriptionOldWay(object sender, SubscriptionEventArgs e)
        {

            var objectID = e.ObjecId;
            Console.WriteLine("*** Vehicle Variable Subscription OLD WAY for compatability ***");
            Console.WriteLine("Subscription Object Id: " + objectID);

            foreach (var r in e.Responses)
            {
                var variableCode = (r as TraCIResponse<object>).Variable;

                switch (variableCode)
                {
                    case TraCIConstants.VAR_SPEED:
                        Console.Write("     VAR_SPEED  " + (r as TraCIResponse<float>).Content);
                        break;
                    case TraCIConstants.VAR_ACCEL:
                        Console.Write("     VAR_ACCEL  " + (r as TraCIResponse<float>).Content);
                        break;
                    case TraCIConstants.VAR_ANGLE:
                        Console.Write("     VAR_ANGLE  " + (r as TraCIResponse<float>).Content);
                        break;
                    case TraCIConstants.VAR_ROUTE:
                        Console.Write("     VAR_ROUTE  " + (r as TraCIResponse<string>).Content);
                        break;

                }
            }

        }

        static async System.Threading.Tasks.Task Connect(TraCIClient client)
        {
            await client.ConnectAsync("127.0.0.1", 4321);

        }
    }
}


