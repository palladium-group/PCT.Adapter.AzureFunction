using PCT.Adapter.AzureFunction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCT.Adapter.AzureFunction.Repository
{
    public class CarrierRepository : Repository<Carrier>
    {
        public CarrierRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
