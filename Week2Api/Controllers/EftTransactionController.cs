using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week2Api.DbContext;
using Week2Api.Entity;

namespace Week2Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EftTransactionController : ControllerBase
{
    private readonly VbDbContext _context;

    public EftTransactionController(VbDbContext context)
    {
        _context = context;
    }

    // GET: api/EftTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EftTransaction>>> GetEftTransactions()
    {
        return await _context.EftTransactions.ToListAsync();
    }

    // GET: api/EftTransaction/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EftTransaction>> GetEftTransaction(int id)
    {
        var eftTransaction = await _context.EftTransactions.FindAsync(id);

        if (eftTransaction == null) return NotFound();

        return eftTransaction;
    }

    // POST: api/EftTransaction
    [HttpPost]
    public async Task<ActionResult<EftTransaction>> PostEftTransaction(EftTransaction eftTransaction)
    {
        _context.EftTransactions.Add(eftTransaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEftTransaction", new {id = eftTransaction.Id}, eftTransaction);
    }

    // PUT: api/EftTransaction/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEftTransaction(int id, EftTransaction eftTransaction)
    {
        if (id != eftTransaction.Id) return BadRequest();

        _context.Entry(eftTransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EftTransactionExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/EftTransaction/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEftTransaction(int id)
    {
        var eftTransaction = await _context.EftTransactions.FindAsync(id);
        if (eftTransaction == null) return NotFound();

        _context.EftTransactions.Remove(eftTransaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EftTransactionExists(int id)
    {
        return _context.EftTransactions.Any(e => e.Id == id);
    }
}