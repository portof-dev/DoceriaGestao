using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoceriaGestao.Models;
using DoceriaGestao.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DoceriaGestao.Repositories.Interface;
using System.Runtime.CompilerServices;

namespace DoceriaGestao.Controllers
{
    public class InsumosController : Controller
    {

        private readonly IInsumoRepository _insumoRepository;

        public InsumosController(IInsumoRepository insumoRepository)
        {
            _insumoRepository = insumoRepository;
        }

         [HttpGet]
            public IActionResult Create()
        {
            return View();
        }
    


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsumoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var  insumo = new Insumo
                {
                    NomeDoProduto = viewModel.NomeDoProduto,
                    PrecoCompra = viewModel.PrecoCompra,
                    QuantidadeItens = viewModel.QuantidadeItens,
                    ValorMedida = viewModel.ValorMedida,
                    Unidade = Enum.Parse<UnidadeMedida> (viewModel.UnidadeMedida!)
                };

                await _insumoRepository.AddAsync(insumo);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        public async Task <IActionResult> Index()
        {
            var Insumos = await _insumoRepository.GetAllAsync();
            return View(Insumos);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id) //*** METODO PARA EDITAR OS PRODUTOS
        {
            var insumo = await _insumoRepository.GetByIdAsync(id);

            if (insumo == null)
            {
                return NotFound();
            }
            // *** Transforma a model(banco) em viewModel(tela)
            var viewModel = new InsumoViewModel
            {
                Id = insumo.Id,
                NomeDoProduto = insumo.NomeDoProduto,
                PrecoCompra = insumo.PrecoCompra,
                QuantidadeItens = insumo.QuantidadeItens,
                ValorMedida = insumo.ValorMedida,
                UnidadeMedida = insumo.Unidade.ToString()
            };
            return View(viewModel);
        }

        [HttpPost] //*** RECEBE OS NOVOS DADOS E SALVA NO BANCO
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InsumoViewModel viewModel)
        {
            if (id != viewModel.Id)   return NotFound();

            if (ModelState.IsValid)
            {
                var insumo = new Insumo
                {
                    Id = viewModel.Id,
                    NomeDoProduto = viewModel.NomeDoProduto,
                    PrecoCompra = viewModel.PrecoCompra,
                    QuantidadeItens = viewModel.QuantidadeItens,
                    ValorMedida = viewModel.ValorMedida,
                    Unidade  = Enum.Parse<UnidadeMedida>(viewModel.UnidadeMedida!)
                };

                await _insumoRepository.UpdateAsync(insumo);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
                
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var insumo = await _insumoRepository.GetByIdAsync(id);
            if (insumo == null)
            
            return NotFound();
            
                
            return View(insumo); //** passa o insumo direto para mostrar os detalhes na tela
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _insumoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}