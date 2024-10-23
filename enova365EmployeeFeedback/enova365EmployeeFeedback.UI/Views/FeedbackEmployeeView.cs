using System;
using System.Drawing;
using enova365EmployeeFeedback.Business;
using enova365EmployeeFeedback.Interfaces;
using enova365EmployeeFeedback.Services;
using enova365EmployeeFeedback.UI.Views;
using enova365EmployeeFeedback.Utils;
using Microsoft.Extensions.DependencyInjection;
using Soneta.Business;
using Soneta.Kadry;
using Soneta.Types;

[assembly: Worker(typeof(FeedbackEmployeeView))]
namespace enova365EmployeeFeedback.UI.Views
{
    public class FeedbackEmployeeView : ContextBase
    {
        public Pracownik Employee { get; set; }
        public string FeedbackText { get; set; } = string.Empty;
        public int Rating1 { get; set; } = 3;
        public int Rating2 { get; set; } = 3;
        public int Rating3 { get; set; } = 3;
        public int Rating4 { get; set; } = 3;
        public double Average
        {
            get
            {
                return (Rating1 + Rating2 + Rating3 + Rating4) / 4.0;
            }
        }

        [ControlEdit(ControlEditKind.Image)]
        public Image RateImage => GetRateImage(Average);

        [ControlEdit(ControlEditKind.Image)]
        public Image HeaderBarImage => _resourceStreamHelper.GetImage(Constants.HeaderBarImage, GetType());

        [ControlEdit(ControlEditKind.Image)]
        public Image LogoImage => _resourceStreamHelper.GetImage(Constants.LogoImage, GetType());

        private Session _session { get; set; }
        private IResourceStreamService _resourceStreamHelper { get; set; }
        private IFeedbackRepository _feedbackRepository { get; set; }
        public FeedbackEmployeeView(Context context) : base(context)
        {
            _session = context.Session;
            var serviceProvider = FeedbackEmployeeServiceFactory.InitServiceProvider(_session);

            _resourceStreamHelper = new ResourceStreamService();
            _feedbackRepository = serviceProvider.GetService<IFeedbackRepository>();
            _resourceStreamHelper = serviceProvider.GetService<IResourceStreamService>();
        }

        public void AddNewFeedback()
        {
            _feedbackRepository.Add(new FeedbackEmp
            {
                Employee = Employee,
                FeedbackText = FeedbackText,
                Rating1 = Rating1,
                Rating2 = Rating2,
                Rating3 = Rating3,
                Rating4 = Rating4
            });
        }

        private Image GetRateImage(double average)
        {
            int rateIndex = (int)Math.Ceiling(Math.Max(1, Math.Min(average, 5)));

            switch (rateIndex)
            {
                case 1:
                    return _resourceStreamHelper.GetImage(Constants.Rate1Image, GetType());
                case 2:
                    return _resourceStreamHelper.GetImage(Constants.Rate2Image, GetType());
                case 3:
                    return _resourceStreamHelper.GetImage(Constants.Rate3Image, GetType());
                case 4:
                    return _resourceStreamHelper.GetImage(Constants.Rate4Image, GetType());
                case 5:
                    return _resourceStreamHelper.GetImage(Constants.Rate5Image, GetType());
                default:
                    return _resourceStreamHelper.GetImage(Constants.Rate1Image, GetType());
            }
        }
    }
}

