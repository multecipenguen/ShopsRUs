using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using ShopsRUs.Persistence.Contexts;

namespace ShopsRUs.Persistence.Repository
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
