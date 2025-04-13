using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPharmacy.Data;
using NewPharmacy.Data.Models;
using NewPharmacy.Endpoints;
using System.Linq;
using System.Threading.Tasks;

namespace NewPharmacy.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostOrderEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostOrderEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Narudzbe
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (!_context.Suppliers.Any(s => s.Id == order.SupplierId))
            {
                return BadRequest("Non-existent supplier Id.");
            }

            if (!_context.MyAppUsers.Any(u => u.ID == order.MyAppUserId))
            {
                return BadRequest("Non-existent MyAppUser Id.");
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderByIdEndpoint.GetOrderById), new { id = order.Id }, order);
        }
    }
}