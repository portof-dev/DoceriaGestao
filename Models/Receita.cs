using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoceriaGestao.Models
{
    public class Receita
    {   

        public int Id {get;set;}   
        public string? NomeReceita {get;set;}
         
        public int Rendimento {get;set;}


        //*** lista de ingredientes que vao compor as receitas 
        public List<ReceitaIngrediente> Ingredientes {get;set;} = new List<ReceitaIngrediente>();

        //*** Calculo do custo total da soma de todos os igredientes
        public decimal CustoTotal => Ingredientes.Sum(x => x.PrecoProporcional);


        //*** quanto custa cada unidade/pedaço para o chef
        public decimal CustoPorRendimento => Rendimento > 0 ? CustoTotal / Rendimento : 0;
    }
}