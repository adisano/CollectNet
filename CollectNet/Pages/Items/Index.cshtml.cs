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
        public List<List> List { get; set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Item.ToListAsync();
            List = await _context.List.ToListAsync();
        }
    }
}
