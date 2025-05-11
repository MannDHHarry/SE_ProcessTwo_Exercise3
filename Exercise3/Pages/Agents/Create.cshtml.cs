using Exercise3.Models;
using Exercise3.Pages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise3.Pages.Agents
{
    public class CreateModel : PageModel
    {
        private readonly OrderManagementContext _context;

        public CreateModel(OrderManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agent Agent { get; set; }

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

            _context.Agents.Add(Agent);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
