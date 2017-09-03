namespace ScotlandsMountains.Import.Domain
{
    public class Section
    {
        public readonly string DobihSectionName;

        public Section(string dobihSectionName)
        {
            DobihSectionName = dobihSectionName;
        }

        public string Code => DobihSectionName.Substring(0, DobihSectionName.IndexOf(SemiColon));

        public string Name => DobihSectionName.Substring(DobihSectionName.IndexOf(Space) + 1);

        public const char SemiColon = ':';
        public const char Space = ' ';
    }
}
