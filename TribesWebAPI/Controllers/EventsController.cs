using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8620

namespace TribesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        public EventsController(ApplicationDbContext context) => _context = context;

        //limit results by datetime, also note that doing datetime check here, will check the server time not client time
        [HttpGet]
        public async Task<IEnumerable<EventModel>> Get()
        {
            return await _context.Events.Include(e => e.CreatedBy)
                .Include(e => e.Subtags).ThenInclude(e => e.TagId).Include(e => e.RequestedPeople)
                .Include(e => e.PeopleJoined).ThenInclude(u => u.User).ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(EventModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var cEvent = await _context.Events.Where(e => e.Id == id).Include(e => e.CreatedBy)
                .Include(e => e.Subtags).ThenInclude(t => t.TagId)
                .Include(e => e.RequestedPeople)
                .Include(e => e.PeopleJoined).ThenInclude(u => u.User).ToListAsync();
            return cEvent == null ? NotFound() : Ok(cEvent);
        }    

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody]EventModel model)
        {
            await _context.Events.AddAsync(model);
            _context.Entry(model.CreatedBy).State = EntityState.Unchanged; //otherwise it tries to add a new user          
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]       
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]       
        public async Task<IActionResult> Put(int id, [FromBody] EventModel cEvent)
        {
            if (id != cEvent.Id) return BadRequest();           
            _context.Entry(cEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }  

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tagsUsed = await _context.UsedTags.Where(t => t.EventId.Id == id).ToListAsync();
            var requested = await _context.RequestedPeople.Where(r => r.HostEvent.Id == id).ToListAsync();

            _context.UsedTags.RemoveRange(tagsUsed);
            _context.RequestedPeople.RemoveRange(requested);

            var res = await _context.Events.FindAsync(id);
            if (res == null) return NotFound();           
            _context.Events.Remove(res);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //limit max result
        [HttpGet("category")]
        [ProducesResponseType(typeof(EventModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventsByCategory(int id)
        {
            var res = await _context.Events.Where(e => ((int)e.MetaType) == id).Include(e => e.CreatedBy)
                .Include(e => e.RequestedPeople)
                .Include(e => e.Subtags).ThenInclude(e => e.TagId)
                .Include(e => e.PeopleJoined).ThenInclude(e => e.User).ToListAsync();
            return res == null? NotFound() : Ok(res);
        }

        [HttpGet("tag")]
        public async Task<IEnumerable<TagsUsed>> GetEventsByTag(string tag)
        {
            var res = await _context.UsedTags.Where(t => t.TagId.TagName == tag).Include(e => e.EventId).Include(e => e.EventId.CreatedBy).Include(e => e.EventId.RequestedPeople).Include(e => e.EventId.PeopleJoined).ThenInclude(i => i.User).Include(e => e.TagId).Include(e => e.EventId.Subtags).ThenInclude(t => t.TagId)
                .ToListAsync();        
            return res;
        }

        [HttpGet("owner")]
        public async Task<IEnumerable<EventModel>> GetEventsByCreator(int id)
        {
            var res = await _context.Events.Where(e => e.CreatedBy.Id == id).Include(e => e.CreatedBy).Include(i => i.Subtags).ThenInclude(t => t.TagId).Include(e => e.PeopleJoined).ToListAsync();
            return res;
        }

        [HttpGet("joined")]
        public async Task<IEnumerable<JoinedEvents>> GetEventsUserJoined(int id)
        {
            var res = await _context.RegisteredForEvents.Where(e => e.User.Id == id).Include(e => e.Event).Include(e => e.Event.PeopleJoined).Include(e => e.Event.CreatedBy).Include(e => e.Event.Subtags).ThenInclude(e => e.TagId).ToListAsync();
            return res;
        }
    }
}
