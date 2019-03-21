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
    public class DetailsModel : PageModel
    {
        private readonly CollectNet.Models.CollectionContext _context;

        public DetailsModel(CollectNet.Models.CollectionContext context)
        {
            _context = context;
        }

        public Item Item { get; set; }
        public List<List> List { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Item.FirstOrDefaultAsync(m => m.ID == id);
            List = await _context.List.ToListAsync();


            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
