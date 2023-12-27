using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week2Api.DbContext;
using Week2Api.Entity;

namespace Week2Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly VbDbContext _context;

    public AccountController(VbDbContext context)
    {
        _context = context;
    }

    // GET: api/Account
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
    {
        return await _context.Accounts.ToListAsync();
    }

    // GET: api/Account/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account == null) return NotFound();

        return account;
    }

    // POST: api/Account
    [HttpPost]
    public async Task<ActionResult<Account>> PostAccount(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAccount", new {id = account.Id}, account);
    }

    // PUT: api/Account/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAccount(int id, Account account)
    {
        if (id != account.Id) return BadRequest();

        _context.Entry(account).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AccountExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Account/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null) return NotFound();

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AccountExists(int id)
    {
        return _context.Accounts.Any(e => e.Id == id);
    }
}