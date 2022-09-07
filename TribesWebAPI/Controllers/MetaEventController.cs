using Microsoft.AspNetCore.Mvc;

namespace TribesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaEventController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public MetaEventController(ApplicationDbContext context) => _context = context;
        

    }
}
