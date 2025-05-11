using Exercise3.Models;
using Exercise3.Pages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise3.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly OrderManagementContext _context;

        public CreateModel(OrderManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; }

        public IActionResult OnGet()
        {
            if (!HttpContext.Session.GetInt32("UserID").HasValue)
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    
}
}
