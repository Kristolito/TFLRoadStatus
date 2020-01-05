using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFLRoadStatus.Models;

namespace TFLRoadStatus
{
    public class ConsoleHelper
    {

        public StringBuilder oMessage { get; set; } = new StringBuilder();




        public void GetUserInput(string msg)
        {
            Console.WriteLine(msg.ToString());


        }


        public void PrintRoad(List<SeverityStatus> objRoadStatus)
        {

            oMessage.Clear();
            oMessage.AppendLine($"\tThe status of the { objRoadStatus.First().displayName} is as follows");
            oMessage.AppendLine($"\tRoad status severity is { objRoadStatus.First().statusSeverity}");
            oMessage.AppendLine($"\tRoad status description is { objRoadStatus.First().statusSeverityDescription}");


            PrintStatus(oMessage.ToString());
        }

        public void PrintError(string road)
        {

            oMessage.Clear();
            oMessage.AppendLine($"\t The following road: { road} is not a valid road.");



            PrintStatus(oMessage.ToString());
        }

        public string PrintInvalidRoadText(string road)
        {
            return $"\t The following road: { road} is not a valid road.";
        }

        public void PrintStatus(string message)
        {
            Console.WriteLine(message);
        }
    }
}
