using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollectNet.Models;

namespace CollectNet.Pages.Lists
{
    public class IndexModel : PageModel
    {
        private readonly CollectNet.Models.CollectionContext _context;

        public IndexModel(CollectNet.Models.CollectionContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<List> List { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            IQueryable<List> listIQ = from s in _context.List
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                listIQ = listIQ.Where(s => s.ListName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listIQ = listIQ.OrderByDescending(s => s.ListName);
                    break;
                default:
                    listIQ = listIQ.OrderBy(s => s.ListName);
                    break;
            }

            List = await listIQ.AsNoTracking().ToListAsync();
        }
    }
}
