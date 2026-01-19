
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoceriaGestao.Models;

namespace DoceriaGestao.Repositories.Interface
{
    public interface IInsumoRepository // Interface de serviço onde vou colocar o CRUD 
    {

        //TODO USAMOS O TASK e ASYNC chamamos a programação assincrona que  evita de o sistema travar esperando o DB(Banco de Dados) responder melhorando a performance
        //TODO Deixando assim o sistema livre para fazer outros pedidos enquanto a reposta do DB nao chega

        //TODO O IEnumerable é mais rapido e mais perfomatico que uma list pode ser percorrido por um foreach
        Task<IEnumerable<Insumo>> GetAllAsync(); //*** busca todos os insumos da tabela e entrega como uma lista
        Task<Insumo?> GetByIdAsync(int id); //*** Busca o insumo por  id  
        Task AddAsync(Insumo insumo); //***  Recebe o novo insumo e o insere no banco de dados
        Task UpdateAsync(Insumo insumo); //*** Pega um insumo já existente e salva as altereçoes feitas nele
        Task DeleteAsync(int id); //*** Remove o insumo que tenha o Id selecionado
    }
}