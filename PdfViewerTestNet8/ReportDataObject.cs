using System.ComponentModel;

namespace PdfViewerTestNet8
{
    [DataObject]

    public class ReportDataObject
    {
        public static List<DataDTO> _dataList;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataDTO> Get()
        {
            return _dataList;
        }
        public static void Set(List<DataDTO> dataList)
        {
            _dataList = dataList;
        }
    }

    public class DataDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
    }

}
