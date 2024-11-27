using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed;

namespace PdfViewerTestNet8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var path = Report.NewReport();
            pdfViewer.DocumentSource = new PdfDocumentSource(new Uri(path));
        }

        private void btnOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = MessageBox.Show("Choose your own PDF?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (msg == MessageBoxResult.Yes)
            {
                OpenFileDialog saveFileDialog = new OpenFileDialog();
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.Filter = "pdf Files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                var res = saveFileDialog.ShowDialog();

                if (res.HasValue && res.Value)
                {
                    pdfViewer.DocumentSource = new PdfDocumentSource(new Uri(saveFileDialog.FileName, UriKind.Absolute));
                }
            }
            else
            {
                var path = Report.NewReport();
                pdfViewer.DocumentSource = new PdfDocumentSource(new Uri(path));
            }

        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnRegenriraj_Click(object sender, RoutedEventArgs e)
        {
        }

        private void tbCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}