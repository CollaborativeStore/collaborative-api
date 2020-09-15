﻿using Collaborative.API.ViewModels;
using Collaborative.API.ViewModels.Collaborative;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.API.Services.Interfaces
{
    public interface ICollaborativeService
    {
        Task<IEnumerable<CollaborativeViewModel>> GetAllAsync();
        Task<CollaborativeViewModel> GetByIdAsync(CollaborativeIdViewModel collaborativeIdViewModel);
        CollaborativeViewModel Add(CollaborativeViewModel collaborativeViewModel);
        void Update(CollaborativeViewModel collaborativeViewModel);
        Task<CollaborativeViewModel> Remove(CollaborativeIdViewModel collaborativeIdViewModel);
    }
}
