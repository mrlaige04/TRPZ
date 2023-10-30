using Lab12.Models.EF;
using Lab12.Models.MVC.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Controllers;
[ApiController, Route("tvs")]
public class TVController : Controller
{
    private readonly TvPriceContext _context;

    public TVController(TvPriceContext context)
    {
        _context = context;
    }

    [HttpGet, Route("")]
    public async Task<IActionResult> GetAll()
    {
        var tvs = await _context.TVs.ToListAsync();
            
        return Ok(tvs);
    }

    [HttpGet, Route("{id:Guid}")] 
    public async Task<IActionResult> GetById(Guid id)
    {
        if (id == Guid.Empty) return BadRequest(ModelState);

        var tv = await _context.TVs
            .FirstOrDefaultAsync(tv=>tv.Id == id);

        if (tv is null) return NotFound();

        return Ok(tv);
    }

    [HttpGet, Route("brand/{query}")]
    public async Task<IActionResult> GetByBrand(string query)
    {
        if (string.IsNullOrEmpty(query)) return BadRequest(ModelState);

        var tv = await _context.TVs
            .FirstOrDefaultAsync(tv => tv.Brand.Equals(query, StringComparison.InvariantCultureIgnoreCase));

        if (tv is null) return NotFound();

        return Ok(tv);
    }

    [HttpGet, Route("name/{query}")]
    public async Task<IActionResult> GetByName(string query)
    {
        if (string.IsNullOrEmpty(query)) return BadRequest(ModelState);

        var tv = await _context.TVs
            .FirstOrDefaultAsync(tv => tv.Name.Equals(query, StringComparison.InvariantCultureIgnoreCase));

        if (tv is null) return NotFound();

        return Ok(tv);
    }

    [HttpGet, Route("model/{query}")]
    public async Task<IActionResult> GetByModel(string query)
    {
        if (string.IsNullOrEmpty(query)) return BadRequest(ModelState);

        var tv = await _context.TVs
            .FirstOrDefaultAsync(tv => tv.Model.Equals(query, StringComparison.InvariantCultureIgnoreCase));

        if (tv is null) return NotFound();

        return Ok(tv);
    }

    [HttpGet, Route("price/{price:decimal}")]
    public async Task<IActionResult> GetByPrice(decimal price)
    {
        var tv = await _context.TVs
            .Include(tv=>tv.TVPrice)
            .ThenInclude(tvp=>tvp.Price)
            .FirstOrDefaultAsync(tv => tv.TVPrice.Price.Value == price);

        if (tv is null) return NotFound();

        return Ok(tv);
    }

    [HttpGet, Route("price/{min:decimal}/{max:decimal}")]
    public async Task<IActionResult> GetByPriceRange(decimal min, decimal max)
    {
        var tv = await _context.TVs
            .Include(tv => tv.TVPrice)
            .ThenInclude(tvp => tvp.Price)
            .FirstOrDefaultAsync(tv => tv.TVPrice.Price.Value >= min && tv.TVPrice.Price.Value <= max);

        if (tv is null) return NotFound();

        return Ok(tv);
    }

    [HttpPut, Route("")]
    public async Task<IActionResult> Create([FromBody] CreateTVModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var tv = new TV
        {
            Name = model.Name,
            Brand = model.Brand,
            Model = model.Name,
            
        };
        tv.TVPrice = new TVPrice
        {
            LastUpdated = DateTime.UtcNow,
            
        };

        tv.TVPrice.Price = new Price
        {
            Value = model.Price,
            Currency = model.Currency,
            LastUpdated = DateTime.UtcNow
        };
        await _context.TVs.AddAsync(tv);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost, Route("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTVModel model)
    {
        var tv = await _context.TVs
            .Include(tv => tv.TVPrice)
            .ThenInclude(tv => tv.Price)
            .FirstOrDefaultAsync(tv => tv.Id == id);

        if (tv is null) return NotFound();

        tv.Name = model.Name ?? tv.Name;
        tv.Brand = model.Brand ?? tv.Brand;
        tv.Model = model.Model ?? tv.Model;

        tv.TVPrice.Price.Value = model.Price ?? tv.TVPrice.Price.Value;
        tv.TVPrice.Price.Currency = model.Currency ?? tv.TVPrice.Price.Currency;

        tv.TVPrice.LastUpdated = DateTime.UtcNow;
        tv.TVPrice.Price.LastUpdated = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete, Route("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var tv = await _context.TVs
            .Include(tv => tv.TVPrice)
            .ThenInclude(tvp => tvp.Price)
            .FirstOrDefaultAsync(tv=>tv.Id == id);

        if (tv is null) return NotFound();

        var price = tv.TVPrice.Price;

        _context.TVs.Remove(tv);
        _context.Prices.Remove(price);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
