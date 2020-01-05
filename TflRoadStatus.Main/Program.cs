using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TFLRoadStatus;
using TFLRoadStatus.Models;

namespace TFLRoadStatus
{
    class Program
    {
        static void Main(string[] args)
        {

            var oConsoleHelper = new ConsoleHelper();
            var oRoadStatusHelper = new WebServiceHelper();
            string oMessage = "Please enter a road:";
            dynamic objResp = string.Empty;
            oConsoleHelper.GetUserInput(oMessage);
            var oRoadId = Console.ReadLine();
            int ExitCode = 0;
            try
            {

                if (oRoadId.Length > 0)
                {
                    var oDctResponce = new Dictionary<HttpStatusCode, string>();
                    oDctResponce = oRoadStatusHelper.GetRoad(oRoadId);
                    var StatusCode = oDctResponce.Keys.First();


                    switch (StatusCode)
                    {
                        case HttpStatusCode.OK:
                            //we have a valid response hence deserialise the object to a severity status.

                            objResp = JsonConvert.DeserializeObject<List<SeverityStatus>>(oDctResponce.Values.First());
                            oConsoleHelper.PrintRoad(objResp);
                            ExitCode = 0;
                            break;
                        case HttpStatusCode.NotFound:
                            //response was invalid i.e Road does not exist.

                            objResp = JsonConvert.DeserializeObject<NotFoundStatus>(oDctResponce.Values.First());
                            oConsoleHelper.PrintError(oRoadId);
                            ExitCode = 1;
                            break;
                        default:
                            // nothing was satisfied.

                            ExitCode = -1;
                            Console.WriteLine($"{oRoadId} is not a valid road");
                            break;
                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Environment.Exit(-1);
            }
            finally
            {
                Console.WriteLine("Exit Code:" + ExitCode);
                Console.WriteLine("Press enter to close...");

                Console.ReadLine();
            }



        }


    }
}
