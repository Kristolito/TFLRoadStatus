
using System.Configuration;

namespace TFLRoadStatus
{
    public class AppSettings
    {
        public static readonly string AppId = ConfigurationManager.AppSettings["AppId"];
        public static readonly string AppKey = ConfigurationManager.AppSettings["AppKey"];
        public static readonly string BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];
    }
}



