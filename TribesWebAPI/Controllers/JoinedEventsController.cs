using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8620
#pragma warning disable CS8602
[Route("api/[controller]")]
[ApiController]
public class JoinedEventsController : ControllerBase
{
    readonly ApplicationDbContext _context;
    public JoinedEventsController(ApplicationDbContext context) => _context = context;
   
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> JoinEvent(int userId, int eventId)
    {
        //you can just use foreing keys kekW
        JoinedEvents join = new JoinedEvents { Id = 0, EventID = eventId, UserID = userId };
        await _context.RegisteredForEvents.AddAsync(join);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = join.Id }, join);
    }

    [HttpGet("id")]
    [ProducesResponseType(typeof(JoinedEvents), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var join = await _context.RegisteredForEvents.Where(j => j.Id == id).Include(u => u.User).Include(e => e.Event).Include(e => e.Event.CreatedBy).Include(e => e.Event.PeopleJoined).ThenInclude(e => e.User).Include(e => e.Event.RequestedPeople).Include(e => e.Event.Subtags).ThenInclude(s => s.TagId).ToListAsync();
        return join == null ? NotFound() : Ok(join);
    }

    [HttpGet("userId")]
    [ProducesResponseType(typeof(JoinedEvents), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByUserId(int id)
    {
        var join = await _context.RegisteredForEvents.Where(e => e.User.Id == id).Include(e => e.Event.Subtags).Include(e => e.Event).ThenInclude(e => e.PeopleJoined).ToListAsync();
        return join == null ? NotFound() : Ok(join);
    }

    [HttpDelete("id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UnsubFromEvent(int accId, int eventId)
    {
        var res = _context.RegisteredForEvents.First(u => u.User.Id == accId && u.Event.Id == eventId);
        if(res == null) return NotFound();

        _context.RegisteredForEvents.Remove(res);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

