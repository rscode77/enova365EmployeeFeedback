using System;
using System.Drawing;

namespace enova365EmployeeFeedback.Interfaces
{
    public interface IResourceStreamService
    {
        public Image GetImage(string resourceName, Type type);
        public string GetText(string resourceName, Type type);
    }
}
