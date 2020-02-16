using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResolutionTracker.Data.Models
{
    public class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            // check if there are any resolutions in the DB already and add some new ones if not
            using (var context = new ResolutionTrackerContext(serviceProvider.GetRequiredService<DbContextOptions<ResolutionTrackerContext>>()))
            {
                if (context.Resolutions.Any())
                {
                    return;   // DB has been seeded
                }

                context.Resolutions.AddRange(
                    // leave out instrument and date completed
                    new MusicResolution
                    {
                        Title = "See Lamb of God Live",
                        MusicGenre = "Heavy metal",
                        Description = "Lamb of God are going on tour in the spring because they have a new album out. Get in!",
                        Deadline = DateTime.Parse("31/12/2020"),
                        PercentageCompleted = 0
                    },

                    new HealthResolution
                    {
                        Title = "Get Prescription Swimming Goggles",
                        HealthArea = "Eyes",
                        Description = "This will help you get more into swimming if you can see where you're going!",
                        Deadline = DateTime.Parse("30/04/2020"),
                        PercentageCompleted = 0
                    },

                    new CodingResolution
                    {
                        Title = "Contribute to Chocolatey",
                        Technology = "C#",
                        Description = "This will be a good opportunity to contribute to a real open source project",
                        Deadline = DateTime.Parse("31/12/2020"),
                        PercentageCompleted = 0
                    },

                    new LanguageResolution
                    {
                        Title = "Learn Dutch",
                        Language = "Dutch",
                        Skill = "Speaking",
                        Description = "Learn to have a conversation in Dutch, to prepare for JSNation conference",
                        Deadline = DateTime.Parse("01/06/2020"),
                        PercentageCompleted = 0
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
