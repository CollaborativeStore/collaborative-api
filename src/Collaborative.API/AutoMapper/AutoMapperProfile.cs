﻿using AutoMapper;
using Collaborative.API.ViewModels;
using Collaborative.API.ViewModels.Collaborative;
using Collaborative.API.ViewModels.Collaborator;
using Collaborative.API.ViewModels.User;
using Collaborative.Domain.Models;
using collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<collab, CollaborativeViewModel>().ReverseMap();
            CreateMap<collab, CollaborativeInsertViewModel>().ReverseMap();
            CreateMap<UserViewModel, CollaborativeInsertViewModel>().ReverseMap();
            
            CreateMap<Collaborator, CollaboratorViewModel>().ReverseMap();
            CreateMap<Collaborator, CollaboratorInsertViewModel>().ReverseMap();
            CreateMap<UserViewModel, CollaboratorInsertViewModel>().ReverseMap();

            CreateMap<FinancialAccount, FinancialAccountViewModel>().ReverseMap();
            CreateMap<OrderProduct, OrderProductViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Stock, StockViewModel>().ReverseMap();
        }
    }
}
 