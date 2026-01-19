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
    }
}