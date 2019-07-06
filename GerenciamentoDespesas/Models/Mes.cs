using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Models
{
    public class Mes
    {
        public Guid MesId { get; set; }

        public string Nome { get; set; }

        public int Ordem { get; set; }

        public ICollection<Despesa> Despesas { get; set; }

        public Salario Salario { get; set; }
    }
}
