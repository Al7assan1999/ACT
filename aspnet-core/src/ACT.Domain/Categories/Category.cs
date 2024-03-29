﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ACT.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public List<Limits> Limits { get; set; }
    }
}
