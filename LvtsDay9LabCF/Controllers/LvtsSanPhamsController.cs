using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LvtsDay9LabCF.Data;
using LvtsDay9LabCF.Models;

namespace LvtsDay9LabCF.Controllers
{
    public class LvtsSanPhamsController : Controller
    {
        private readonly LvtsAppDataContext _context;

        public LvtsSanPhamsController(LvtsAppDataContext context)
        {
            _context = context;
        }

        // GET: LvtsSanPhams
        public async Task<IActionResult> Index()
        {
            var lvtsAppDataContext = _context.SanPhams.Include(l => l.LoaiSanPham);
            return View(await lvtsAppDataContext.ToListAsync());
        }

        // GET: LvtsSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsSanPham = await _context.SanPhams
                .Include(l => l.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsSanPham == null)
            {
                return NotFound();
            }

            return View(lvtsSanPham);
        }

        // GET: LvtsSanPhams/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPhams, "ID", "MaLoai");
            return View();
        }

        // POST: LvtsSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] LvtsSanPham lvtsSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvtsSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPhams, "ID", "MaLoai", lvtsSanPham.MaLoai);
            return View(lvtsSanPham);
        }

        // GET: LvtsSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsSanPham = await _context.SanPhams.FindAsync(id);
            if (lvtsSanPham == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPhams, "ID", "MaLoai", lvtsSanPham.MaLoai);
            return View(lvtsSanPham);
        }

        // POST: LvtsSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] LvtsSanPham lvtsSanPham)
        {
            if (id != lvtsSanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvtsSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvtsSanPhamExists(lvtsSanPham.ID))
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
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPhams, "ID", "MaLoai", lvtsSanPham.MaLoai);
            return View(lvtsSanPham);
        }

        // GET: LvtsSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsSanPham = await _context.SanPhams
                .Include(l => l.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsSanPham == null)
            {
                return NotFound();
            }

            return View(lvtsSanPham);
        }

        // POST: LvtsSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvtsSanPham = await _context.SanPhams.FindAsync(id);
            if (lvtsSanPham != null)
            {
                _context.SanPhams.Remove(lvtsSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LvtsSanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.ID == id);
        }
    }
}
