using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDespesas.Models
{
    public class Salario
    {
        public Guid SalarioId { get; set; }

        public Guid MesId { get; set; }

        public Mes Mes { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage ="Valor Inválido!")]
        public double Valor { get; set; }
    }
}