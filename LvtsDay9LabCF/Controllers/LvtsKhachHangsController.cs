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
    public class LvtsKhachHangsController : Controller
    {
        private readonly LvtsAppDataContext _context;

        public LvtsKhachHangsController(LvtsAppDataContext context)
        {
            _context = context;
        }

        // GET: LvtsKhachHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhachHangs.ToListAsync());
        }

        // GET: LvtsKhachHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsKhachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsKhachHang == null)
            {
                return NotFound();
            }

            return View(lvtsKhachHang);
        }

        // GET: LvtsKhachHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LvtsKhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaKhachHang,HoTenKhachHang,Email,MatKhau,DienThoai,DiaChi,NgayDangKy,TrangThai")] LvtsKhachHang lvtsKhachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvtsKhachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lvtsKhachHang);
        }

        // GET: LvtsKhachHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsKhachHang = await _context.KhachHangs.FindAsync(id);
            if (lvtsKhachHang == null)
            {
                return NotFound();
            }
            return View(lvtsKhachHang);
        }

        // POST: LvtsKhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaKhachHang,HoTenKhachHang,Email,MatKhau,DienThoai,DiaChi,NgayDangKy,TrangThai")] LvtsKhachHang lvtsKhachHang)
        {
            if (id != lvtsKhachHang.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvtsKhachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvtsKhachHangExists(lvtsKhachHang.ID))
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
            return View(lvtsKhachHang);
        }

        // GET: LvtsKhachHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsKhachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsKhachHang == null)
            {
                return NotFound();
            }

            return View(lvtsKhachHang);
        }

        // POST: LvtsKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvtsKhachHang = await _context.KhachHangs.FindAsync(id);
            if (lvtsKhachHang != null)
            {
                _context.KhachHangs.Remove(lvtsKhachHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LvtsKhachHangExists(int id)
        {
            return _context.KhachHangs.Any(e => e.ID == id);
        }
    }
}
