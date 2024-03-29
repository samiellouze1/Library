using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;

namespace LIbrary.Repository.Specific
{
    public class AvailabilityStatusRepository : EntityBaseRepository<AvailabilityStatus>, IAvailabilityStatusRepository
    {
        public AvailabilityStatusRepository(AppDbContext context) : base(context)
        {

        }
    }
}
