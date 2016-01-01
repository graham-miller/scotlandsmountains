using System.Collections.Generic;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import
{
    internal interface IDobihReader
    {
        IList<Record> Records { get; }
    }
}