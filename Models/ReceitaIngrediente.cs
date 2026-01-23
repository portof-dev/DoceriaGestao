using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoceriaGestao.Models
{
    public class ReceitaIngrediente
    {
        public int Id { get; set; }
        public int ReceitaId {get;set;}
        public Receita? Receita { get; set; }
        public int InsumoId { get; set; }
        public Insumo? Insumo { get; set; }
        
        public decimal QuantidadeUtilizada { get; set; }

        public decimal PrecoProporcional => Insumo != null ? Insumo.CustoUnitario * QuantidadeUtilizada : 0;
        }
}