using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Assos_Ticket.Server.PaymentSystem
{
    public class Base
    {
        protected void PrintResponse<T>(T resource)
        {
            TraceListener consoleListener = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleListener);
            Trace.WriteLine(JsonConvert.SerializeObject(resource, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}
