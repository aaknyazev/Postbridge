using System;

namespace PostBridge.Publisher.Service
{
    internal class MessageResolver : IMessageResolver
    {
        public string Resolve()
        {
            return $"This message has been generated at {DateTime.Now}. Guid is {Guid.NewGuid().ToString("D")}";
        }
    }
}
