using AutoMapper;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels;
using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Interfaces.UoW;
using Collaborative.Domain.Validation.CollaborativeValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.API.Services
{
    public class CollaborativeService : ICollaborativeService
    {
        private readonly ICollaborativeRepository _collaborativeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CollaborativeService(ICollaborativeRepository collaborativeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _collaborativeRepository = collaborativeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public CollaborativeViewModel Add(CollaborativeViewModel collaborativeViewModel)
        {
            CollaborativeViewModel viewModel = null;

            var model = _mapper.Map<Collab>(collaborativeViewModel);

            var validation = new CollaborativeInsertValidation(_collaborativeRepository).Validate(model);

            if (!validation.IsValid)
            {
                throw new Exception("Collaborative is invalid!");
            }

            _collaborativeRepository.Add(model);
            _unitOfWork.Commit();

            viewModel = _mapper.Map<CollaborativeViewModel>(model);

            return viewModel;

        }

        public async Task<IEnumerable<CollaborativeViewModel>> GetAllAsync()
        {
            var collabs = _mapper.Map<IEnumerable<CollaborativeViewModel>>(await _collaborativeRepository.GetAllAsync());

            return collabs;
        }

        public async Task<CollaborativeViewModel> GetByIdAsync(int id)
        {
            var collab = _mapper.Map<CollaborativeViewModel>(await _collaborativeRepository.GetByIdAsync(id));

            return collab;
        }

        public void remove(CollaborativeViewModel collaborativeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(CollaborativeViewModel collaborativeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
