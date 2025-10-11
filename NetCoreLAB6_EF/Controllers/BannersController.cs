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
    public class BannersController : Controller
    {
        private readonly AppDbContext _context;

        public BannersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Banners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banners.ToListAsync());
        }

        // GET: Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Status")] Banner banner)
        {
            Console.WriteLine($"Starting Create action for banner: {banner}");

            var files = HttpContext.Request.Form.Files;
            Console.WriteLine($"Number of files received: {files.Count}");

            if (files.Count > 0 && files[0]?.Length > 0)
            {
                try
                {
                    var file = files[0];
                    var fileName = Path.GetFileName(file.FileName).Replace(" ", "_").ToLower();
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Banner");
                    var filePath = Path.Combine(folderPath, fileName);
                    Console.WriteLine($"Attempting to save file to: {filePath}");

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                        Console.WriteLine($"Created directory: {folderPath}");
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        Console.WriteLine($"File {fileName} uploaded successfully to {filePath}");
                    }

                    banner.Image = fileName;
                    Console.WriteLine($"Assigned Image property: {banner.Image}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error uploading file: {ex.Message}");
                    ModelState.AddModelError("", "Lỗi khi upload file. Vui lòng thử lại.");
                    return View(banner);
                }
            }
            else
            {
                ModelState.AddModelError("Image", "Vui lòng chọn một tệp ảnh.");
            }

            if (!string.IsNullOrEmpty(banner.Image))
            {
                ModelState.Remove("Image"); 
            }

            if (ModelState.IsValid)
            {
                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }
        // GET: Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Banner banner, IFormFile? NewImage)
        {
            if (id != banner.Id)
                return NotFound();

            var existingBanner = await _context.Banners.FirstOrDefaultAsync(b => b.Id == id);
            if (existingBanner == null)
                return NotFound();

            if (NewImage != null && NewImage.Length > 0)
            {
                var fileName = Path.GetFileName(NewImage.FileName).Replace(" ", "_").ToLower();
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Banner");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await NewImage.CopyToAsync(stream);
                }

                existingBanner.Image = fileName;
            }

            // Cập nhật thủ công các thuộc tính khác
            existingBanner.Name = banner.Name;
            existingBanner.Description = banner.Description;
            existingBanner.Status = banner.Status;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {
                _context.Banners.Remove(banner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
            return _context.Banners.Any(e => e.Id == id);
        }
    }
}
