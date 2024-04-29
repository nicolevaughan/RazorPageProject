using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageProject.Data;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly RazorPageProject.Data.RazorPageProjectContext _context;

        public CreateModel(RazorPageProject.Data.RazorPageProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Song.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
