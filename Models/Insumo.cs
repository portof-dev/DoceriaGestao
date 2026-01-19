using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoceriaGestao.Models
{
    public class Insumo
    {
        public int Id {get;set;}
        public string? NomeDoProduto {get;set;}
        public decimal PrecoCompra {get;set;}
        public decimal QuantidadeCompra {get;set;}
        
        public  UnidadeMedida Unidade {get;set;}
    }
}