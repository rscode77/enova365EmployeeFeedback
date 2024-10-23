using Soneta.Business;
using Soneta.CRM;
using Soneta.Types;
using static enova365EmployeeFeedback.Business.FeedbackBusinessModule;

namespace enova365EmployeeFeedback.Business
{
    public class FeedbackEmpVerifier : RowVerifier
    {
        public FeedbackEmpVerifier(Row row) : base(row) { }

        public override string Description => "Wartość oceny musi się mieścic między 0 a 5.";

        private new FeedbackEmpRow Row => (FeedbackEmpRow)base.Row;
        protected override bool IsValid()
        {
            return IsRatingValid(Row.Rating1.ToString()) &&
                   IsRatingValid(Row.Rating2.ToString()) &&
                   IsRatingValid(Row.Rating3.ToString()) &&
                   IsRatingValid(Row.Rating4.ToString());
        }

        private bool IsRatingValid(string rate)
        {
            if (string.IsNullOrEmpty(rate)) return false;
            if (int.TryParse(rate, out int parsedRate))
            {
                return parsedRate >= 0 && parsedRate <= 5;
            }
            return false;
        }

        public override VerifierType Type => VerifierType.Error;
    }
}
