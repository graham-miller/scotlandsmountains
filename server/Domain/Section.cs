using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScotlandsMountains.Domain
{
    public class Section : HasId
    {
        [JsonIgnore]
        public readonly string DobihSectionName;

        public IList<string> MountainIds { get; private set; } = new List<string>();

        public Section() { }

        public Section(string dobihSectionName)
        {
            DobihSectionName = dobihSectionName;
            Code = DobihSectionName.Substring(0, DobihSectionName.IndexOf(SemiColon)).TrimStart('0');
            Name = DobihSectionName.Substring(DobihSectionName.IndexOf(Space) + 1);
        }

        public string Code { get; set; }

        public string Name { get; set; }

        private const char SemiColon = ':';
        private const char Space = ' ';
    }
}
