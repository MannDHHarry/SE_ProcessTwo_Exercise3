using Exercise3.Pages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Exercise3.Pages.FilterForm
{
    public class FilterModel : PageModel
    {
        private readonly OrderManagementContext _context;

        public FilterModel(OrderManagementContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string ReportType { get; set; }

        public List<SelectListItem> ReportTypes { get; set; }
        public dynamic ReportData { get; set; }

        public IActionResult OnGet()
        {
            if (!HttpContext.Session.GetInt32("UserID").HasValue)
            {
                return RedirectToPage("/Login");
            }

            ReportTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "BestItems", Text = "Best Items (Most Purchased)" },
                new SelectListItem { Value = "ItemsByAgent", Text = "Items Purchased by Agents" },
                new SelectListItem { Value = "AgentPurchases", Text = "Agent Purchases" }
            };

            if (!string.IsNullOrEmpty(ReportType))
            {
                if (ReportType == "BestItems")
                {
                    ReportData = _context.OrderDetails
                        .GroupBy(od => od.ItemID)
                        .Select(g => new
                        {
                            ItemName = g.First().Item.ItemName,
                            TotalQuantity = g.Sum(od => od.Quantity)
                        })
                        .OrderByDescending(x => x.TotalQuantity)
                        .Take(10)
                        .ToList();
                }
                else if (ReportType == "ItemsByAgent")
                {
                    ReportData = _context.OrderDetails
                        .Include(od => od.Order).ThenInclude(o => o.Agent)
                        .Include(od => od.Item)
                        .Select(od => new
                        {
                            AgentName = od.Order.Agent.AgentName,
                            ItemName = od.Item.ItemName,
                            Quantity = od.Quantity
                        })
                        .OrderBy(x => x.AgentName)
                        .ToList();
                }
                else if (ReportType == "AgentPurchases")
                {
                    ReportData = _context.Orders
                        .Include(o => o.Agent)
                        .Include(o => o.OrderDetails)
                        .Select(o => new
                        {
                            AgentName = o.Agent.AgentName,
                            OrderDate = o.OrderDate,
                            TotalAmount = o.OrderDetails.Sum(od => od.Quantity * od.UnitAmount)
                        })
                        .OrderBy(x => x.AgentName)
                        .ToList();
                }
            }

            return Page();
        }
    }
}
