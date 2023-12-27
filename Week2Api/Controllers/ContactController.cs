using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week2Api.DbContext;
using Week2Api.Entity;

namespace Week2Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly VbDbContext _context;

    public ContactController(VbDbContext context)
    {
        _context = context;
    }

    // GET: api/Contact
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
    {
        return await _context.Contacts.ToListAsync();
    }

    // GET: api/Contact/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContact(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null) return NotFound();

        return contact;
    }

    // POST: api/Contact
    [HttpPost]
    public async Task<ActionResult<Contact>> PostContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetContact", new {id = contact.Id}, contact);
    }

    // PUT: api/Contact/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutContact(int id, Contact contact)
    {
        if (id != contact.Id) return BadRequest();

        _context.Entry(contact).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContactExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Contact/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null) return NotFound();

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContactExists(int id)
    {
        return _context.Contacts.Any(e => e.Id == id);
    }
}