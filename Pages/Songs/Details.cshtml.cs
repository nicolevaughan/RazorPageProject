using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.Data;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Songs
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageProject.Data.RazorPageProjectContext _context;

        public DetailsModel(RazorPageProject.Data.RazorPageProjectContext context)
        {
            _context = context;
        }

        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }
            else
            {
                Song = song;
            }
            return Page();
        }
    }
}
