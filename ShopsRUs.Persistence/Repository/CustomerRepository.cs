using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using ShopsRUs.Persistence.Contexts;

namespace ShopsRUs.Persistence.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
