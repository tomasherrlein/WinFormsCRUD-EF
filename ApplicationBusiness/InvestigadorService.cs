using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBusiness
{
    internal class InvestigadorService
    {
        private readonly IRepository<Investigador> _repository;

        public InvestigadorService(IRepository<Investigador> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Investigador entity)
        {
            if (string.IsNullOrEmpty(entity.Nombre))
            {
                throw new Exception("El nombre del investigador es obligatorio");
            }

            await _repository.AddAsync(entity);
        }

        public async Task EditAsync(Investigador entity)
        {
            if (string.IsNullOrEmpty(entity.Nombre))
            {
                throw new Exception("El nombre del investigador es obligatorio");
            }

            if (_repository.GetByIdAsync(entity.Idinvestigador) == null)
            {
                throw new Exception("Investigador no existente");
            }

            await _repository.EditAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            if (_repository.GetByIdAsync(id) == null)
            {
                throw new Exception("Investigador no existente");
            }

            await _repository.DeleteAsync(id);
        }

    }
}
