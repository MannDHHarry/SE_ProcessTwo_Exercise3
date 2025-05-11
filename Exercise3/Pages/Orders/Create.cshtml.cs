using Exercise3.Models;
using Exercise3.Pages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise3.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly OrderManagementContext _context;

        public CreateModel(OrderManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; }

        public List<SelectListItem> AgentList { get; set; }
        public List<SelectListItem> ItemList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!HttpContext.Session.GetInt32("UserID").HasValue)
            {
                return RedirectToPage("/Login");
            }

            AgentList = await _context.Agents
                .Select(a => new SelectListItem { Value = a.AgentID.ToString(), Text = a.AgentName })
                .ToListAsync();
            ItemList = await _context.Items
                .Select(i => new SelectListItem { Value = i.ItemID.ToString(), Text = i.ItemName })
                .ToListAsync();

            Order = new Order { OrderDate = DateTime.Today, OrderDetails = new List<OrderDetail>() };
            OrderDetails = new List<OrderDetail>();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                AgentList = await _context.Agents
                    .Select(a => new SelectListItem { Value = a.AgentID.ToString(), Text = a.AgentName })
                    .ToListAsync();
                ItemList = await _context.Items
                    .Select(i => new SelectListItem { Value = i.ItemID.ToString(), Text = i.ItemName })
                    .ToListAsync();
                return Page();
            }

            Order.OrderDetails = OrderDetails;
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
