using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Portfolio.Models;
using Portfolio.Models.Data;


namespace Portfolio.Controllers
{
    
    public class StockController : Controller
    {
        private readonly StockContext context;
        

        public StockController(StockContext context)
        {
            this.context = context;
        }




        // GET: Stock
        public async Task<IActionResult> Index()
        {

            return View(await context.Stock.ToListAsync());
        }


        public IActionResult Recent()
        {

            return View(context.Stock.OrderByDescending(x => x.ID).Take(11).ToList());


        }
        // GET: Stock/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocks = await context.Stock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stocks == null)
            {
                return NotFound();
            }

            return View(stocks);
        }

        // GET: Stock/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Symbol,LastPrice,DateScrapped,Change,ChangeRate,Currency,MarketTime,Volume,ShareData,AverageVolume,MarketCapData")] Stocks stocks)
        {
            if (ModelState.IsValid)
            {
                context.Add(stocks);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stocks);
        }

        

        // GET: Stock/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocks = await context.Stock.FindAsync(id);
            if (stocks == null)
            {
                return NotFound();
            }
            return View(stocks);
        }

        // POST: Stock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Symbol,LastPrice,DateScrapped,Change,ChangeRate,Currency,MarketTime,Volume,ShareData,AverageVolume,MarketCapData")] Stocks stocks)
        {
            if (id != stocks.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(stocks);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StocksExists(stocks.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stocks);
        }

        // GET: Stock/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocks = await context.Stock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stocks == null)
            {
                return NotFound();
            }

            return View(stocks);
        }

        // POST: Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stocks = await context.Stock.FindAsync(id);
            context.Stock.Remove(stocks);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StocksExists(int id)
        {
            return context.Stock.Any(e => e.ID == id);
        }



        
    }
}
