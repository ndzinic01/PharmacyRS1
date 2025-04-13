using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;
using NewPharmacy.Data.Models.Auth;

namespace NewPharmacy.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutMyAppUserEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PutMyAppUserEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult PutMyAppUser(int id, [FromBody] MyAppUser myAppUser)
        {
            var existingMyAppUser = _context.MyAppUsers.FirstOrDefault(u => u.ID == id);

            if (existingMyAppUser == null)
                return NotFound($"App User with Id {id} not found.");

            if (string.IsNullOrWhiteSpace(myAppUser.Username))
                return BadRequest("Username cannot be empty.");

            existingMyAppUser.Username = myAppUser.Username;
            existingMyAppUser.FirstName = myAppUser.FirstName;
            existingMyAppUser.LastName = myAppUser.LastName;
            existingMyAppUser.IsAdmin = myAppUser.IsAdmin;
            existingMyAppUser.IsPharmacist = myAppUser.IsPharmacist;
            existingMyAppUser.IsCustomer = myAppUser.IsCustomer;

            _context.SaveChanges(); 

            return NoContent();
        }
    }
}