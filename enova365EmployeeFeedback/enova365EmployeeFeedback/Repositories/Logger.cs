using Soneta.Business;
using Soneta.Business.UI;

namespace enova365EmployeeFeedback.Repositories
{
    public class Logger : Interfaces.ILogger
    {
        private Session _session { get; set; }
        public Logger(Session session)
        {
            _session = session;
        }
        public void LogToClient(string message)
        {
            new Log("EmployeeFeedback", true).WriteLine(message);
        }

        public MessageBoxInformation LogToMessageBox(string message, MessageBoxInformationType type)
        {
            return new MessageBoxInformation
            {
                Type = type,
                Text = message,
                OKHandler = () => { return null; }
            };
        }
    }
}
