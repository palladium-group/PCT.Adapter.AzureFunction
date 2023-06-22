using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PCT.Adapter.AzureFunction.Entities;
using PCT.Adapter.AzureFunction.Repository;

namespace PCT.Adapter.AzureFunction
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly ProductRepository _repository;
        private readonly DataContext _dataContext;

        public Function1(ILogger<Function1> log, ProductRepository repository, DataContext dataContext)
        {
            _logger = log;
            _repository = repository;
            _dataContext = dataContext;
        }

        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger("product", "dwh-product", Connection = "ServiceBusConnection")] string productJson, 
            ILogger log)
        {
            try
            {
                Product product = JsonConvert.DeserializeObject<Product>(productJson);
                _repository.Create(product);
                log.LogInformation(product.Name + " saved successfully", null);
            }
            catch(Exception ex)
            {
                log.LogError(ex.Message);
                log.LogError(ex.InnerException.Message);
            }
        }
    }
}
