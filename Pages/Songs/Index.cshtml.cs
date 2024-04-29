using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.Data;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageProject.Data.RazorPageProjectContext _context;

        public IndexModel(RazorPageProject.Data.RazorPageProjectContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Location { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SongLocation { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of locations.
            IQueryable<string> locationQuery = from m in _context.Song
                                            orderby m.Location
                                            select m.Location;

            var songs = from m in _context.Song
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SongLocation))
            {
                songs = songs.Where(x => x.Location == SongLocation);
            }
            Location = new SelectList(await locationQuery.Distinct().ToListAsync());
            Song = await songs.ToListAsync();
        }
    }
}
