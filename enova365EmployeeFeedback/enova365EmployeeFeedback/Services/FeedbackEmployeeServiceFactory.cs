using enova365EmployeeFeedback.Interfaces;
using enova365EmployeeFeedback.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Soneta.Business;

namespace enova365EmployeeFeedback.Services
{
    public static class FeedbackEmployeeServiceFactory
    {
        public static ServiceProvider InitServiceProvider(Session session)
        {
            var services = new ServiceCollection();

            // Rejestracja usług
            services.AddScoped<Session>(provider => session);
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddSingleton<ILogger, Logger>(provider => new Logger(session));
            services.AddSingleton<IResourceStreamService, ResourceStreamService>();

            return services.BuildServiceProvider();
        }
    }
}
