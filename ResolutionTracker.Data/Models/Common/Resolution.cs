using System;
using System.ComponentModel.DataAnnotations;

namespace ResolutionTracker.Data.Common
{
    public class Resolution
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public DateTime DateCompleted { get; set; }

        public int PercentageCompleted { get; set; }
    }
}
