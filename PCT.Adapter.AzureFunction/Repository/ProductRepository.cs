using PCT.Adapter.AzureFunction.Entities;

namespace PCT.Adapter.AzureFunction.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
