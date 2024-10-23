using System;
using enova365EmployeeFeedback.Business;
using enova365EmployeeFeedback.Interfaces;
using Soneta.Business;

namespace enova365EmployeeFeedback.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private ILogger _logger { get; set; }
        private Session _session { get; set; }
        public FeedbackRepository(Session session, ILogger logger)
        {
            _session = session;
            _logger = logger;
        }

        // Metoda dodająca nowy wpis feedback do bazy danych
        public void Add(FeedbackEmp feedbackEmp)
        {
            // Walidacja wejściowa - sprawdzenie, czy pole 'Employee' nie jest puste
            if (feedbackEmp.Employee == null)
            {
                _logger.LogToClient("Pole pracownik nie może zostać puste.");
            }

            // Otwarcie nowej sesji i transakcji w celu dodania wiersza
            using (var session = _session.Login.CreateSession(false, true))
            {
                using (var transaction = session.Logout(true))
                {
                    try
                    {
                        // Ustawienie oceniającego i daty przed dodaniem wiersza
                        var feedback = new FeedbackEmp
                        {
                            Employee = session.Get(feedbackEmp.Employee),
                            DateSubmitted = DateTime.Now,
                            Rating1 = feedbackEmp.Rating1,
                            Rating2 = feedbackEmp.Rating2,
                            Rating3 = feedbackEmp.Rating3,
                            Rating4 = feedbackEmp.Rating4,
                            FeedbackText = feedbackEmp.FeedbackText
                        };

                        // Dodanie wiersza do sesji
                        FeedbackBusinessModule.GetInstance(session).FeedbacksEmp.AddRow(feedback);

                        // Zatwierdzenie transakcji
                        transaction.CommitUI();

                        _logger.LogToClient("Feedback został pomyślnie dodany.");
                    }
                    catch (Exception ex)
                    {
                        // Logowanie błędu do klienta
                        _logger.LogToClient($"Wystąpił błąd podczas dodawania feedbacku: {ex.Message}");
                    }
                }

                // Zapisanie zmian w sesji
                session.Save();
            }
        }
    }
}
