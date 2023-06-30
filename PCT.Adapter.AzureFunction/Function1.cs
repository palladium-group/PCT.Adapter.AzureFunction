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
        private readonly ProductRepository _productRepository;
        private readonly CarrierRepository _carrierRepository;
        private readonly LocationRepository _locationRepository;
        private readonly VendorRepository _vendorRepository;
        private readonly DataContext _dataContext;

        public Function1(ILogger<Function1> log, 
            ProductRepository productRepository, 
            CarrierRepository carrierRepository,
            LocationRepository locationRepository,
            VendorRepository vendorRepository,
            DataContext dataContext)
        {
            _logger = log;
            _productRepository = productRepository;
            _carrierRepository= carrierRepository;
            _locationRepository= locationRepository;
            _vendorRepository= vendorRepository;
            _dataContext = dataContext;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        [FunctionName("Function1")]
        public async Task RunProductTrigger([ServiceBusTrigger("product", "dwh-product", Connection = "ServiceBusConnection")] string productJson, 
            ILogger log)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            try
            {
                Product product = JsonConvert.DeserializeObject<Product>(productJson);
                _productRepository.Create(product);
                log.LogInformation(product.Name + " saved successfully", null);
            }
            catch(Exception ex)
            {
                log.LogError(ex.InnerException.Message);
            }
        }

        [FunctionName("Function2")]
        public async Task RunCarrierTrigger([ServiceBusTrigger("carrier", "dwh-carrier", Connection = "ServiceBusConnection")] string json,
            ILogger log)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            try
            {
                Carrier carrier = JsonConvert.DeserializeObject<Carrier>(json);
                _carrierRepository.Create(carrier);
                log.LogInformation(carrier.Name + " saved successfully", null);
            }
            catch (Exception ex)
            {
                log.LogError(ex.InnerException.Message);
            }
        }

        [FunctionName("Function3")]
        public async Task RunLocationTrigger([ServiceBusTrigger("location", "dwh-location", Connection = "ServiceBusConnection")] string json,
            ILogger log)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            try
            {
                Location location = JsonConvert.DeserializeObject<Location>(json);
                _locationRepository.Create(location);
                log.LogInformation(location.Name + " saved successfully", null);
            }
            catch (Exception ex)
            {
                log.LogError(ex.InnerException.Message);
            }
        }

        [FunctionName("Function4")]
        public async Task RunVendorTrigger([ServiceBusTrigger("vendor", "dwh-vendor", Connection = "ServiceBusConnection")] string json,
            ILogger log)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            try
            {
                Vendor vendor = JsonConvert.DeserializeObject<Vendor>(json);
                _vendorRepository.Create(vendor);
                log.LogInformation(vendor.Name + " saved successfully", null);
            }
            catch (Exception ex)
            {
                log.LogError(ex.InnerException.Message);
            }
        }
    }
}
