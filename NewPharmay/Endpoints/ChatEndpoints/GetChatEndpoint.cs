using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPharmacy.Data;
using NewPharmacy.Data.Models;

namespace NewPharmacy.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetChatEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetChatEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Obavijesti/KorisnikId/{korisnikId}
        [HttpGet("MyAppUserId/{myAppUserId}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetMessageByMyAppUserId(int myAppUserId)
        {
            var message = await _context.Chats
                .Where(c => c.MyAppUserId == myAppUserId)
                .OrderBy(c => c.Date)
                .ToListAsync();

            if (message == null || !message.Any())
            {
                return NotFound($"No messages found for user with ID {myAppUserId}.");
            }

            return Ok(message);
        }
    }
}