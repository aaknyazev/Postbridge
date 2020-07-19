using System;

namespace PostBridge.Domain.Postmessage
{
    public class Postmessage : BaseEntityLongId
    {
        public string Message { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime SentDate { get; set; }

        public PostmessageStatus Status { get; set; }
    }
}
