using GerenciamentoDespesas.Infra;
using GerenciamentoDespesas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.ViewComponents
{
    public class EstatisticasViewComponent : ViewComponent
    {
        private readonly Contexto _contexto;

        public EstatisticasViewComponent(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IViewComponentResult Invoke()
        {
            EstatisticasViewModel estatisticas = new EstatisticasViewModel();
            estatisticas.MenorDespesa = _contexto.TDespesa.Min(x => x.Valor);
            estatisticas.MaiorDespesa = _contexto.TDespesa.Max(x => x.Valor);
            estatisticas.QuantidadeDespesas = _contexto.TDespesa.Count();

            return View(estatisticas);
        }
    }
}
