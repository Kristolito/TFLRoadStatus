

namespace TFLRoadStatus.Models
{
    public class NotFoundStatus
    {
        public string timeStamptUtc { get; set; }
        public string exceptionType { get; set; }
        public string httpStatusCode { get; set; }
        public string httpStatus { get; set; }
        public string relativeUri { get; set; }
        public string message { get; set; }
    }
}
