using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDespesas.Models
{
    public class Despesa
    {
        public Guid DespesaId { get; set; }

        public Guid MesId { get; set; }

        public Guid TipoDespesaId { get; set; }

        public Mes Mes { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor Inválido!")]
        public double Valor { get; set; }

        public TipoDespesa TipoDespesa { get; set; }

    }
}