﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollectNet.Models;

namespace CollectNet.Pages.Lists
{
    public class DetailsModel : PageModel
    {
        private readonly CollectNet.Models.CollectionContext _context;

        public DetailsModel(CollectNet.Models.CollectionContext context)
        {
            _context = context;
        }

        public List List { get; set; }
        public Item Item { get; set; }
        public List<Item> ListItems { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List = await _context.List.FirstOrDefaultAsync(m => m.ID == id);
            ListItems = await _context.Item.Where(m => m.ListID == List.ID).ToListAsync();

            if (List == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
