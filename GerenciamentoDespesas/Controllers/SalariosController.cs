using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDespesas.Infra;
using GerenciamentoDespesas.Models;

namespace GerenciamentoDespesas.Controllers
{
    public class SalariosController : Controller
    {
        private readonly Contexto _context;

        public SalariosController(Contexto context)
        {
            _context = context;
        }

        // GET: Salarios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contexto = _context.TSalario.Include(s => s.Mes).OrderBy(x => x.Mes.Ordem);
            return View(await contexto.ToListAsync());
        }

        //pesquisa o salario pelo mes
        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await _context.TSalario
                                    .Include(x => x.Mes)
                                    .Where(x => x.Mes.Nome.ToUpper()
                                    .Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await _context.TSalario.ToListAsync());
        }

        // GET: Salarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.TSalario
                .Include(s => s.Mes)
                .FirstOrDefaultAsync(m => m.SalarioId == id);
            if (salario == null)
            {
                return NotFound();
            }

            return View(salario);
        }

        // GET: Salarios/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.TMes.Where(x => x.MesId != x.Salario.MesId).OrderBy(x => x.Ordem), "MesId", "Nome");
            return View();
        }

        // POST: Salarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalarioId,MesId,Valor")] Salario salario)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = "Salário cadastrado com sucesso!";
                salario.SalarioId = Guid.NewGuid();
                _context.Add(salario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.TMes.Where(x => x.MesId != x.Salario.MesId), "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        // GET: Salarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.TSalario.FindAsync(id);
            if (salario == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.TMes.Where(x => x.MesId == salario.MesId), "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        // POST: Salarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SalarioId,MesId,Valor")] Salario salario)
        {
            if (id != salario.SalarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salario);
                    await _context.SaveChangesAsync();
                    TempData["Confirmacao"] = "Salário atualizado com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarioExists(salario.SalarioId))
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
            ViewData["MesId"] = new SelectList(_context.TMes.Where(x => x.MesId == salario.MesId), "MesId", "Nome", salario.MesId);
            return View(salario);
        }

       
        // POST: Salarios/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var salario = await _context.TSalario.FindAsync(id);
            _context.TSalario.Remove(salario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarioExists(Guid id)
        {
            return _context.TSalario.Any(e => e.SalarioId == id);
        }
    }
}
