using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoceriaGestao.ViewModels
{
    public class InsumoViewModel
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O nome do insumo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [Display(Name ="Nome do Insumo")]
        public string? NomeDoProduto{get;set;}
        [Required(ErrorMessage = "Informe o preço de compra.")]
        [Range(0.01, 10000, ErrorMessage = "O Preço dever maior que zero.")]
        [Display(Name = "Preço de Compra (R$)")]
        public decimal PrecoCompra {get;set;}

        [Required(ErrorMessage = "Informe a quantidade Comprada.")]
        [Range(0.01, 100000, ErrorMessage = "A quantidade deve ser maior que zero.")]
        [Display(Name = "Quantidade de Compra")]

         public int QuantidadeItens {get;set;}
         [Required(ErrorMessage = "Informe o volume de itens Comprados")]
         [Range(0.01,10000,ErrorMessage = "O volume deve ser maior que 0")]
         [Display (Name ="volume De Compra")]
        public decimal ValorMedida {get;set;}
        [Required(ErrorMessage = "Selecione a unidade de medida.")]
        [Display(Name = "Unidade (g,ml,un,kg)")]
        public string? UnidadeMedida {get;set;}
    }
}