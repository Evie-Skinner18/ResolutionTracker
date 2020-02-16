﻿namespace ResolutionTracker.ViewModels
{
    // do I really need this? Can't I just use existing view models?
    public class ResolutionCreateModel
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


        public string RemovePercentageSign()
        {
            return PercentageCompletion.Contains("%") ? PercentageCompletion.Replace("%", string.Empty) : PercentageCompletion;
        }

    }
}
