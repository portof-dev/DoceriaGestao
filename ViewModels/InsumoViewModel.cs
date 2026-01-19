using System;
using System.Collections.Generic;
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
    }
}