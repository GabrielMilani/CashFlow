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
            RequestToEntity();
            ResponseToEntity();
        }
        public void RequestToEntity()
        {
            CreateMap<Expense, RequestExpenseJson>().ReverseMap();
            CreateMap<User, RequestRegisterUserJson>().ReverseMap();
        }
        public void ResponseToEntity()
        {
            CreateMap<Expense, ResponseRegisteredExpenseJson>().ReverseMap();
            CreateMap<Expense, ResponseShortExpenseJson>().ReverseMap();
            CreateMap<Expense, ResponseExpenseJson>().ReverseMap();
        }

    }
}
