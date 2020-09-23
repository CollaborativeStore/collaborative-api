using AutoMapper;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.Collaborative;
using Collaborative.API.ViewModels.Collaborator;
using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Interfaces.UoW;
using Collaborative.Domain.Models;
using Collaborative.Domain.Validation.CollaboratorValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.API.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly ICollaborativeRepository _collaborativeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CollaboratorService(ICollaborativeRepository collaborativeRepository, ICollaboratorRepository collaboratorRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _collaboratorRepository = collaboratorRepository;
            _collaborativeRepository = collaborativeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CollaboratorViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CollaboratorViewModel>>(await _collaboratorRepository.GetAllAsync());
        }

        public async Task<IEnumerable<CollaboratorViewModel>> GetAllByCollaborativeIdAsync(CollaborativeIdViewModel collaborativeIdViewModel)
        {
            return _mapper.Map<IEnumerable<CollaboratorViewModel>>(await _collaboratorRepository.GetAllByCollaborativeIdAsync(collaborativeIdViewModel.Id));
        }

        public async Task<IEnumerable<CollaboratorViewModel>> GetAllClosedAsync()
        {
            return _mapper.Map<IEnumerable<CollaboratorViewModel>>(await _collaboratorRepository.GetAllClosed());
        }

        public async Task<CollaboratorViewModel> GetByIdAsync(CollaboratorIdViewModel collaboratorIdViewModel)
        {
            return _mapper.Map<CollaboratorViewModel>(await _collaboratorRepository.GetByIdAsync(collaboratorIdViewModel.Id));
        }

        public async Task<CollaboratorViewModel> GetByCnpjAsync(CollaboratorCnpjViewModel collaboratorCnpjViewModel)
        {
            return _mapper.Map<CollaboratorViewModel>(await _collaboratorRepository.GetByCnpj(collaboratorCnpjViewModel.CNPJ));
        }

        public async Task<CollaboratorViewModel> GetByCpfAsync(CollaboratorCpfViewModel collaboratorCpfViewModel)
        {
            return _mapper.Map<CollaboratorViewModel>(await _collaboratorRepository.GetByCpf(collaboratorCpfViewModel.CPF));
        }

        public async Task<CollaboratorViewModel> GetByMailAsync(CollaboratorMailViewModel collaboratorMailViewModel)
        {
            return _mapper.Map<CollaboratorViewModel>(await _collaboratorRepository.GetByMail(collaboratorMailViewModel.Email));
        }

        public async Task<CollaboratorViewModel> GetByNameAsync(CollaboratorNameViewModel collaboratorNameViewModel)
        {
            return _mapper.Map<CollaboratorViewModel>(await _collaboratorRepository.GetByName(collaboratorNameViewModel.Name));
        }
        
        public async Task<CollaboratorViewModel> Add(CollaboratorInsertViewModel collaboratorInsertViewModel)
        {
            var collaborative = await _collaborativeRepository.GetByIdAsync(collaboratorInsertViewModel.CollaborativeId);
            
            if (collaborative == null)
            {
                throw new Exception("Collaborative not found!");
            }

            var model = _mapper.Map<Collaborator>(collaboratorInsertViewModel);

            var validation = new CollaboratorInsertValidation(_collaboratorRepository).Validate(model);

            if (!validation.IsValid)
            {
                throw new Exception("Collaborator is invalid!");
            }


            _collaboratorRepository.Add(model);
            _unitOfWork.Commit();
            
            model.Collaborative = collaborative;

            return _mapper.Map<CollaboratorViewModel>(model);
        }

        public async Task<CollaboratorViewModel> Remove(CollaboratorIdViewModel collaboratorIdViewModel)
        {
            var model = await _collaboratorRepository.GetByIdAsync(collaboratorIdViewModel.Id);

            if (model == null)
            {
                throw new Exception("Collaborator not found!");
            }

            model.ClosingDate = DateTime.Now;

            var validation = new CollaboratorDeleteValidation().Validate(model);

            if (!validation.IsValid)
            {
                return null;
            }

            _collaboratorRepository.Update(model);
            _unitOfWork.Commit();

            var viewModel = _mapper.Map<CollaboratorViewModel>(model);

            return viewModel;
        }

        public void Update(int id, CollaboratorInsertViewModel collaboratorInsertViewModel)
        {
            var model = _mapper.Map<Collaborator>(collaboratorInsertViewModel);
            model.Id = id;

            var validation = new CollaboratorUpdateValidator(_collaboratorRepository).Validate(model);

            if (!validation.IsValid)
            {
                return;
            }

            _collaboratorRepository.Update(model);
            _unitOfWork.Commit();
        }
    }
}
