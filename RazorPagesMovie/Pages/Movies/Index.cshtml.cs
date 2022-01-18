#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString {get;set;}
        public SelectList Gernes{get;set;}
        [BindProperty(SupportsGet = true)]
        public string MovieGerne{get;set;}

        public async Task OnGetAsync()
        {
            IQueryable<string> gerneQuery = from m in _context.Movie orderby m.Genre select m.Genre;
            
            

            var movie = from m in _context.Movie select m;
            if(!string.IsNullOrEmpty(SearchString))
            {
                movie = movie.Where(s=>s.Title.Contains(SearchString));
            }
            if(!string.IsNullOrEmpty(MovieGerne))
            {
                movie = movie.Where(x=>x.Genre == MovieGerne);
            }
            Gernes = new SelectList(await gerneQuery.Distinct().ToListAsync());
            Movie = await movie.ToListAsync();
        }
    }
}
