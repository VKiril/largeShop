﻿using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Shipping
{
    public class ZoneModel : ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Scope { get; set; }
    }
}
