using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoviesApp
{
    public class PeopleIndexModel : PageModel
    {
        private readonly MoviesApp.Data.MoviesAppContext _context;

        public PeopleIndexModel(MoviesApp.Data.MoviesAppContext context)
        {
            _context = context;
        }
    }
}
