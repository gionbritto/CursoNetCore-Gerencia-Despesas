using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.ViewModels
{
    public class EstatisticasViewModel
    {
        public int QuantidadeDespesas { get; set; }
        public double MenorDespesa { get; set; }
        public double MaiorDespesa { get; set; }
    }
}
