﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCT.Adapter.AzureFunction.Entities
{
    [Table("mst_carrier")]
    public class Carrier : Entity
    {
        public string? Name { get; set; }
        public Guid Category { get; set; }
        public Guid Unit { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
    }
}
