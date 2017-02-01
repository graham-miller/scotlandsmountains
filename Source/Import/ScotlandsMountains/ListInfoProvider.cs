using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import.ScotlandsMountains
{
    public interface IListInfoProvider
    {
        ListInfo GetListInfoFor(string listCode);
    }

    public class ListInfoProvider : IListInfoProvider
    {
        private readonly IList<ListInfo> _listInfo = new List<ListInfo>();

        public ListInfoProvider()
        {
            using (var stream = Load.ScotlandsMountains.ListInfo)
            using (var package = new ExcelPackage())
            {
                package.Load(stream);

                ExcelRangeBase cell = package.Workbook.Worksheets.Single().Cells["A2"];

                while (cell.Value != null)
                {
                    _listInfo.Add(new ListInfo
                    {
                        Code = cell.GetValue<string>(),
                        Name = cell.Offset(0, 1).GetValue<string>(),
                        Order = cell.Offset(0, 2).GetValue<int>(),
                        Description = cell.Offset(0, 3).GetValue<string>(),
                        Enabled = cell.Offset(0, 4).GetValue<bool>()
                    });

                    cell = cell.Offset(1, 0);
                }
            }
        }

        public ListInfo GetListInfoFor(string listCode)
        {
            return _listInfo.Single(x => x.Code == listCode);
        }
    }

    public class ListInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
    }
}
