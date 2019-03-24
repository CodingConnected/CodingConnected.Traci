using System;
using System.Collections.Generic;
using System.Diagnostics;

using CodingConnected.TraCI.NET;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.UsageExample
{
    class UsageExample
    {
        #region Creating SMO process and serving it

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
                Console.WriteLine("Sumo Executable used: " + sumoExecutable);
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

        #endregion

        #region static variables

        private static string DEFAULT_SUMOCFG = @"..\..\sumo-scenarios\usage-example\run.sumocfg";

        /* The Variables used for Variable and Context Subscription for this example */
        private static List<byte> variablesToSubscribeTo = new List<byte>()
        {
            TraCIConstants.VAR_SPEED,
            TraCIConstants.VAR_ACCEL,
            TraCIConstants.VAR_ANGLE,
            TraCIConstants.VAR_ROUTE_ID
        };

        private static List<string> vehicleIds;

        #endregion

        #region subscription listeners

        private static void Client_VehicleSubscriptionUsingResponses(object sender, SubscriptionEventArgs e)
        {
            var objectID = e.ObjecId;
            Console.WriteLine("*** Vehicle Variable Subscription OLD WAY for compatability. (using Responses) ***");
            Console.WriteLine("Subscription Object Id: " + objectID);

            foreach (var r in e.Responses)
            {
                /* Responses are object that can be casted to IResponseInfo so we can retrieve 
                 the variable type. */
                var respInfo = (r as IResponseInfo); 
                var variableCode = respInfo.Variable;

                /*We can then cast to TraCIResponse to get the Content
                 We can also use IResponseInfo.GetContentAs<> ()s*/
                // WARNING using TraCIResponse<> we must use the exact type (i.e for speed, accel, angle, is double and not float)
                switch (variableCode)
                {
                    case TraCIConstants.VAR_SPEED:
                        Console.WriteLine(" VAR_SPEED  " + (r as TraCIResponse<double>).Content);
                        break;
                    case TraCIConstants.VAR_ANGLE:
                        Console.WriteLine(" VAR_ANGLE  " + respInfo.GetContentAs<float> ());
                        break;
                    case TraCIConstants.VAR_ROUTE_ID:
                        Console.WriteLine(" VAR_ROUTE_ID  " + (r as TraCIResponse<string>).Content);
                        break;
                    default:
                        /* Intentionaly ommit VAR_ACCEL*/
                        Console.WriteLine($" Variable with code {ByteToHex(variableCode)} not handled ");
                        break;
                }
            }

        }

        private static string ByteToHex(byte? b)
        {
            return $"0x{((byte)b).ToString("X2")}";
        }
        /// <summary>
        /// Event Args are still SubscriptionEventArgs for backwards compatability but 
        /// can be casted to VariableSubscriptionEventArgs for ResponseByVariableCode support.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Client_VehicleSubscriptionUsingDictionary(object sender, SubscriptionEventArgs e)
        {
            Console.WriteLine("*** Vehicle Variable Subscription using dictionary ***");
            /* Get the subscribed object id */
            var objectID = e.ObjecId;

            /* We can cast to VariableSubscriptionEventArgs to use the new features where 
             we can get the response by the Variable Type */
            var eventArgsNew = e as VariableSubscriptionEventArgs;

            Console.WriteLine("Subscription Object Id: " + objectID);
            var responseInfo = eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_SPEED];
            Console.WriteLine(" VAR_SPEED  " + responseInfo.GetContentAs<float>());

            responseInfo = eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_ACCEL];
            Console.WriteLine(" VAR_SPEED  " + responseInfo.GetContentAs<float>());

            // We can Can still retrieve using TraCIResult. 
            // TraCIResult implements IResponseInfo. 
            // WARNING using TraCIResponse<> we must use the exact type (i.e for angle is double)
            var traCIResponse = (TraCIResponse<double>)eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_ANGLE];
            Console.WriteLine(" VAR_ANGLE  " + traCIResponse.Content);

            Console.WriteLine(" VAR_ROUTE_ID " + eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_ROUTE_ID].GetContentAs<string>());

        }

        private static void Client_VehicleContextSubscriptionUsingDictionary(object sender, ContextSubscriptionEventArgs e)
        {
            Console.WriteLine("*** Vehicle Context Subscription using Dictionaries ***");
            var egoObjectID = e.ObjecId;
            Console.WriteLine("EGO Object " + " id: " + egoObjectID);

            Console.WriteLine("Iterating responses:");
            foreach (var r in e.Responses) /* Responses are TraCIVariableSubscriptionResponse */
            {
                var variableSubscriptionResponse = r as TraCIVariableSubscriptionResponse;
                var vehicleID = variableSubscriptionResponse.ObjectId;
                Console.WriteLine(" Object inside ego object range id: " + vehicleID);
                Console.WriteLine("     VAR_SPEED  " +
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_SPEED]).GetContentAs<float>());
                Console.WriteLine("     VAR_ACCEL  " +
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_ACCEL]).GetContentAs<float>());
                Console.WriteLine("     VAR_ANGLE  " +
                    /* We can also use TraCIResult<> (). Warning using TraCIResponse<> we must use the exact type (i.e for angle is double) */
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_ANGLE] as TraCIResponse<double>).Content);
                Console.WriteLine("     VAR_ROUTE  " +
                    (variableSubscriptionResponse.ResponseByVariableCode[TraCIConstants.VAR_ROUTE_ID]).GetContentAs<string>());
            }

            //We can also get TraCIVariableSubscriptionResponse by objectID
            Console.WriteLine("Iterating objectIds of dictionary with objects inside context range:" +
                "\n Printing VAR_SPEED for demonstration");
            foreach (var id in e.VariableSubscriptionByObjectId.Keys)
            {
                Console.WriteLine(" Object inside ego object range id: " + id);
                var varResp = e.VariableSubscriptionByObjectId[id];
                /* We can handle variable responses like before either iterating responses or
                 by using value by variable type */
                //*Printing VAR_SPEED just for demostration 
                Console.WriteLine("     VAR_SPEED" + varResp.ResponseByVariableCode[TraCIConstants.VAR_SPEED].GetContentAs<float>());
            }
        }

        private static void Client_VehicleContextSubscriptionUsingResponses(object sender, ContextSubscriptionEventArgs e)
        {
            Console.WriteLine("*** Vehicle Context Subscription using responses ***");
            var egoObjectID = e.ObjecId;
            Console.WriteLine("EGO Object " + " id: " + egoObjectID);

            foreach (var r in e.Responses) /* Responses are TraCIVariableSubscriptionResponse */
            {
                var variableSubscriptionResponse = r as TraCIVariableSubscriptionResponse;
                var vehicleID = variableSubscriptionResponse.ObjectId;

                Console.WriteLine(" Object in context range id: " + vehicleID);
                foreach (var response in variableSubscriptionResponse.Responses)
                {
                    var variableResponse = ((IResponseInfo)response);
                    var variableCode = variableResponse.Variable;

                    switch (variableCode)
                    {
                        case TraCIConstants.VAR_SPEED: // Returns the speed of the named vehicle within the last step [m/s]; error value: -2^30
                            Console.WriteLine("     VAR_SPEED  " + ((TraCIResponse<double>)response).Content);
                            break;
                        case TraCIConstants.VAR_ANGLE: // Returns the angle of the named vehicle within the last step [°]; error value: -2^30
                            Console.WriteLine("     VAR_ANGLE  " + ((TraCIResponse<double>)variableResponse).Content);
                            break;
                        case TraCIConstants.VAR_ROUTE_ID:
                            Console.WriteLine("     VAR_ROUTE_ID " + ((TraCIResponse<string>)variableResponse).Content);
                            break;
                        default:
                            /* Intentionaly ommit VAR_ACCEL*/
                            Console.WriteLine($" Variable with code {ByteToHex(variableCode)} not handled ");
                            break;
                    }
                }
            }
        }

        #endregion

        #region Printing vehicle ids methods
    
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

        #endregion Printing vehicle ids methods

        static void Main(string[] args)
        {
            /* Create a TraCIClient for the commands */
            var client = new TraCIClient();

            var sumoCfgPath = DEFAULT_SUMOCFG;

            #region handling arguments
            if (args.Length > 0)
            {
                sumoCfgPath = args[0];
                Console.WriteLine("Using sumocfg located at " + sumoCfgPath);
            }
            else
            {
                Console.WriteLine("No sumocfg file provided. Using default sumocfg: " + DEFAULT_SUMOCFG + "]");
            }
            #endregion

            /*Create a new sumo process so the client can connect to it. This step is optional if 
             a sumo server is already running. */
            var sumoProcess = ServeSumo(sumoCfgPath, 4321, redirectOutputToConsole:true);

            if (sumoProcess == null)
            {
                Console.WriteLine("Something went wrong launching SUMO server. Maybe .sumocfg path is wrong" +
                    "or sumo executables not defined in PATH.\n Sumo Configuration Path provided " + sumoCfgPath);
            }

            /* Connecting to Sumo Server is async but we wait for the task to complete for simplicity */
            var task = client.ConnectAsync("127.0.0.1", 4321);
            while (!task.IsCompleted) { /*  Wait for task to be completed before using traci commands */ }

            /* Subscribe to Variable Subscriptions Events 
             * (triggered each step if the vehicle that was subscribed to exists )*/
            client.VehicleSubscription += Client_VehicleSubscriptionUsingResponses;
            client.VehicleSubscription += Client_VehicleSubscriptionUsingDictionary;

            /* Subscribe to Context Subscriptions Events*/
            client.VehicleContextSubscription += Client_VehicleContextSubscriptionUsingDictionary;
            client.VehicleContextSubscription += Client_VehicleContextSubscriptionUsingDictionary;

            string id;
            Console.WriteLine("");
            var instructions =
                @"
                ************************************************************
                * Press:                                                   *
                *   Enter - to make a Simulation Step                      *
                *   V - to make Variable Subscription                      *
                *   C - to make Context Subscription                       *
                *   P - to print Vehicles                                  *
                *   T - to print Simulation Time                           *
                *   ESC - to stop the simulation                           *
                *   H - to print this instruction menu                     *
                ************************************************************";
            Console.WriteLine(instructions);

            bool isEscapePressed = false;

            do
            {
                Console.Write("\n>");
                var curTime = client.Simulation.GetCurrentTime("ignored").Content;

                var keyPressed = Console.ReadKey(false).Key;
                switch (keyPressed)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine("************************************************************");
                        Console.WriteLine($"Current Simulation time: {curTime} ms");
                        client.Control.SimStep();
                        break;
                    case ConsoleKey.Escape:
                        isEscapePressed = true;
                        break;
                    case ConsoleKey.V:
                        Console.Write(" enter vehicle id for subscripition: >");
                        id = Console.ReadLine();
                        Console.WriteLine("Attempted to subscrible to vehicle with id \"" + id + "\" (see SUMO output to know if it failed)");
                        client.Vehicle.Subscribe(id, 0, 1000, variablesToSubscribeTo);
                        break;
                    case ConsoleKey.C:
                        Console.Write(" enter vehicle id for subscripition: >");
                        id = Console.ReadLine();
                        client.Vehicle.SubscribeContext(id, 0, 1000, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, 1000f, variablesToSubscribeTo);
                        Console.WriteLine("Attempted to subscrible to vehicle with id \"" + id + "\" (see SUMO output to know  if it failed) \n" +
                            "!Warning: Context subscription ends the simulation if it fails!");
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
                        Console.WriteLine("Current Simulation time: " + curTime + " ms");
                        break;
                    case ConsoleKey.H:
                        Console.WriteLine(instructions);
                        break;
                    default:
                        Console.Write("\n        No such command. \n");
                        Console.WriteLine(instructions);
                        break;
                }
            } while (!isEscapePressed);

            client.Control.Close();
            Console.WriteLine("Simulation ended. Press any key to quit");
            Console.ReadKey();
        }
    }
}


