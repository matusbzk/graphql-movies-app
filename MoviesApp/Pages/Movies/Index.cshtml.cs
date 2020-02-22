using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp
{
    public class IndexModel : PageModel
    {
        private readonly MoviesApp.Data.MoviesAppContext _context;

        public IndexModel(MoviesApp.Data.MoviesAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies
                .Include(m => m.Director).ToListAsync();
        }
    }
}
