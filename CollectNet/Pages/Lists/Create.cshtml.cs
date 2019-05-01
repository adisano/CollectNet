using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CollectNet.Models;

namespace CollectNet.Pages.Lists
{
    public class CreateModel : PageModel
    {
        private readonly CollectNet.Models.CollectionContext _context;

        public CreateModel(CollectNet.Models.CollectionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public List List { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.List.Add(List);
            List.UserName = User.Identity.Name;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}