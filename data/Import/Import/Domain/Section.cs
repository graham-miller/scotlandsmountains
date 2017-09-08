using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScotlandsMountains.Import.Domain
{
    public class Section : HasId
    {
        [JsonIgnore]
        public readonly string DobihSectionName;

        public IList<string> MountainIds { get; private set; } = new List<string>();

        public Section(string dobihSectionName)
        {
            DobihSectionName = dobihSectionName;
        }

        public string Code => DobihSectionName.Substring(0, DobihSectionName.IndexOf(SemiColon)).TrimStart('0');

        public string Name => DobihSectionName.Substring(DobihSectionName.IndexOf(Space) + 1);

        private const char SemiColon = ':';
        private const char Space = ' ';
    }
}
