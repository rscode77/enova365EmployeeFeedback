using enova365EmployeeFeedback.Business;
using enova365EmployeeFeedback.Services;
using Soneta.Business;
using static enova365EmployeeFeedback.Business.FeedbackBusinessModule;

[assembly: ProgramInitializer(typeof(FeedbackEmployeeInitializer))]

namespace enova365EmployeeFeedback.Services
{
    public class FeedbackEmployeeInitializer : IProgramInitializer
    {
        public void Initialize()
        {
            FeedbackEmpSchema.AddOnAdded((FeedbackEmpRow feedback) =>
            {
                feedback.Session.Verifiers.Add(new FeedbackEmpVerifier(feedback));
                
            });

            FeedbackEmpSchema.AddOnEditing((FeedbackEmpRow feedback) =>
            {
                feedback.Session.Verifiers.Add(new FeedbackEmpVerifier(feedback));
            });
        }
    }
}
