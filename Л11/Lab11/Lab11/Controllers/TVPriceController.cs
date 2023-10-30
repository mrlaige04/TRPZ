using Lab11.Models;
using Lab11.Models.EF;
using Lab11.Models.MVC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Controllers;
public class TVPriceController : Controller
{
    private readonly TvPriceContext _context;

    public TVPriceController(TvPriceContext context)
    {
        _context = context;
    }

    [HttpGet] public IActionResult TVForm() => View(new TVForm { IsEditMode = false });

    [HttpGet] public async Task<IActionResult> EditTV(Guid tvId)
    {
        var tv = await _context.TVs
            .Include(tv=>tv.TVPrice)
            .ThenInclude(tvp=>tvp.Price)
            .FirstOrDefaultAsync(tv => tv.Id == tvId);

        var tvViewModel = new TvViewModel(tv.Id, tv.Name, tv.Brand, tv.Model, tv.TVPrice.Price.Value, tv.TVPrice.Price.Currency);
        

        var model = new TVForm { IsEditMode = true, Tv = tvViewModel };
        return View("TVForm", model);
    }

    [HttpPost] public async Task<IActionResult> TVForm(TVForm tvForm)
    {
        var tv = await _context.TVs
            .Include(tv=>tv.TVPrice)
            .ThenInclude(tvp=>tvp.Price)
            .FirstOrDefaultAsync(tv => tv.Id == tvForm.Tv.Id);
        if (tvForm.IsEditMode && tv is not null)
        {
            tv.Brand = tvForm.Tv.Brand;
            tv.Model = tvForm.Tv.Model;
            tv.Name = tvForm.Tv.Name;

            tv.TVPrice.Price.Value = tvForm.Tv.Price;
            tv.TVPrice.Price.Currency = tvForm.Tv.Currency;
            tv.TVPrice.Price.LastUpdated = DateTime.UtcNow;
            tv.TVPrice.LastUpdated = DateTime.UtcNow;
        }
        else
        {
            
            var newTv = new TV()
            {
                Brand = tvForm.Tv.Brand,
                Name = tvForm.Tv.Name,
                Model = tvForm.Tv.Model,
                TVPrice = new TVPrice()
                {
                    LastUpdated = DateTime.UtcNow,
                    Price = new Price()
                    {
                        Value = tvForm.Tv.Price,
                        Currency = tvForm.Tv.Currency,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            };

            await _context.TVs.AddAsync(newTv);
        }
        
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost] public async Task<IActionResult> DeleteTV(Guid tvId)
    {
        var tv = await _context.TVs.FirstOrDefaultAsync(tv=>tv.Id==tvId);
        if (tv is not null)
        {
            _context.TVs.Remove(tv);
            await _context.SaveChangesAsync();
        }
        
        return RedirectToAction("Index");
    }

    [HttpGet] public async Task<IActionResult> TVPrice(Guid tvId)
    {
        var tv = await _context.TVs
            .Include(tv => tv.TVPrice)
            .ThenInclude(tvp => tvp.Price)
            .FirstOrDefaultAsync(tv => tv.Id == tvId);

        if (tv is not null)
        {
            var price = tv.TVPrice.Price;

            return View(price);
        }

        return RedirectToAction("Index");
    } 

    [HttpGet] public async Task<IActionResult> Index()
    {
        var tvs = await _context.TVs.ToListAsync();
        return View(tvs);
    }
}
