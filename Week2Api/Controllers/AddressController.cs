using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week2Api.DbContext;
using Week2Api.Entity;

namespace Week2Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly VbDbContext _context;

    public AddressController(VbDbContext context)
    {
        _context = context;
    }

    // GET: api/Address
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
    {
        return await _context.Addresses.ToListAsync();
    }

    // GET: api/Address/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Address>> GetAddress(int id)
    {
        var address = await _context.Addresses.FindAsync(id);

        if (address == null) return NotFound();

        return address;
    }

    // POST: api/Address
    [HttpPost]
    public async Task<ActionResult<Address>> PostAddress(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAddress", new {id = address.Id}, address);
    }

    // PUT: api/Address/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAddress(int id, Address address)
    {
        if (id != address.Id) return BadRequest();

        _context.Entry(address).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AddressExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Address/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null) return NotFound();

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AddressExists(int id)
    {
        return _context.Addresses.Any(e => e.Id == id);
    }
}