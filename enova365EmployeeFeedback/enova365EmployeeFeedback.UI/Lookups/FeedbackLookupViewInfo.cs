using System.Drawing;
using enova365EmployeeFeedback.UI.Lookups;
using enova365EmployeeFeedback.UI.Views;
using Soneta.Business;
using Soneta.Business.UI;

[assembly: FolderView("Oceń pracownika",
 Priority = 1000,
 Description = "Oceń pracę współpracowników i sprawdź, co inni myślą o Tobie",
 IconName = "osoba_aprobata",
 ForeColor = 9159991
)]

[assembly: FolderView("Oceń pracownika/Wszystkie oceny",
 Priority = 1002,
 Description = "Zobacz, jak inni oceniają Twoich współpracowników",
 ViewType = typeof(FeedbackLookupViewInfo),
 IconName = "osoba_kalendarz",
 ForeColor = 9159991,
 TableName = "FeedbacksEmp"
)]

[assembly: FolderView("Oceń pracownika/Dodaj ocenę",
    Priority = 10,
    Description = "Podziel się swoją opinią na temat współpracownika",
    ObjectType = typeof(FeedbackEmployeeView),
    ObjectPage = "FeedbackEmployeeView.Ogolne.pageform.xml",
    ReadOnlySession = false,
    ForeColor = 9159991,
    IconName = "osoba_aprobata",
    ConfigSession = true
)]

namespace enova365EmployeeFeedback.UI.Lookups
{
    public class FeedbackLookupViewInfo : ViewInfo
    {
        public FeedbackLookupViewInfo()
        {
            ResourceName = "FeedbackList";
        }
    }
}