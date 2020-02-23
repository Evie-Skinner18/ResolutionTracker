namespace ResolutionTracker.ViewModels.Common
{
    public abstract class ResolutionChangeModel
    {
        public string ResolutionId { get; set; }

        public string ResolutionTitle { get; set; }

        public string ResolutionDescription { get; set; }

        public string ResolutionDeadline { get; set; }

        public string ResolutionType { get; set; }

        public string PercentageCompletion { get; set; }

        public string MusicGenre { get; set; }

        public string MusicalInstrument { get; set; }

        public string HealthArea { get; set; }

        public string CodingTechnology { get; set; }

        public string Language { get; set; }

        public string LanguageSkill { get; set; }
    }
}
