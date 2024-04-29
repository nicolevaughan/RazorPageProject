using Microsoft.EntityFrameworkCore;
using RazorPageProject.Data;

namespace RazorPageProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPageProjectContext>>()))
            {
                if (context == null || context.Song == null)
                {
                    throw new ArgumentNullException("Null RazorPageProjectContext");
                }

                // Look for any songs.
                if (context.Song.Any())
                {
                    return;   // DB has been seeded
                }

                context.Song.AddRange(
                    new Song
                    {
                        Title = "Minglewood Blues",
                        PerformanceDate = DateTime.Parse("2023-5-8"),
                        Location = "Barton Hall - Cornell Univerity",
                        State = "Ithica, NY",
                        SongLength = 8.07M
                    },

                    new Song
                    {
                        Title = "Shakedown Street",
                        PerformanceDate = DateTime.Parse("2023-5-19"),
                        Location = "The Forum",
                        State = "Inglewood, CA",
                        SongLength = 13.23M
                    },

                    new Song
                    {
                        Title = "Bertha",
                        PerformanceDate = DateTime.Parse("2023-5-20"),
                        Location = "The Forum",
                        State = "Inglewood, CA",
                        SongLength = 8.51M
                    },

                    new Song
                    {
                        Title = "Feel Like a Stranger",
                        PerformanceDate = DateTime.Parse("2023-5-23"),
                        Location = "Talking Stick Resort Ampitheater",
                        State = "Phoenix, AZ",
                        SongLength = 12.13M
                    },
                    new Song
                    {
                        Title = "Let the Good Times Roll",
                        PerformanceDate = DateTime.Parse("2023-5-26"),
                        Location = "Dox Equis Pavilion",
                        State = "Dallas, TX",
                        SongLength = 5.0M
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
