using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageProject.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Performance Date")]
        public DateTime PerformanceDate { get; set; }
        [Display(Name = "Venue")]
        public string? Location { get; set; }
        [Display(Name = "City, State")]
        public string? State { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Song Length")]
        public decimal SongLength { get; set; }
    }
}
