using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DoceriaGestao.Data;
using DoceriaGestao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace DoceriaGestao.Controllers
{
    
    public class ReceitaController : Controller
    {
        private readonly AppDbContext _context;

        public ReceitaController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Create()
        {   

            //BUSCA OS INSUMOS PARA PREENCHER o dropdown
            var insumos = _context.Insumos.OrderBy(i => i.NomeDoProduto).ToList();


            //*** PASSA A LISTA PARA A VIEW ATRAVES DA VIEW MODEL
           ViewBag.InsumoId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(insumos, "Id", "NomeDoProduto");
            

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


        [HttpPost]
        public async Task <IActionResult> Create(Receita receita, int InsumoId, decimal QuantidadeUtilizada)
        {
            if (ModelState.IsValid)         //*** salva a receita para depois gerar o ID
            {
                _context.Receitas.Add(receita);
                await _context.SaveChangesAsync();
            

            var primeiroIngrediente = new ReceitaIngrediente
            {
                ReceitaId = receita.Id,
                InsumoId = InsumoId,
                QuantidadeUtilizada = QuantidadeUtilizada
            };


            _context.ReceitaIngredientes.Add(primeiroIngrediente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        var insumos = _context.Insumos.OrderBy(i => i.NomeDoProduto).ToList();

        ViewBag.InsumoId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(insumos, "Id", "NomeDoProduto");


        return View(receita);

         }

    }

    
}