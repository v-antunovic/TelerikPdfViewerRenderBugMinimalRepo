using System.Globalization;
using System.Windows;

namespace PdfViewerTestNet8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var culture = new CultureInfo("hr-HR"); //uses comma as decimal separator, DOES NOT WORK!!!!
            //var culture = new CultureInfo("en-US"); //uses dot as decimal separator, WORKS!
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Thread.CurrentThread.CurrentCulture = culture; ;
            Thread.CurrentThread.CurrentUICulture = culture;

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }

}
