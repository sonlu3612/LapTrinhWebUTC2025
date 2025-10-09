using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLAB6_EF.Entities;
using NetCoreLAB6_EF.Models;

namespace NetCoreLAB6_EF.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            Console.WriteLine($"Index - Loading {categories.Count} categories");

            // In ra console để debug
            foreach (var cat in categories)
            {
                Console.WriteLine($"Category: {cat.Id} - {cat.Name} - {cat.Status} - {cat.CreateDate}");
            }

            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,CreateDate")] Category category)
        {
            // DEBUG CHI TIẾT
            Console.WriteLine("=== DEBUG CREATE CATEGORY ===");
            Console.WriteLine($"ModelState IsValid: {ModelState.IsValid}");

            // In tất cả lỗi ModelState
            foreach (var key in ModelState.Keys)
            {
                var state = ModelState[key];
                foreach (var error in state.Errors)
                {
                    Console.WriteLine($"ERROR - {key}: {error.ErrorMessage}");
                }
            }

            // In giá trị binding
            Console.WriteLine($"Id: {category.Id}");
            Console.WriteLine($"Name: {category.Name}");
            Console.WriteLine($"Status: {category.Status}");
            Console.WriteLine($"CreateDate: {category.CreateDate}");

            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("Adding to context...");
                    _context.Add(category);

                    Console.WriteLine("Saving changes...");
                    int result = await _context.SaveChangesAsync();
                    Console.WriteLine($"SaveChanges result: {result} records affected");

                    // KIỂM TRA NGAY LẬP TỨC
                    var newCount = await _context.Categories.CountAsync();
                    Console.WriteLine($"Categories count after save: {newCount}");

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine($"DB Update Error: {dbEx.Message}");
                    Console.WriteLine($"Inner Exception: {dbEx.InnerException?.Message}");
                    ModelState.AddModelError("", $"Database error: {dbEx.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }

            return View(category);
        }
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,CreateDate")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
