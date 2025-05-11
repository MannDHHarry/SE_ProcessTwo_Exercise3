using Exercise3.Pages.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Exercise3.Pages
{
    public class LoginModel : PageModel
    {
        private readonly OrderManagementContext _context;

        public LoginModel(OrderManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("UserID").HasValue)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == UserName && u.Password == Password && !u.Lock);

            if (user == null)
            {
                ErrorMessage = "Invalid username, password, or account is locked.";
                return Page();
            }

            HttpContext.Session.SetInt32("UserID", user.UserID);
            return RedirectToPage("/Index");
        }
    }
}
