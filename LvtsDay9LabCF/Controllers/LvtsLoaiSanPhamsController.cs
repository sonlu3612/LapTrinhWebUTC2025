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
    public class LvtsLoaiSanPhamsController : Controller
    {
        private readonly LvtsAppDataContext _context;

        public LvtsLoaiSanPhamsController(LvtsAppDataContext context)
        {
            _context = context;
        }

        // GET: LvtsLoaiSanPhams
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSanPhams.ToListAsync());
        }

        // GET: LvtsLoaiSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsLoaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(lvtsLoaiSanPham);
        }

        // GET: LvtsLoaiSanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LvtsLoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaLoai,TenLoai,TrangThai")] LvtsLoaiSanPham lvtsLoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvtsLoaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lvtsLoaiSanPham);
        }

        // GET: LvtsLoaiSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsLoaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            if (lvtsLoaiSanPham == null)
            {
                return NotFound();
            }
            return View(lvtsLoaiSanPham);
        }

        // POST: LvtsLoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaLoai,TenLoai,TrangThai")] LvtsLoaiSanPham lvtsLoaiSanPham)
        {
            if (id != lvtsLoaiSanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvtsLoaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvtsLoaiSanPhamExists(lvtsLoaiSanPham.ID))
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
            return View(lvtsLoaiSanPham);
        }

        // GET: LvtsLoaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsLoaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(lvtsLoaiSanPham);
        }

        // POST: LvtsLoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvtsLoaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            if (lvtsLoaiSanPham != null)
            {
                _context.LoaiSanPhams.Remove(lvtsLoaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LvtsLoaiSanPhamExists(int id)
        {
            return _context.LoaiSanPhams.Any(e => e.ID == id);
        }
    }
}
