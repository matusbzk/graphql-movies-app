using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesApp.Models;

namespace MoviesApp
{
    public class CreateModel : PageModel
    {
        private readonly MoviesApp.Data.MoviesAppContext _context;

        public CreateModel(MoviesApp.Data.MoviesAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DirectorId"] = new SelectList(_context.Set<Person>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
