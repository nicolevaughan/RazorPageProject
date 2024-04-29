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
    public class DeleteModel : PageModel
    {
        private readonly RazorPageProject.Data.RazorPageProjectContext _context;

        public DeleteModel(RazorPageProject.Data.RazorPageProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                Song = song;
                _context.Song.Remove(Song);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
