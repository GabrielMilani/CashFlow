using CashFlow.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class IUserRepository : IUserReadOnlyRepository
    {
        private readonly CashFlowDbContext _context;

        public IUserRepository(CashFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.Equals(email));
        }
    }
}
