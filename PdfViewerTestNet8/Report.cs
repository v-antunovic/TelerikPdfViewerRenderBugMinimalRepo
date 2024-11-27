using System.Collections;
using System.IO;
using Telerik.Reporting;
using Telerik.Reporting.Processing;

namespace PdfViewerTestNet8
{
    public class Report
    {
        public static string NewReport()
        {
            try
            {
                List<DataDTO> dataList = [
                    new ()
                    {
                        Id = 1,
                        Title = "Test",
                        Date = DateTime.Now,
                        Status = 2,
                        StatusDescription = "Test status description",
                    }];

                ReportDataObject.Set(dataList);

                var violationReport = new UriReportSource
                {
                    Uri = "TestReport.trdp"
                };

                ReportBook reportBook = new();

                reportBook.ReportSources.Add(violationReport);

                InstanceReportSource combinedReport = new()
                {
                    ReportDocument = reportBook
                };

                ReportProcessor reportProcessor = new();

                Hashtable deviceInfo = [];

                RenderingResult result = reportProcessor.RenderReport("PDF", combinedReport, deviceInfo);

                if (!result.HasErrors)
                {
                    using MemoryStream memoryStream = new(result.DocumentBytes);

                    string outputDirectory = Path.Combine(Path.GetTempPath(), "Reports");
                    if (!Directory.Exists(outputDirectory))
                    {
                        Directory.CreateDirectory(outputDirectory);
                    }

                    string filePath = Path.Combine(outputDirectory, $"{Guid.NewGuid()}.pdf");
                    File.WriteAllBytes(filePath, result.DocumentBytes);

                    return filePath;
                }
                else
                {
                    throw result.Errors.First();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
