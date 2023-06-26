using PCT.Adapter.AzureFunction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCT.Adapter.AzureFunction.Repository
{
    public class VendorRepository : Repository<Vendor>
    {
        public VendorRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
