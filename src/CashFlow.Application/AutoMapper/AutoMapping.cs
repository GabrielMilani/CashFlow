using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RequestRegisterExpenseJson, Expense>().ReverseMap(); 
            CreateMap<ResponseShortExpenseJson, Expense>().ReverseMap(); 
        }

    }
}
