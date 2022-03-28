using DotnetBackend.Core.Entities;
using System.Linq.Expressions;

namespace DotnetBackend.Data.Repositories.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext db) : base(db)
        {
        }

        public static Expression<Func<Customer, bool>> IsActive => customer => customer.Status == Core.Status.ACTIVE && customer.IsDeleted == false;


        public IEnumerable<Customer> GetActiveCustomers()
        {
            return GetWhere(IsActive);
        }

        public IEnumerable<Customer> GetDeletedCustomers()
        {
            return GetWhere(x => x.IsDeleted == true);
        }
    }
}