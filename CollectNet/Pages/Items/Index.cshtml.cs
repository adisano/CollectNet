using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollectNet.Models;

namespace CollectNet.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly CollectNet.Models.CollectionContext _context;

        public IndexModel(CollectNet.Models.CollectionContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchItem { get; set; }

        public List<List> List { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of items.
            IQueryable<string> itemQuery = from m in _context.Item
                                           orderby m.ItemName
                                           select m.ItemName;

            var items = from m in _context.Item
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.ItemName.Contains(SearchString) ||
                                         s.ItemTags.Contains(SearchString) ||
                                         s.ItemTypes.Contains(SearchString));
            }

            Item = await items.ToListAsync();
            List = await _context.List.ToListAsync();
        }
    }
}
