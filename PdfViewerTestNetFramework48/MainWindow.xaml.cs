using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed;

namespace PdfViewerTestNetFramework48
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
            pdfViewer.DocumentSource = new PdfDocumentSource(new Uri(Environment.CurrentDirectory + "/e229a471-d448-47e9-af80-f27c6cb01fe2.pdf"));
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
                pdfViewer.DocumentSource = new PdfDocumentSource(new Uri(Environment.CurrentDirectory + "/e229a471-d448-47e9-af80-f27c6cb01fe2.pdf"));
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
