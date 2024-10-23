using enova365EmployeeFeedback.Business;
using Soneta.Business.UI;

namespace enova365EmployeeFeedback.Interfaces
{
    public interface IFeedbackRepository
    {
        public void Add(FeedbackEmp feedbackEmp);
    }
}
