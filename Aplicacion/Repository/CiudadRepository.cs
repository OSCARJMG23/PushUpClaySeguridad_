using Dominio.Entities;
using Dominio.Interfaces;
using Aplicacion.Repository;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
    {
        private readonly ApiContext _context;

        public CiudadRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Ciudad> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Ciudads as IQueryable<Ciudad>;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Id.Equals(int.Parse(search)));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
            return (totalRegistros, registros);
        }
    }
}