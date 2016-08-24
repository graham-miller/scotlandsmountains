using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import.ScotlandsMountains
{
    public interface IClassificationInfoProvider
    {
        ClassificationInfo GetClassificationInfoFor(string classificationCode);
    }

    public class ClassificationInfoProvider : IClassificationInfoProvider
    {
        private readonly IList<ClassificationInfo> _classificationInfo = new List<ClassificationInfo>();

        public ClassificationInfoProvider()
        {
            using (var stream = Load.ScotlandsMountains.ClassificationInfo)
            using (var package = new ExcelPackage())
            {
                package.Load(stream);

                ExcelRangeBase cell = package.Workbook.Worksheets.Single().Cells["A2"];

                while (cell.Value != null)
                {
                    _classificationInfo.Add(new ClassificationInfo
                    {
                        Code = cell.GetValue<string>(),
                        Name = cell.Offset(0, 1).GetValue<string>(),
                        Order = cell.Offset(0, 2).GetValue<int>(),
                        Description = cell.Offset(0, 3).GetValue<string>()
                    });

                    cell = cell.Offset(1, 0);
                }
            }
        }

        public ClassificationInfo GetClassificationInfoFor(string classificationCode)
        {
            return _classificationInfo.Single(x => x.Code == classificationCode);
        }
    }

    public class ClassificationInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
    }
}
