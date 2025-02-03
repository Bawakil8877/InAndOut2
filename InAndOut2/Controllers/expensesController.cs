using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InAndOut2.Data;
using InAndOut2.Models;

namespace InAndOut2.Controllers
{
    public class expensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public expensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var expenses = await _context.expense.Include(e => e.ExpenseType).ToListAsync();
            return View(expenses);
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var expense = await _context.expense.Include(e => e.ExpenseType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            ViewBag.TypeDropDown = _context.ExpenseType.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }).ToList();

            return View();
        }


        // POST: Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExpenseName,ExpenseTypeId,Amount")] expense expense)
        {


           //wurin validity
             
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var expense = await _context.expense.FindAsync(id);
            if (expense == null)
                return NotFound();

            ViewBag.TypeDropDown = _context.ExpenseType
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();

            return View(expense);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExpenseName,ExpenseTypeId,Amount")] expense expense)
        {
            if (id != expense.Id)
                return NotFound();

          //wurin validity
             
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
                        return NotFound();
                    throw;
                }
            
            return RedirectToAction(nameof(Index));
            
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var expense = await _context.expense
                .Include(e => e.ExpenseType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.expense.FindAsync(id);
            if (expense != null)
                _context.expense.Remove(expense);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.expense.Any(e => e.Id == id);
        }
    }
}

