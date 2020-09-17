using AutoMapper;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels;
using Collaborative.API.ViewModels.Collaborative;
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


        public async Task<IEnumerable<CollaborativeViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CollaborativeViewModel>>(await _collaborativeRepository.GetAllAsync());
        }
        
        public async Task<IEnumerable<CollaborativeViewModel>> GetAllClosedAsync()
        {
            var collabs = _mapper.Map<IEnumerable<CollaborativeViewModel>>(await _collaborativeRepository.GetAllClosed());

            return collabs;
        }

        public async Task<CollaborativeViewModel> GetByIdAsync(CollaborativeIdViewModel collaborativeIdViewModel)
        {
            var collab = _mapper.Map<CollaborativeViewModel>(await _collaborativeRepository.GetByIdAsync(collaborativeIdViewModel.Id));

            return collab;
        }
        
        public async Task<CollaborativeViewModel> GetByCpfAsync(CollaborativeCpfViewModel collaborativeCpfViewModel)
        {
            var collab = _mapper.Map<CollaborativeViewModel>(await _collaborativeRepository.GetByCpf(collaborativeCpfViewModel.CPF));

            return collab;
        }
        
        public async Task<CollaborativeViewModel> GetByCnpjAsync(CollaborativeCnpjViewModel collaborativeCnpjViewModel)
        {
            var collab = _mapper.Map<CollaborativeViewModel>(await _collaborativeRepository.GetByCnpj(collaborativeCnpjViewModel.CNPJ));

            return collab;
        }

        public async Task<CollaborativeViewModel> GetByNameAsync(CollaborativeNameViewModel collaborativeNameViewModel)
        {
            var collab = _mapper.Map<CollaborativeViewModel>(await _collaborativeRepository.GetByName(collaborativeNameViewModel.Name));

            return collab;
        }
        
        public async Task<CollaborativeViewModel> GetByMailAsync(CollaborativeMailViewModel collaborativeMailViewModel)
        {
            var collab = _mapper.Map<CollaborativeViewModel>(await _collaborativeRepository.GetByMail(collaborativeMailViewModel.Mail));

            return collab;
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
        
        public async Task<CollaborativeViewModel> Remove(CollaborativeIdViewModel collaborativeIdViewModel)
        {
            var model = await _collaborativeRepository.GetByIdAsync(collaborativeIdViewModel.Id);
            model.ClosingDate = DateTime.Now;

            var validationDel = new CollaborativeDeleteValidation().Validate(model);

            if (!validationDel.IsValid)
            {
                return null;
            }


            _collaborativeRepository.Update(model);
            _unitOfWork.Commit();

            var viewModel = _mapper.Map<CollaborativeViewModel>(model);
            
            return viewModel;
        }

        public void Update(CollaborativeViewModel collaborativeViewModel)
        {
            var model = _mapper.Map<Collab>(collaborativeViewModel);

            var validation = new CollaborativeUpdateValidation(_collaborativeRepository).Validate(model);

            if (!validation.IsValid)
            {
                return;
            }

            _collaborativeRepository.Update(model);
            _unitOfWork.Commit();
        }
    }
}
