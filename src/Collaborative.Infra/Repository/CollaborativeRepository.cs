﻿using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Infra.Repository
{
    public class CollaborativeRepository : BaseRepository<Collab>, ICollaborativeRepository
    {
        private readonly EntityContext _entityContext;

        public CollaborativeRepository(EntityContext entityContext) 
            : base (entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<Collab>> GetAllAsync()
        {
            var collabs = await _entityContext.Collaboratives
                .Where(x => x.ClosingDate == null)
                .AsNoTracking()
                .ToListAsync();

            return collabs;
               
        }

        public async Task<IEnumerable<Collab>> GetAllClosed()
        {
            var collabs = _entityContext.Collaboratives
                .Where(x => x.ClosingDate != null)
                .AsNoTracking()
                .ToListAsync();

            return await collabs;
        }

        public async Task<Collab> GetByCnpj(string cnpj)
        {
            var collab = _entityContext.Collaboratives
                .Where(x => x.CNPJ == cnpj && x.ClosingDate == null)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }

        public async Task<Collab> GetByCpf(string cpf)
        {
            var collab = _entityContext.Collaboratives
                .Where(x => x.CPF == cpf && x.ClosingDate == null)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }

        public async Task<Collab> GetByIdAsync(int id)
        {
            var collab = await _entityContext.Collaboratives
                .Where(x => x.Id.Equals(id) && x.ClosingDate == null)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return collab;
        }

        public async Task<Collab> GetByName(string name)
        {
            var collab = _entityContext.Collaboratives
                .Where(x => x.Name == name && x.ClosingDate == null)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }

        public async Task<Collab> GetByMail(string mail)
        {
            var collab = _entityContext.Collaboratives
                .Where(x => x.Email == mail && x.ClosingDate == null)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }
    }
}
