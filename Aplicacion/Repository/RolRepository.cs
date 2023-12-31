using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;



namespace Aplicacion.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly ApiContext _context;

        public RolRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}