using DotnetBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DotnetBackend.Data.Repositories.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext db) : base(db)
        {
        }

        public static Expression<Func<Customer, bool>> IsActive => customer => customer.Status.Equals(Core.Constants.ACTIVE) && customer.IsDeleted == false;


        public async Task<IEnumerable<Customer>> GetActiveCustomers()
        {
            //string query = "SELECT * FROM CUSTOMERS WHERE Status = {0} AND IsDeleted = {1}";
            //var result =  db.Set<Customer>().FromSqlRaw(query, 30, false);
            //return await result.ToListAsync();
            return await GetWhere(IsActive);
        }

        public async Task<IEnumerable<Customer>> GetDeletedCustomers()
        {
            return await GetWhere(x => x.IsDeleted == true);
        }
    }
}