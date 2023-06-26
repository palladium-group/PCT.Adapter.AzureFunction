using PCT.Adapter.AzureFunction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCT.Adapter.AzureFunction.Repository
{
    public class LocationRepository : Repository<Location>
    {
        public LocationRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
