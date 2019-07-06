using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDespesas.Infra;
using GerenciamentoDespesas.Models;
using X.PagedList;
using GerenciamentoDespesas.ViewModels;

namespace GerenciamentoDespesas.Controllers
{
    public class DespesasController : Controller
    {
        private readonly Contexto _context;

        public DespesasController(Contexto context)
        {
            _context = context;
        }

        // GET: Despesas
        //alteracao para que a index me faça a paginacao
        public async Task<IActionResult> Index(int? pagina)
        {
            const int itensPagina = 10;
            int numeroPagina = (pagina ?? 1);

            ViewData["Meses"] = new SelectList(_context.TMes.Where(x => x.MesId == x.Salario.MesId).OrderBy(x => x.Ordem), "Ordem", "Nome");
            var contexto = _context.TDespesa.Include(d => d.Mes).OrderBy(d => d.Mes.Ordem).Include(d => d.TipoDespesa);
            return View(await contexto.ToPagedListAsync(numeroPagina, itensPagina));
        }

        // GET: Despesas/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.TMes.OrderBy(x => x.Ordem), "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(_context.TTipoDespesa, "TipoDespesaId", "Nome");
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespesaId,MesId,TipoDespesaId,Valor")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = "Despesa cadastrada com sucesso!";
                despesa.DespesaId = Guid.NewGuid();
                _context.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.TMes, "MesId", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TTipoDespesa, "TipoDespesaId", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.TDespesa.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.TMes.OrderBy(x => x.Ordem), "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(_context.TTipoDespesa, "TipoDespesaId", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DespesaId,MesId,TipoDespesaId,Valor")] Despesa despesa)
        {
            if (id != despesa.DespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesa);
                    await _context.SaveChangesAsync();
                    TempData["Confirmacao"] = "Despesa atualizada com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaExists(despesa.DespesaId))
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
            ViewData["MesId"] = new SelectList(_context.TMes, "MesId", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TTipoDespesa, "TipoDespesaId", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

       
        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var despesa = await _context.TDespesa.FindAsync(id);
            _context.TDespesa.Remove(despesa);
            await _context.SaveChangesAsync();
            TempData["Confirmacao"] = "Despesa excluída com successo!";
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaExists(Guid id)
        {
            return _context.TDespesa.Any(e => e.DespesaId == id);
        }

        public JsonResult GastosTotaisMes(int ordem)
        {
            GastosTotaisMesViewModel gastos = new GastosTotaisMesViewModel();
            gastos.ValorTotalGasto = _context.TDespesa.Where(x => x.Mes.Ordem == ordem).Sum(x => x.Valor);
            gastos.Salario = _context.TSalario.Where(x => x.Mes.Ordem == ordem).Select(x => x.Valor).FirstOrDefault();

            return Json(gastos);

        }

        public JsonResult GastosMes(int ordem)
        {
            var query = from d in _context.TDespesa
                        where d.Mes.Ordem == ordem
                        group d by d.TipoDespesa.Nome into g
                        select new
                        {
                            TiposDespesas = g.Key,
                            Valores = g.Sum(d => d.Valor)
                        };
            return Json(query);
        }

        public JsonResult GastosTotais()
        {
            var query = _context.TDespesa
                        .OrderBy(x => x.Mes.Ordem)
                        .GroupBy(x => x.Mes.Ordem)
                        .Select(x => new
                        {
                            NomeMeses = x.Select(m => m.Mes.Nome).Distinct(),
                            Valores = x.Sum(d => d.Valor)
                        });
            return Json(query);
        }
    }
}
