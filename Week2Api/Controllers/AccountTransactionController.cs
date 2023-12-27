using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week2Api.DbContext;
using Week2Api.Entity;

namespace Week2Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountTransactionController : ControllerBase
{
    private readonly VbDbContext _context;

    public AccountTransactionController(VbDbContext context)
    {
        _context = context;
    }

    // GET: api/AccountTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountTransaction>>> GetAccountTransactions()
    {
        return await _context.AccountTransactions.ToListAsync();
    }

    // GET: api/AccountTransaction/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AccountTransaction>> GetAccountTransaction(int id)
    {
        var accountTransaction = await _context.AccountTransactions.FindAsync(id);

        if (accountTransaction == null) return NotFound();

        return accountTransaction;
    }

    // POST: api/AccountTransaction
    [HttpPost]
    public async Task<ActionResult<AccountTransaction>> PostAccountTransaction(AccountTransaction accountTransaction)
    {
        _context.AccountTransactions.Add(accountTransaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAccountTransaction", new {id = accountTransaction.Id}, accountTransaction);
    }

    // PUT: api/AccountTransaction/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAccountTransaction(int id, AccountTransaction accountTransaction)
    {
        if (id != accountTransaction.Id) return BadRequest();

        _context.Entry(accountTransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AccountTransactionExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/AccountTransaction/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccountTransaction(int id)
    {
        var accountTransaction = await _context.AccountTransactions.FindAsync(id);
        if (accountTransaction == null) return NotFound();

        _context.AccountTransactions.Remove(accountTransaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AccountTransactionExists(int id)
    {
        return _context.AccountTransactions.Any(e => e.Id == id);
    }
}