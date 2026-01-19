using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoceriaGestao.Data;
using DoceriaGestao.Models;
using DoceriaGestao.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;


namespace DoceriaGestao.Repositories.Implementations
{
    public class InsumoRepository : IInsumoRepository
    {
        private readonly AppDbContext _context;


        public InsumoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Insumo>> GetAllAsync() 
        => await _context.Insumos.ToListAsync();

        public async Task<Insumo?> GetByIdAsync(int id)
        => await _context.Insumos.FindAsync(id)  ;
        

        public async Task AddAsync(Insumo insumo)
        {
            await _context.Insumos.AddAsync(insumo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Insumo insumo)
        {
            _context.Insumos.Update( insumo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (int id)
        {
            var insumo = await GetByIdAsync(id);
            if (insumo != null)
            {
                _context.Insumos.Remove(insumo);
                await _context.SaveChangesAsync();
            }
        }
    }
}