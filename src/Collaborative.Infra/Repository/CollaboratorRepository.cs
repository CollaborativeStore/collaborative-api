﻿using Collaborative.Domain.Models;
using Collaborative.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collaborative.Infra.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Collaborative.Infra.Repository
{
    public class CollaboratorRepository :  BaseRepository<Collaborator>, ICollaboratorRepository
    {
        private readonly EntityContext _entityContext;

        public CollaboratorRepository(EntityContext entityContext) 
            : base (entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<Collaborator>> GetAllAsync()
        {
            var collabs = _entityContext.Collaborators
                .Where(x => x.ClosingDate == null )
                .Include(x => x.Collaborative)
                .AsNoTracking()
                .ToListAsync();

            return await collabs;
        }

        public async Task<IEnumerable<Collaborator>> GetAllByCollaborativeIdAsync(int id)
        {
            var collabs = _entityContext.Collaborators
                .Where(x => x.ClosingDate == null && x.CollaborativeId.Equals(id))
                .AsNoTracking()
                .ToListAsync();

            return await collabs;
        }

        public async Task<IEnumerable<Collaborator>> GetAllClosed()
        {
            var collabs = _entityContext.Collaborators
                .Where(x => x.ClosingDate != null)
                .Include(x => x.Collaborative)
                .AsNoTracking()
                .ToListAsync();

            return await collabs;
        }

        public async Task<Collaborator> GetByCnpj(string cnpj)
        {
            var collab = _entityContext.Collaborators
                .Where(x => x.ClosingDate == null && x.CNPJ == cnpj)
                .Include(x => x.Collaborative)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }

        public async Task<Collaborator> GetByCpf(string cpf)
        {
            var collab = _entityContext.Collaborators
                .Where(x => x.ClosingDate == null && x.CPF == cpf)
                .Include(x => x.Collaborative)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }

        public async Task<Collaborator> GetByIdAsync(int id)
        {
            var collab = _entityContext.Collaborators
                .Where(x => x.ClosingDate == null && x.Id.Equals(id))
                .Include(x => x.Collaborative)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }

        public async Task<Collaborator> GetByMail(string mail)
        {
            var collab = _entityContext.Collaborators
                .Where(x => x.ClosingDate == null && x.Email == mail)
                .Include(x => x.Collaborative)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }

        public async Task<Collaborator> GetByName(string name)
        {
            var collab = _entityContext.Collaborators
                .Where(x => x.ClosingDate == null && x.Name == name)
                .Include(x => x.Collaborative)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await collab;
        }
    }
}
