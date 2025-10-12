using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly QLBanHangContext _context;

        public SanPhamsController(QLBanHangContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SanPhams.Include(s => s.MaLoaiNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.MaLoaiNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPhams, "Id", "MaLoai");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] SanPham sanPham)
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0 && files[0]?.Length > 0)
            {
                var file = files[0];
                var fileName = Path.GetFileName(file.FileName).Replace(" ", "_").ToLower();
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SanPham");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                sanPham.HinhAnh = fileName;
            }

            if (!string.IsNullOrEmpty(sanPham.HinhAnh))
                ModelState.Remove("HinhAnh");

                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPhams, "Id", "MaLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] SanPham sanPham, IFormFile? NewImage)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            var existingSanPham = await _context.SanPhams.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            if (existingSanPham == null)
            {
                return NotFound();
            }

            string? imageFileName = existingSanPham.HinhAnh;

            if (NewImage != null && NewImage.Length > 0)
            {
                var fileName = Path.GetFileName(NewImage.FileName).Replace(" ", "_").ToLower();
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SanPham");
                var filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await NewImage.CopyToAsync(stream);
                }

                imageFileName = fileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sanPham.HinhAnh = imageFileName;
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
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
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPhams, "Id", "MaLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.MaLoaiNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
