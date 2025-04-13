using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;
using NewPharmacy.Data.Models;

namespace NewPharmacy.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostChatEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostChatEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Obavijesti
        [HttpPost]
        public async Task<ActionResult<Chat>> PostMessage(Chat message)
        {
            if (message == null)
            {
                return BadRequest("Invalid message data.");
            }

            // Add the new message to the database
            message.Date = DateTime.Now; // Automatically set the date to now
            _context.Chats.Add(message);
            await _context.SaveChangesAsync();

            // Return a response indicating success
            return CreatedAtAction(nameof(GetChatEndpoint), new { myAppUserId = message.MyAppUserId }, message);
        }
    }
}