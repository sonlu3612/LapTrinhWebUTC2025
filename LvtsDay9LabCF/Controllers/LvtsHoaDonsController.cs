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
    public class LvtsHoaDonsController : Controller
    {
        private readonly LvtsAppDataContext _context;

        public LvtsHoaDonsController(LvtsAppDataContext context)
        {
            _context = context;
        }

        // GET: LvtsHoaDons
        public async Task<IActionResult> Index()
        {
            var lvtsAppDataContext = _context.HoaDons.Include(l => l.KhachHang);
            return View(await lvtsAppDataContext.ToListAsync());
        }

        // GET: LvtsHoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsHoaDon = await _context.HoaDons
                .Include(l => l.KhachHang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsHoaDon == null)
            {
                return NotFound();
            }

            return View(lvtsHoaDon);
        }

        // GET: LvtsHoaDons/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "ID", "DiaChi");
            return View();
        }

        // POST: LvtsHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] LvtsHoaDon lvtsHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvtsHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "ID", "DiaChi", lvtsHoaDon.MaKhachHang);
            return View(lvtsHoaDon);
        }

        // GET: LvtsHoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsHoaDon = await _context.HoaDons.FindAsync(id);
            if (lvtsHoaDon == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "ID", "DiaChi", lvtsHoaDon.MaKhachHang);
            return View(lvtsHoaDon);
        }

        // POST: LvtsHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] LvtsHoaDon lvtsHoaDon)
        {
            if (id != lvtsHoaDon.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvtsHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvtsHoaDonExists(lvtsHoaDon.ID))
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
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "ID", "DiaChi", lvtsHoaDon.MaKhachHang);
            return View(lvtsHoaDon);
        }

        // GET: LvtsHoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsHoaDon = await _context.HoaDons
                .Include(l => l.KhachHang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsHoaDon == null)
            {
                return NotFound();
            }

            return View(lvtsHoaDon);
        }

        // POST: LvtsHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvtsHoaDon = await _context.HoaDons.FindAsync(id);
            if (lvtsHoaDon != null)
            {
                _context.HoaDons.Remove(lvtsHoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LvtsHoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.ID == id);
        }
    }
}
