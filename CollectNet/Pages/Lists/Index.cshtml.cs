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

        public PaginatedList<List> List { get;set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

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

            int pageSize = 3;
            List = await PaginatedList<List>.CreateAsync(
                listIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
