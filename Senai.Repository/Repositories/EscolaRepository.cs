using Microsoft.EntityFrameworkCore;
using Senai.Domain.Entidades;
using Senai.Domain.Interfaces;
using Senai.Repository.Context;

namespace Senai.Repository.Repositories
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly SenaiContext _context;

        public EscolaRepository(SenaiContext context)
        {
            _context = context;
        }
        public List<Escola> BuscarTodos()
        {
            return _context.Escola.ToList();
        }
        public bool Salvar(Escola entity)
        {
            try
            {
                if (entity.Id > 0)
                {
                    _context.Escola.Update(entity);
                }
                else
                {
                    _context.Escola.Add(entity);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Remover(long id)
        {
            var entidade = _context.Escola.FirstOrDefault(c => c.Id == id);
            if (entidade == null)
                return false;

            _context.Escola.Remove(entidade);
            _context.SaveChanges();
            return true;
        }

        //public Escola? BuscarPorId(long id)
        //{
        //    return _context.Escola.FirstOrDefault(c => c.Id == id);
        //}
        //public bool Remover(long id)
        //{
        //    try
        //    {
        //        var escola = BuscarPorId(id);
        //        if (escola != null)
        //        {
        //            _context.Escola.Remove(escola);
        //            _context.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public async Task RemoverPorId(long id)
        //{
        //    var sql = $"DELETE \"Escola\" e WHERE e.\"Id\" = {id}";
        //    await _context.Database.ExecuteSqlRawAsync(sql);
        //}


    }
}
