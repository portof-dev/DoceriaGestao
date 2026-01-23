using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoceriaGestao.Models;
using Microsoft.EntityFrameworkCore;

namespace DoceriaGestao.Data
{
    public class AppDbContext : DbContext
{ 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // faz a instancia da classe DbContext com as configuraçoes feitas no program para configurar o Banco
        {
            
        }


        public DbSet<Insumo> Insumos {get;set;} //*** Instanciando a classe para o meu banco de dados 
        public DbSet <Receita> Receitas {get;set;}
        public DbSet <ReceitaIngrediente> ReceitaIngredientes {get;set;}
        
    
}
}