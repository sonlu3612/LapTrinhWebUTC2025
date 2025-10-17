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
    public class LvtsChiTietHoaDonsController : Controller
    {
        private readonly LvtsAppDataContext _context;

        public LvtsChiTietHoaDonsController(LvtsAppDataContext context)
        {
            _context = context;
        }

        // GET: LvtsChiTietHoaDons
        public async Task<IActionResult> Index()
        {
            var lvtsAppDataContext = _context.ChiTietHoaDons.Include(l => l.HoaDon).Include(l => l.SanPham);
            return View(await lvtsAppDataContext.ToListAsync());
        }

        // GET: LvtsChiTietHoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsChiTietHoaDon = await _context.ChiTietHoaDons
                .Include(l => l.HoaDon)
                .Include(l => l.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsChiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(lvtsChiTietHoaDon);
        }

        // GET: LvtsChiTietHoaDons/Create
        public IActionResult Create()
        {
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon");
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "MaSanPham");
            return View();
        }

        // POST: LvtsChiTietHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] LvtsChiTietHoaDon lvtsChiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvtsChiTietHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon", lvtsChiTietHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "MaSanPham", lvtsChiTietHoaDon.SanPhamID);
            return View(lvtsChiTietHoaDon);
        }

        // GET: LvtsChiTietHoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsChiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (lvtsChiTietHoaDon == null)
            {
                return NotFound();
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon", lvtsChiTietHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "MaSanPham", lvtsChiTietHoaDon.SanPhamID);
            return View(lvtsChiTietHoaDon);
        }

        // POST: LvtsChiTietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] LvtsChiTietHoaDon lvtsChiTietHoaDon)
        {
            if (id != lvtsChiTietHoaDon.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvtsChiTietHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvtsChiTietHoaDonExists(lvtsChiTietHoaDon.ID))
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
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon", lvtsChiTietHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "MaSanPham", lvtsChiTietHoaDon.SanPhamID);
            return View(lvtsChiTietHoaDon);
        }

        // GET: LvtsChiTietHoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsChiTietHoaDon = await _context.ChiTietHoaDons
                .Include(l => l.HoaDon)
                .Include(l => l.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsChiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(lvtsChiTietHoaDon);
        }

        // POST: LvtsChiTietHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvtsChiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (lvtsChiTietHoaDon != null)
            {
                _context.ChiTietHoaDons.Remove(lvtsChiTietHoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LvtsChiTietHoaDonExists(int id)
        {
            return _context.ChiTietHoaDons.Any(e => e.ID == id);
        }
    }
}
