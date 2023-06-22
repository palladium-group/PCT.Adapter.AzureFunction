using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCT.Adapter.AzureFunction.Entities
{
    public class Entity
    {
        [Key]
        public virtual Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            if (IsDeleted == null)
                IsDeleted = false;
            if (CreateDate == null)
                CreateDate = DateTime.Now;
        }
    }
}
