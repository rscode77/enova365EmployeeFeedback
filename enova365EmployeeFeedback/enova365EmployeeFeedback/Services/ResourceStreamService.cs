using enova365EmployeeFeedback.Interfaces;
using System;
using System.Drawing;
using System.IO;

namespace enova365EmployeeFeedback.Services
{
    public class ResourceStreamService : IResourceStreamService
    {
        public Image GetImage(string resourceAddresses, Type type)
        {
            using (Stream imageStream = type.Assembly.GetManifestResourceStream(resourceAddresses))
            {
                if (imageStream == null)
                {
                    throw new FileNotFoundException("Nie można znaleźć zasobu");
                }
                return Image.FromStream(imageStream);
            }
        }

        public string GetText(string resourceAddresses, Type type)
        {
            string page = "";
            using (Stream infoHtml = type.Assembly.GetManifestResourceStream(resourceAddresses))
            {
                using (StreamReader streamReader = new StreamReader(infoHtml))
                    page = streamReader.ReadToEnd();
            }
            return page;
        }
    }
}