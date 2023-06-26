using System.ComponentModel.DataAnnotations.Schema;

namespace PCT.Adapter.AzureFunction.Entities
{
    [Table("mst_vendor")]
    public class Vendor : Entity
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
    }
}
