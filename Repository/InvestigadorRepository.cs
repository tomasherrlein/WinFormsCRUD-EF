using ApplicationBusiness;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InvestigadorRepository : IRepository<Investigador>
    {
        private AsistenciaInvestigadoresDbContext _dbContext;

        public InvestigadorRepository(AsistenciaInvestigadoresDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Investigador entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var investigador = await _dbContext.Investigadores.FindAsync(id);
            _dbContext.Investigadores.Remove(investigador);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Investigador entity)
        {
            var investigador = await _dbContext.Investigadores.FindAsync(entity.Idinvestigador);
            
            investigador.Nombre = entity.Nombre;
            investigador.Iddepartamentos = entity.Iddepartamentos;
            _dbContext.Entry(investigador).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Investigador>> GetAllAsync()
        {
            return await _dbContext.Investigadores.ToListAsync();
        }

        public async Task<Investigador> GetByIdAsync(int id)
        {
            var investigador = await _dbContext.Investigadores.FindAsync(id);
            return investigador;
        }
    }
}
