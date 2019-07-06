using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Models
{
    public class TipoDespesa
    {
        public Guid TipoDespesaId { get; set; }

        [Required(ErrorMessage =("Campo Obrigatório"))]
        [StringLength(50, ErrorMessage =("Use até 50 caracteres"))]
        [Remote("TipoDespesaExiste", "TipoDespesas")]
        public string Nome { get; set; }

        public ICollection<Despesa> Despesas { get; set; }
    }
}
