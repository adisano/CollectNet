using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CollectNet.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectNet.Pages.Items
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
            Lists = _context.List.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.ListName
            }).ToList();
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }
        [BindProperty]
        public int ListID { get; set; }
        public List<SelectListItem> Lists { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Item.ListID = ListID;

            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}