using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.Data;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class ChiTietHoaDonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChiTietHoaDonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChiTietHoaDons
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChiTietHoaDons.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ChiTietHoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Create
        public IActionResult Create()
        {
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon");
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "HinhAnh");
            return View();
        }

        // POST: ChiTietHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon", chiTietHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "HinhAnh", chiTietHoaDon.SanPhamID);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon", chiTietHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "HinhAnh", chiTietHoaDon.SanPhamID);
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] ChiTietHoaDon chiTietHoaDon)
        {
            if (id != chiTietHoaDon.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHoaDonExists(chiTietHoaDon.ID))
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
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "MaHoaDon", chiTietHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "HinhAnh", chiTietHoaDon.SanPhamID);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (chiTietHoaDon != null)
            {
                _context.ChiTietHoaDons.Remove(chiTietHoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHoaDonExists(int id)
        {
            return _context.ChiTietHoaDons.Any(e => e.ID == id);
        }
    }
}
