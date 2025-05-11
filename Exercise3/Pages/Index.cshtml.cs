using Exercise3.Pages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly OrderManagementContext _context;

        public IndexModel(OrderManagementContext context)
        {
            _context = context;
        }

        public bool IsLoggedIn { get; set; }
        public string UserName { get; set; }

        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId.HasValue)
            {
                var user = await _context.Users.FindAsync(userId.Value);
                if (user != null)
                {
                    IsLoggedIn = true;
                    UserName = user.UserName;
                }
            }
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
