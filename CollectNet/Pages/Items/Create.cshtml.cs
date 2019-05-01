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


            // Use LINQ to get list of items.
            IQueryable<string> listQuery = from m in _context.List
                                           orderby m.ListName
                                           select m.ListName;

            var lists = from m in _context.List
                        where m.UserName == User.Identity.Name
                        select m;

            
            Lists = lists.Select(x => new SelectListItem
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
        public IList<List> List { get; set; }
        public List<SelectListItem> Lists { get; set; }
        [BindProperty]
        public bool IsChecked { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {

                return Page();
            }

            Item.ListID = ListID;
            Item.UserName = User.Identity.Name;
            
            if (IsChecked)
            {
                Item.IsCollected = true;
            }

            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}