using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;
using System.Linq;

namespace NewPharmacy.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMyAppUserEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetMyAppUserEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMyAppUser()
        {
            var MyAppUser = _context.MyAppUsers.ToList();
            return Ok(MyAppUser);
        }
    }
}
