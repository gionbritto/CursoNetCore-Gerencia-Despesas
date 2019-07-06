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
    public class TipoDespesasController : Controller
    {
        private readonly Contexto _context;

        public TipoDespesasController(Contexto context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TTipoDespesa.OrderBy(x => x.Nome).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await _context.TTipoDespesa.Where(x => x.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await _context.TTipoDespesa.ToListAsync());
        }

        public JsonResult AdicionarTipoDespesa(string txtDespesa)
        {
            if (!String.IsNullOrEmpty(txtDespesa))
            {
                if(!_context.TTipoDespesa.Any(td => td.Nome.ToUpper() == txtDespesa.ToUpper()))
                {
                    TipoDespesa tipoDespesa = new TipoDespesa();
                    tipoDespesa.Nome = txtDespesa;
                    _context.Add(tipoDespesa);
                    _context.SaveChanges();

                    return Json(true);
                }
               
            }
            return Json(false);
        }

        public async Task<JsonResult> TipoDespesaExiste(string nome)
        {
            if(await _context.TTipoDespesa.AnyAsync(x => x.Nome.ToUpper() == nome.ToUpper()))
            {
                return Json("Este tipo de despesa já foi cadastrado!");
            }

            return Json(true);
        }

        // GET: TipoDespesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDespesaId,Nome")] TipoDespesa tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = tipoDespesa.Nome + " foi cadastrado com sucesso";

                tipoDespesa.TipoDespesaId = Guid.NewGuid();
                _context.Add(tipoDespesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesa);
        }

        // GET: TipoDespesas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDespesa = await _context.TTipoDespesa.FindAsync(id);
            if (tipoDespesa == null)
            {
                return NotFound();
            }
            return View(tipoDespesa);
        }

        // POST: TipoDespesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TipoDespesaId,Nome")] TipoDespesa tipoDespesa)
        {
            if (id != tipoDespesa.TipoDespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = tipoDespesa.Nome + " foi atualizado com sucesso";
                    _context.Update(tipoDespesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDespesaExists(tipoDespesa.TipoDespesaId))
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
            return View(tipoDespesa);
        }

        // POST: TipoDespesas/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var tipoDespesa = await _context.TTipoDespesa.FindAsync(id);
            TempData["Confirmacao"] = tipoDespesa.Nome + " foi excluído com sucesso";
            _context.TTipoDespesa.Remove(tipoDespesa);
            await _context.SaveChangesAsync();
            return Json(tipoDespesa.Nome + " excluido com sucesso");
        }

        private bool TipoDespesaExists(Guid id)
        {
            return _context.TTipoDespesa.Any(e => e.TipoDespesaId == id);
        }
    }
}
