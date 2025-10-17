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
    public class LvtsQuanTrisController : Controller
    {
        private readonly LvtsAppDataContext _context;

        public LvtsQuanTrisController(LvtsAppDataContext context)
        {
            _context = context;
        }

        // GET: LvtsQuanTris
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuanTris.ToListAsync());
        }

        // GET: LvtsQuanTris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsQuanTri = await _context.QuanTris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsQuanTri == null)
            {
                return NotFound();
            }

            return View(lvtsQuanTri);
        }

        // GET: LvtsQuanTris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LvtsQuanTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TaiKhoan,MatKhau,TrangThai")] LvtsQuanTri lvtsQuanTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvtsQuanTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lvtsQuanTri);
        }

        // GET: LvtsQuanTris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsQuanTri = await _context.QuanTris.FindAsync(id);
            if (lvtsQuanTri == null)
            {
                return NotFound();
            }
            return View(lvtsQuanTri);
        }

        // POST: LvtsQuanTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TaiKhoan,MatKhau,TrangThai")] LvtsQuanTri lvtsQuanTri)
        {
            if (id != lvtsQuanTri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvtsQuanTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvtsQuanTriExists(lvtsQuanTri.ID))
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
            return View(lvtsQuanTri);
        }

        // GET: LvtsQuanTris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvtsQuanTri = await _context.QuanTris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lvtsQuanTri == null)
            {
                return NotFound();
            }

            return View(lvtsQuanTri);
        }

        // POST: LvtsQuanTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvtsQuanTri = await _context.QuanTris.FindAsync(id);
            if (lvtsQuanTri != null)
            {
                _context.QuanTris.Remove(lvtsQuanTri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LvtsQuanTriExists(int id)
        {
            return _context.QuanTris.Any(e => e.ID == id);
        }
    }
}
